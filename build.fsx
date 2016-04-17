#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./bin/"

Target "clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "default" (fun _ ->
    CreateDir buildDir
    trace "build"
)

"clean"
    ==> "default"
    
RunTargetOrDefault "default"