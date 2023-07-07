namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Styling
open Fabulous

type IFabTopLevel =
    inherit IFabContentControl

module TopLevel =
    let PointerOverElement =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.PointerOverElementProperty

    let ThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.RequestedThemeVariantProperty

    let ThemeVariantChanged =
        Attributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

    let TransparencyLevelHint =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyLevelHintProperty

    let SystemBarColorWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.SystemBarColorProperty

    let SystemBarColor =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.SystemBarColorProperty

    let TransparencyBackgroundFallbackWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.TransparencyBackgroundFallbackProperty

    let TransparencyBackgroundFallback =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyBackgroundFallbackProperty

    let Opened =
        Attributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let ScalingChanged =
        Attributes.defineEventNoArg "TopLevel_ScalingChangedEvent" (fun target -> (target :?> TopLevel).ScalingChanged)

    let BackRequested =
        Attributes.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

[<Extension>]
type TopLevelModifiers =
    [<Extension>]
    static member inline pointerOverElement(this: WidgetBuilder<'msg, #IFabTopLevel>, value: IInputElement) =
        this.AddScalar(TopLevel.PointerOverElement.WithValue(value))

    [<Extension>]
    static member inline themeVariant(this: WidgetBuilder<'msg, #IFabTopLevel>, value: ThemeVariant) =
        this.AddScalar(TopLevel.ThemeVariant.WithValue(value))

    [<Extension>]
    static member inline onThemeVariantChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: ThemeVariant -> 'msg) =
        this.AddScalar(TopLevel.ThemeVariantChanged.WithValue(fn Application.Current.ActualThemeVariant))

    [<Extension>]
    static member inline transparencyLevelHint(this: WidgetBuilder<'msg, #IFabTopLevel>, alignment: WindowTransparencyLevel list) =
        this.AddScalar(TopLevel.TransparencyLevelHint.WithValue(alignment))

    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallbackWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, brush: IBrush) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(brush))

    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, brush: string) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.SystemBarColorWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, brush: string) =
        this.AddScalar(TopLevel.SystemBarColor.WithValue(brush |> SolidColorBrush.Parse))

    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, onOpened: 'msg) =
        this.AddScalar(TopLevel.Opened.WithValue(onOpened))

    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, onClosed: 'msg) =
        this.AddScalar(TopLevel.Closed.WithValue(onClosed))

    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<'msg, #IFabTopLevel>, onBackRequested: 'msg) =
        this.AddScalar(TopLevel.BackRequested.WithValue(fun _ -> onBackRequested |> box))

    [<Extension>]
    static member inline onScalingChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, onScalingChanged: 'msg) =
        this.AddScalar(TopLevel.ScalingChanged.WithValue(onScalingChanged))
