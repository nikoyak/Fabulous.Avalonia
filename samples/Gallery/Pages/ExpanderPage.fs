namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ExpanderPage =
    type Model = { IsExpanded: bool }

    type Msg =
        | ExpandChanged of bool
        | Expanding of CancelRoutedEventArgs
        | Collapsing of CancelRoutedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsExpanded = true }, []

    let update msg model =
        match msg with
        | ExpandChanged b -> { IsExpanded = b }, []
        | Expanding _ -> model, []
        | Collapsing _ -> model, []

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
                Expander("Title", "Mr.").isExpanded(model.IsExpanded)

                Expander(TextBlock("Title"), "Mr.")
                    .onExpandedChanged(model.IsExpanded, ExpandChanged)

                Expander(
                    "Title",
                    VStack(8.) {
                        TextBlock("Mr.")
                        TextBlock("Mr.")
                        TextBlock("Ms.")
                        TextBlock("Mr.")
                    }
                )
                    .contentTransition(CrossFade(TimeSpan.FromSeconds(2.5)) :> IPageTransition)


                Expander(
                    TextBlock("Marital status"),
                    VStack(8.) {
                        TextBlock("Married")
                        Separator()
                        TextBlock("Single")
                        Separator()
                        TextBlock("Divorced")
                        Separator()
                        TextBlock("Widowed")
                    }
                )
                    .expandDirection(ExpandDirection.Right)
                    .onCollapsing(Collapsing)
                    .onExpanding(Expanding)
            }
        }
