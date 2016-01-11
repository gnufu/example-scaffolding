#I "..\packages\Aardvark.Application"
#I "..\packages\Aardvark.Application.WinForms"
#I "..\packages\Aardvark.Application.WinForms.GL"
#I "..\packages\Aardvark.Base"
#I "..\packages\Aardvark.Base.Essentials"
#I "..\packages\Aardvark.Base.FSharp"
#I "..\packages\Aardvark.Base.Incremental"
#I "..\packages\Aardvark.Base.Rendering"
#I "..\packages\Aardvark.Base.Runtime"
#I "..\packages\Aardvark.Rendering.GL"
#I "..\packages\Aardvark.Rendering.NanoVg"
#I "..\packages\Aardvark.SceneGraph"
#I "..\packages\FShade"
#r @"lib\net45\Aardvark.Base.TypeProviders.dll"
#r @"lib\net45\Aardvark.Base.dll"
#r @"lib\net45\Aardvark.Base.Essentials.dll"
#r @"lib\net45\Aardvark.Base.FSharp.dll"
#r @"lib\net45\Aardvark.Base.Incremental.dll"
#r @"lib\net45\Aardvark.Base.Runtime.dll"
#r @"lib\net45\Aardvark.Base.Rendering.dll"
#r @"lib\net45\FShade.dll"
#r @"lib\net45\FShade.Compiler.dll"
#r @"lib\net45\Aardvark.SceneGraph.dll"
#r @"lib\net45\Aardvark.Rendering.NanoVg.dll"
#r @"lib\net45\Aardvark.Rendering.GL.dll"
#r @"lib\net45\Aardvark.Application.dll"
#r @"lib\net45\Aardvark.Application.WinForms.dll"
#r @"lib\net45\Aardvark.Application.WinForms.GL.dll"


namespace Examples

[<AutoOpen>]
module FsiSetup =


    open System
    open Aardvark.Base
    open Aardvark.Base.Incremental
    open Aardvark.Base.Rendering
    open Aardvark.Rendering.NanoVg
    open Aardvark.SceneGraph
    open Aardvark.SceneGraph.Semantics

    open Aardvark.Application
    open Aardvark.Application.WinForms

    let runInteractive () =
           
        
        //System.Environment.CurrentDirectory <- System.IO.Path.Combine(__SOURCE_DIRECTORY__, @".")
        //IntrospectionProperties.CustomEntryAssembly <- System.Reflection.Assembly.LoadFile <| System.IO.Path.Combine(__SOURCE_DIRECTORY__, @"..\..\..\bin\Debug\Examples.exe")

        Aardvark.Init()
        Ag.initialize()
        Aardvark.Base.Ag.unpack <- fun o ->
                match o with
                    | :? IMod as o -> o.GetValue(null)
                    | _ -> o


        let app = new OpenGlApplication()
        let win = app.CreateSimpleRenderWindow(1)
        let root = Mod.init <| (Sg.group [] :> ISg)


        let task = app.Runtime.CompileRender(win.FramebufferSignature, Sg.DynamicNode root)

        win.Text <- @"Aardvark rocks \o/"
        win.TopMost <- true
        win.Visible <- true

        let fixupRenderTask () =
            if win.RenderTask = Unchecked.defaultof<_> then win.RenderTask <- task

        (fun s -> fixupRenderTask () ; transact (fun () -> Mod.change root s)), win, task

