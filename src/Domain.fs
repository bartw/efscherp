module Breed.Domain

type ClassGroupDto = { Id : int
                       Name : string }
                       
let mapClassGroupToDto (classGroup : Db.ClassGroup) = { Id = classGroup.Id 
                                                        Name = classGroup.Name }
                                                        
let getClassGroups () = Db.getContext () 
                        |> Db.getClassGroups
                        |> List.map mapClassGroupToDto