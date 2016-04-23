module Breed.Db

open System
open FSharp.Data.Sql

let [<Literal>] connStr = @"Server=127.0.0.1;Database=cleverclass;User Id=suave;Password=1234;"
let [<Literal>] dbVendor = Common.DatabaseProviderTypes.POSTGRESQL
let [<Literal>] resolutionFolder = @".\packages\Npgsql\lib\net45"
let [<Literal>] useOptTypes  = true

type Sql = 
    SqlDataProvider< dbVendor, 
                     connStr,  
                     ResolutionPath = resolutionFolder, 
                     UseOptionTypes = useOptTypes >

type DbContext = Sql.dataContext
type ClassGroup = DbContext.``public.classgroupsEntity``

let getContext() = Sql.GetDataContext()

let getClassGroups (ctx : DbContext) : ClassGroup list = 
    ctx.Public.Classgroups |> Seq.toList