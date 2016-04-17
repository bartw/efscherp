#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./bin/"
let sourceFiles = ["./src/app.fs"]
let outputFile = "app.exe"
let outputPath = buildDir + outputFile
let references = [ "./packages/FSharp.Core/lib/net40/FSharp.Core.dll" 
                   "./packages/Suave/lib/net40/Suave.dll" ]
let fscParameters = [ FscHelper.FscParam.Out outputPath
                      FscHelper.FscParam.Target FscHelper.TargetType.Exe
                      FscHelper.FscParam.NoFramework ]          
let fscParametersWithReferences = fscParameters @ 
                                  List.map (fun reference -> FscHelper.FscParam.Reference reference) references                           

Target "clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "default" (fun _ ->
    CreateDir buildDir
    CopyFiles buildDir references
    sourceFiles
    |> FscHelper.Compile fscParametersWithReferences
)

"clean"
    ==> "default"
    
RunTargetOrDefault "default"