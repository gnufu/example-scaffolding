#I @"packages/build/FAKE/tools/"
#r @"FakeLib.dll"
#load "packages/build/SourceLink.Fake/tools/SourceLink.fsx"
#r @"paket-files\build\vrvis\Aardvark.Fake\bin\Aardvark.Fake.dll"


open Fake
open System
open System.IO
open System.Diagnostics
open Aardvark.Fake

do Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

//DefaultTargets.install ["src/Aardvark.Rendering.sln"]

// start build
//RunTargetOrDefault "Default"