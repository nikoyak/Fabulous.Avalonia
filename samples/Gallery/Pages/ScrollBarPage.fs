namespace Gallery

open System.Diagnostics
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ScrollBarPage =
    type Model = { ScrollValue: float }

    type Msg =
        | ValueChanged of float
        | ScrollBarChanged of ScrollEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { ScrollValue = 0.0 }, []

    let update msg model =
        match msg with
        | ValueChanged value -> { ScrollValue = value }, []
        | ScrollBarChanged _ -> model, []

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component(program) {
            let! model = Mvu.State

            VStack(spacing = 15.) {

                TextBlock($"Value: {model.ScrollValue}")

                ScrollBar(1., 240., model.ScrollValue, ValueChanged)
                    .orientation(Orientation.Horizontal)
                    .allowAutoHide(false)
                    .background(SolidColorBrush(Colors.LightSalmon))
                    .margin(10., 10., 0., 0.)
                    .onScroll(ScrollBarChanged)
            }
        }
