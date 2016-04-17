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
    |> FscHelper.Fsc (fun p ->
        { p with Output = buildDir + outputFile })
)

"clean"
    ==> "default"
    
RunTargetOrDefault "default"