namespace Gallery

open System.Collections.ObjectModel
open System.Diagnostics
open System.Threading.Tasks
open Avalonia.Controls
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous
open Avalonia.Input

open type Fabulous.Avalonia.View

module RefreshContainerPage =
    type Model = { Items: ObservableCollection<string> }

    type Msg = RefreshRequested of RefreshRequestedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Items = ObservableCollection([ 0..200 ] |> List.map(fun x -> $"Item %d{x}")) }, []

    let update msg model =
        match msg with
        | RefreshRequested args ->
            let deferral = args.GetDeferral()

            Task.Delay(3000) |> Async.AwaitTask |> Async.RunSynchronously

            model.Items.Insert(0, $"Item %d{200 - model.Items.Count}")

            deferral.Complete()

            model, []

    let container model =
        ListBox(model.Items, (fun x -> TextBlock(x)))
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .verticalAlignment(VerticalAlignment.Top)

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

            (Dock() {
                Label("A control that supports pull to refresh")
                    .dock(Dock.Top)

                RefreshContainer(container model)
                    .onRefreshRequested(RefreshRequested)
                    .pullDirection(PullDirection.TopToBottom)
                    .horizontalAlignment(HorizontalAlignment.Stretch)
                    .verticalAlignment(VerticalAlignment.Stretch)
                    .margin(5.)
                    .dock(Dock.Bottom)

            })
                .horizontalAlignment(HorizontalAlignment.Stretch)
                .verticalAlignment(VerticalAlignment.Top)
                .height(600.)
        }
