#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./bin/"
let sourceFiles = ["./src/app.fs"]
let outputFile = "app.exe"

Target "clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "default" (fun _ ->
    CreateDir buildDir
    sourceFiles
    |> FscHelper.Compile [ FscHelper.FscParam.Out "./bin/app.exe"
                           FscHelper.FscParam.Target FscHelper.TargetType.Exe]
)

"clean"
    ==> "default"
    
RunTargetOrDefault "default"