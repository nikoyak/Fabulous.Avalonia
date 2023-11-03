namespace Fabulous.Avalonia

open System
open System.Collections
open Avalonia.Controls
open Avalonia.Controls.Templates
open Avalonia.Data
open Avalonia.Markup.Xaml.Templates
open Fabulous

type WidgetDataTemplate(node: IViewNode, templateFn: obj -> Widget) as this =
    inherit FuncDataTemplate(typeof<obj>, System.Func<obj, INameScope, Control>(fun data n -> this.Build(data, n)), supportsRecycling = false)

    member this.Recycle(newData: obj, prevWidget: Widget, rowNode: IViewNode) : Widget =
        let currWidget = templateFn newData
        Reconciler.update node.TreeContext.CanReuseView (ValueSome prevWidget) currWidget rowNode
        currWidget

    member this.Build(data: obj, _: INameScope) =
        let widget = templateFn data
        let definition = WidgetDefinitionStore.get widget.Key

        let struct (_, view) =
            definition.CreateView(widget, node.TreeContext, ValueSome node)

        let item = ContentControl()
        item.Content <- (view :?> Control)

        item

type WidgetTreeDataTemplate(node: IViewNode, childrenFn: obj -> IEnumerable, templateFn: obj -> Widget) =

    interface ITreeDataTemplate with
        member this.ItemsSelector(item) =
            InstancedBinding.OneTime(childrenFn item)

        member this.Match(_data) = true

        member this.Build(data: obj) =
            let widget = templateFn data
            let definition = WidgetDefinitionStore.get widget.Key

            let struct (_, view) =
                definition.CreateView(widget, node.TreeContext, ValueSome node)

            view :?> Control
