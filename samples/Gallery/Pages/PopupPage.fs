namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PopupPage =
    type Model = { IsOpen: bool }

    type Msg =
        | OpenPopup
        | OnOpened
        | OnClosed

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsOpen = false }, []

    let update msg model =
        match msg with
        | OpenPopup -> { IsOpen = not model.IsOpen }, []
        | OnOpened -> model, []
        | OnClosed -> model, []

    let buttonRef = ViewRef<Button>()

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

            (VStack(spacing = 15.) {
                Button("Click me", OpenPopup)

                Popup(
                    model.IsOpen,
                    (Grid(coldefs = [ Pixel(300) ], rowdefs = [ Auto; Pixel(200.) ]) {
                        Ellipse()
                            .size(100., 100.)
                            .fill(SolidColorBrush(Colors.Green))

                        TextBlock("This is a popup content")
                            .centerHorizontal()
                            .centerVertical()
                            .gridRow(1)
                    })
                        .background(SolidColorBrush(Colors.LightGray))
                )
                    .onOpened(OnOpened)
                    .onClosed(OnClosed)
                    .placement(PlacementMode.Bottom)
                    .placementGravity(PopupGravity.Bottom)
                    .placementAnchor(PopupAnchor.Bottom)
                    .placementConstraintAdjustment(PopupPositionerConstraintAdjustment.FlipY)
                    .placementRect(Rect(0., 0., 100., 100.))
            })
                .center()
        }
