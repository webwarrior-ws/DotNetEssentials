#!/usr/bin/env fsharpi

open System
open System.IO
open System.Linq

#r "System.Configuration"
#load "../fsx/InfraLib/Misc.fs"
#load "../fsx/InfraLib/Process.fs"
#load "../fsx/InfraLib/Network.fs"
open FSX.Infrastructure
open Process
open System.IO
open System.Linq

let MaybeUpload (packageName: string) =
    let outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output") |> DirectoryInfo
    let nupkgFile = outputDir.EnumerateFiles().Single(fun file -> file.Name.StartsWith packageName && file.FullName.EndsWith ".nupkg")
    let argsPassedToThisScript = Misc.FsxArguments()
    if argsPassedToThisScript.Length <> 1 then
        Console.WriteLine "NUGET_API_KEY not passed to script, skipping upload..."
    else
        let nugetApiKey = argsPassedToThisScript.First()
        let githubRef = Environment.GetEnvironmentVariable "GITHUB_REF"
// Had to disable this due to developing in a branch
//        if githubRef <> "refs/heads/master" then
//            Console.WriteLine "Branch different than master, skipping upload..."
//        else
        let defaultNugetFeedUrl = "https://api.nuget.org/v3/index.json"
        let nugetPushCmd =
            {
                Command = "dotnet"
                Arguments = sprintf "nuget push %s -k %s -s %s"
                                    nupkgFile.FullName nugetApiKey defaultNugetFeedUrl
            }
        Console.WriteLine "Pushing package..."
        Process.SafeExecute (nugetPushCmd, Echo.All) |> ignore
        Console.WriteLine "Pushing completed!"


Console.WriteLine "Packaging..."
MaybeUpload "DotNetEssentials"
