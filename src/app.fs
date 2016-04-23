module Breed.App

open Suave
open Suave.Filters
open Suave.Json
open Suave.Operators
open Suave.Successful
open System
open Newtonsoft.Json
open Newtonsoft.Json.Serialization

let jsonSerializerSettings = new JsonSerializerSettings()
jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

let jsonWebPart obj = JsonConvert.SerializeObject(obj, jsonSerializerSettings)
                         |> OK
                         >=> Writers.setMimeType "application/json; charset=utf-8" 

let getClassGroups = warbler ( fun _ -> Domain.getClassGroups ()
                                        |> jsonWebPart)

let routes = 
    choose 
        [ GET >=> choose 
            [ path "/classgroups" >=> getClassGroups ]
          POST >=> choose 
            [ path ".classgoups" >=> OK "post classgroups" ] ]

startWebServer defaultConfig routes