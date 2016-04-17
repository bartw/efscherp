#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./bin/"
let sourceFiles = ["./src/app.fs"]
let outputFile = "app.exe"
let outputPath = buildDir + outputFile

Target "clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "default" (fun _ ->
    CreateDir buildDir
    sourceFiles
    |> FscHelper.Compile [ FscHelper.FscParam.Out outputPath
                           FscHelper.FscParam.Target FscHelper.TargetType.Exe]
)

"clean"
    ==> "default"
    
RunTargetOrDefault "default"