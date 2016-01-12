#I @"packages\build\"

#r @"FAKE\tools\FakeLib.dll"
#r @"Paket.Core\lib\net45\Chessie.dll"
#r @"Paket.Core\lib\net45\Paket.Core.dll"
#r @"Mono.Cecil\lib\net45\Mono.Cecil.dll"
#r "System.IO.Compression.dll"
#r "System.IO.Compression.FileSystem.dll"

#load @"paket-files\build\vrvis\Aardvark.Fake\AdditionalSources.fsx"
#load @"paket-files\build\vrvis\Aardvark.Fake\AssemblyResources.fsx"
#load @"paket-files\build\vrvis\Aardvark.Fake\Targets.fsx"
#load @"paket-files\build\vrvis\Aardvark.Fake\DefaultSetup.fsx"


open Fake
open System
open System.IO
open System.Diagnostics
open Aardvark.Fake

do Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

DefaultSetup.install ["src/Stub.sln"]

// start build
RunTargetOrDefault "Default"