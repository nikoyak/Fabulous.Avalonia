namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module LayoutTransformControlPage =
    type Model =
        { Min: float; Max: float; Angle: float }

    type Msg = SliderValueChanged of float

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Min = 0.; Max = 360.; Angle = 0. }, []

    let update msg model =
        match msg with
        | SliderValueChanged value -> { model with Angle = value }, []

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

            VStack(16.) {
                (VStack(16.) {
                    HStack() {
                        TextBlock("Rotation: ")
                        TextBlock($"{model.Angle}")
                    }

                    Slider(model.Min, model.Max, model.Angle, SliderValueChanged)
                        .width(200.)
                })
                    .margin(16.)
                    .centerHorizontal()

                (Grid(coldefs = [ Pixel(24.); Auto; Pixel(24.) ], rowdefs = [ Pixel(24.); Auto; Pixel(24.) ]) {
                    EmptyBorder()
                        .background(SolidColorBrush(Colors.Red))
                        .gridColumn(1)
                        .gridRow(0)

                    EmptyBorder()
                        .background(SolidColorBrush(Colors.Green))
                        .gridColumn(0)
                        .gridRow(1)

                    EmptyBorder()
                        .background(SolidColorBrush(Colors.Yellow))
                        .gridColumn(2)
                        .gridRow(1)

                    EmptyBorder()
                        .background(SolidColorBrush(Colors.Blue))
                        .gridColumn(1)
                        .gridRow(2)

                    LayoutTransformControl(Image(("avares://Gallery/Assets/Icons/fabulous-icon.png")))
                        .layoutTransform(RotateTransform(model.Angle, 0., 0))
                        .gridColumn(1)
                        .gridRow(1)
                })
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
            }
        }
