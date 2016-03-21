﻿namespace Speakers.Controllers

open System
open System.Net
open System.Net.Http
open System.Web.Http
open Speakers.Models
open Speakers.Repositories


type SpeakersController() =
    inherit ApiController()

    member x.Get() =
        printfn "Received GET request for speakers"
        let speakers = getAllSpeakers
        x.Request.CreateResponse(speakers)

    member x.Get(id:int) =
        printfn "Received GET request for speaker with id %d" id
        let speaker = getSpeaker id
        match speaker with
        | Some speaker -> x.Request.CreateResponse(speaker)
        | None -> x.Request.CreateResponse(HttpStatusCode.NotFound)