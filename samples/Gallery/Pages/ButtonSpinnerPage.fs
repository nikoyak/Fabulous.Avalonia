namespace Gallery

open System
open System.Diagnostics
open Avalonia.Controls
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ButtonSpinnerPage =
    type Model = { Count: int }

    type Msg = Increment of SpinEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Count = 0 }, []

    let update msg model =
        match msg with
        | Increment args ->
            let spinner = args.Source :?> ButtonSpinner
            let currentSpinValue = spinner.Content :?> string

            let mutable currentValue =
                if String.IsNullOrEmpty(currentSpinValue) then
                    0
                else
                    Convert.ToInt32(currentSpinValue)

            if (args.Direction = SpinDirection.Increase) then
                currentValue <- currentValue + 1
            else
                currentValue <- currentValue - 1

            spinner.Content <- currentValue.ToString()

            { Count = model.Count + 1 }, []

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
            VStack(spacing = 15.) {
                TextBlock("Button spinner")

                ButtonSpinner("1", Increment)
            }
        }
