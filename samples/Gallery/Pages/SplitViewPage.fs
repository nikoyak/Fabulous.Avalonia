namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module SplitViewPage =
    type Model = { IsOpen: bool }

    type Msg = | Open

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsOpen = false }, []

    let update msg model =
        match msg with
        | Open -> { IsOpen = not model.IsOpen }, []

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

            VStack() {
                Button("Open", Open)

                SplitView(
                    TextBlock("Pane")
                        .fontSize(24.)
                        .verticalAlignment(VerticalAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center),

                    Grid() {
                        TextBlock("Content")
                            .fontSize(24.)
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)

                    }
                )
                    .isPaneOpen(model.IsOpen)
                    .paneBackground(SolidColorBrush(Colors.LightGray))
                    .useLightDismissOverlayMode(true)

                    .displayMode(SplitViewDisplayMode.Inline)
                    .openPaneLength(296.0)
            }
        }
