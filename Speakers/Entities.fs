﻿namespace Speakers.Entities

open System

type Rating =
    | Zero = 0
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5

type TalkStatus =
    | Unassigned = 0
    | Assigned = 1
    | InProgress = 2
    | Deferred = 3
    | TopicApproved = 4
    | DateAssigned = 5

type Speaker = {
    Name : string
    Rating : Rating
    LastContacted : DateTime
}

type Admin = {
    Name : string
    ImageUrl : string
}

type Talk = {
    Title : string
    Status : TalkStatus
    Speaker : Speaker
    Admin : Admin
}   

[<AutoOpen>]
module Helpers = 
    let exampleTalks = 
        seq { 
            yield { Title = "To know javascript is to love javascript"
                    Status = TalkStatus.Assigned
                    Speaker = 
                        { Name = "Thomas Hull"
                          Rating = Rating.Zero
                          LastContacted = DateTime(1970, 1, 1) }
                    Admin = 
                        { Name = "David Wybourn"
                          ImageUrl = "https://placebear.com/50/50" } }
            yield { Title = "F#: The sharpest tool in the shed"
                    Status = TalkStatus.Deferred
                    Speaker = 
                        { Name = "Jason Ebbin"
                          Rating = Rating.Five
                          LastContacted = DateTime(1989, 11, 09) }
                    Admin = 
                        { Name = "Jason Ebbin"
                          ImageUrl = "https://placebear.com/50/50" } }
            yield { Title = "Concourse: Where I met myself"
                    Status = TalkStatus.TopicApproved
                    Speaker = 
                        { Name = "David Wybourn"
                          Rating = Rating.Three
                          LastContacted = DateTime(2015, 10, 21) }
                    Admin = 
                        { Name = "Chris James Smith"
                          ImageUrl = "https://placebear.com/50/50" } }
            yield { Title = ""
                    Status = TalkStatus.InProgress
                    Speaker = 
                        { Name = "Joe Bloggs"
                          Rating = Rating.Two
                          LastContacted = DateTime(2016, 02, 19) }
                    Admin = 
                        { Name = "Thomas Hull"
                          ImageUrl = "https://placebear.com/50/50" } }
            yield { Title = "C# or F#: Which is sharper?"
                    Status = TalkStatus.DateAssigned
                    Speaker = 
                        { Name = "Chris Smith"
                          Rating = Rating.Four
                          LastContacted = DateTime(2016, 01, 10) }
                    Admin = 
                        { Name = "Thomas Hull"
                          ImageUrl = "https://placebear.com/50/50" } }
        }