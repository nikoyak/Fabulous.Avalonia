namespace Gallery

open System
open System.Diagnostics
open Avalonia.Controls
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module CalendarPage =
    type Model =
        { Date1: DateTime option
          Date2: DateTime option }

    type Msg =
        | SelectedDateChanged of DateTime option
        | SelectedDatesChanged2 of DateTime option

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Date1 = Some DateTime.Now
          Date2 = Some DateTime.Now },
        []

    let update msg model =
        match msg with
        | SelectedDateChanged dateTime -> { model with Date1 = dateTime }, []
        | SelectedDatesChanged2 dateTime -> { model with Date2 = dateTime }, []

    let startFromYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1.0))

    let showUpToTomorrow = DateTime.Today.Add(TimeSpan.FromDays(1.0))

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
                TextBlock($"Selected: {model.Date1}")
                TextBlock("SingleDate").centerHorizontal()

                Calendar(model.Date1, SelectedDateChanged)
                    .displayDateStart(startFromYesterday)
                    .displayDateEnd(showUpToTomorrow)
                    .centerHorizontal()

                TextBlock($"Selected: {model.Date2}")
                TextBlock("MultipleRange").centerHorizontal()

                Calendar(model.Date2, SelectedDatesChanged2, CalendarSelectionMode.MultipleRange)
                    .displayMode(CalendarMode.Month)
                    .center()

            }
        }
