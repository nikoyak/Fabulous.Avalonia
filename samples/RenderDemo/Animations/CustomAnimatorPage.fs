namespace RenderDemo

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Styling
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

type CustomStringAnimator() =
    inherit InterpolatingAnimator<string>()

    override this.Interpolate(progress, _oldValue, newValue) =

        if newValue.Length = 0 then
            ""
        else
            let step = 1.0 / float newValue.Length
            let length = int(progress / step)
            let result = newValue.Substring(0, length + 1)
            result

module CustomAnimatorPage =
    type Model = { Value: int }

    type Msg = Loaded of RoutedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        Animation.RegisterCustomAnimator<string, CustomStringAnimator>()
        { Value = 0 }, []

    let update msg model =
        match msg with
        | Loaded _ ->
            Animation.SetAnimator(Setter(TextBlock.TextProperty, ""), CustomStringAnimator())
            model, []

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
            Grid() {
                TextBlock("")
                    .centerHorizontal()
                    .onLoaded(Loaded)
                    .animation(
                        Animation(KeyFrame(TextBlock.TextProperty, "0123456789").cue(1.), TimeSpan.FromSeconds(3.))
                            .repeatForever()
                    )
            }
        }
