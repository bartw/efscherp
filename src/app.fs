module Breed.App

open Suave
open Suave.Filters
open Suave.Json
open Suave.Operators
open Suave.Successful
open System
open Newtonsoft.Json

let routes = choose [ path "/" >=> (OK "Home") 
                      path "/classgroups" >=> (OK (JsonConvert.SerializeObject(Db.getContext() 
                                                                               |> Db.getClassGroups 
                                                                               |> List.map (fun cg -> cg.Name))))]

startWebServer defaultConfig routes