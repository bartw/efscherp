open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let routes = choose [ path "/" >=> (OK "Home") ]

startWebServer defaultConfig routes