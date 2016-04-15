﻿namespace Startup

open Newtonsoft.Json
open Owin
open System.Net.Http.Headers
open System.Web.Http
open Serilog

module private ConfigurationHelpers =

    let configureSerializationFormatters (config : HttpConfiguration) =
        config.Formatters.XmlFormatter.UseXmlSerializer <- true

        //The following lines are for controlling the serialisation of F# properties from Records and Unions
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver ()

        config.Formatters.JsonFormatter.SerializerSettings.MissingMemberHandling <- MissingMemberHandling.Error
        config.Formatters.JsonFormatter.SerializerSettings.Error <- new System.EventHandler<Serialization.ErrorEventArgs>(fun _ errorEvent ->
            let context = System.Web.HttpContext.Current
            let error = errorEvent.ErrorContext.Error
            context.AddError(error)
            errorEvent.ErrorContext.Handled <- true)
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(MediaTypeHeaderValue("text/html"))

        Log.Information("Configured JSON serialisation")

        config

    let registerConfiguration (config : HttpConfiguration) =
        config
        |> Bristech.Srm.HttpConfig.Logging.configure
        |> Bristech.Srm.HttpConfig.Cors.configure
        |> Bristech.Srm.HttpConfig.Routes.configure
        |> configureSerializationFormatters

type Startup() =
    member __.Configuration (appBuilder: IAppBuilder) =
        let config = ConfigurationHelpers.registerConfiguration(new HttpConfiguration())        
        appBuilder.UseWebApi(config) |> ignore