namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module SplitButtonPage =
    type Model = { Colors: Color list }

    type Msg = | Clicked

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Colors =
            [ Colors.Red
              Colors.Green
              Colors.Blue
              Colors.Yellow
              Colors.Purple
              Colors.Orange
              Colors.Pink
              Colors.Brown
              Colors.Black
              Colors.White
              Colors.Gray
              Colors.Cyan
              Colors.Magenta
              Colors.Lime
              Colors.Turquoise
              Colors.Black
              Colors.Red
              Colors.Bisque
              Colors.White ] },
        []

    let update msg model =
        match msg with
        | Clicked -> model, []

    let menuFlyout () =
        (MenuFlyout() {
            MenuItems("Item 1") {
                MenuItem("Subitem 1")
                MenuItem("Subitem 2")
                MenuItem("Subitem 3")
            }

            MenuItem("Item 2")
                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

            MenuItem("Item 3")
        })
            .placement(PlacementMode.Bottom)

    let availableColors (colors: Color list) =
        (MenuFlyout() {
            MenuItem(
                ScrollViewer(
                    HWrap() {
                        for color in colors do
                            Rectangle().size(50., 50.).fill(SolidColorBrush(color))
                    }
                )

            )
        })
            .placement(PlacementMode.Bottom)

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

            (VStack(spacing = 16.) {
                SplitButton("Content", Clicked).flyout(menuFlyout())

                SplitButton("Disabled", Clicked).isEnabled(false)

                SplitButton("Re-themed", Clicked)
                    .flyout(menuFlyout())
                    .foreground(SolidColorBrush(Colors.White))

                SplitButton(Clicked, Rectangle().size(32., 32.).fill(SolidColorBrush(Colors.Red)))
                    .flyout(availableColors model.Colors)
            })
                .horizontalAlignment(HorizontalAlignment.Center)
        }
