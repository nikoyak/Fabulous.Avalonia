namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Input
open Fabulous

type IFabPopupFlyoutBase =
    inherit IFabFlyoutBase

module PopupFlyoutBase =
    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.VerticalOffsetProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementAnchorProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementGravityProperty

    let ShowMode =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.ShowModeProperty

    let OverlayInputPassThroughElement =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.OverlayInputPassThroughElementProperty

    let PlacementConstraintAdjustment =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementConstraintAdjustmentProperty

    let Opening =
        Attributes.defineEventNoArg "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        Attributes.defineEvent "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

[<Extension>]
type PopupFlyoutBaseModifiers =
    /// <summary>Sets the Placement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Placement value.</param>
    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PlacementMode) =
        this.AddScalar(PopupFlyoutBase.Placement.WithValue(value))

    /// <summary>Sets the HorizontalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalOffset value.</param>
    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: double) =
        this.AddScalar(PopupFlyoutBase.HorizontalOffset.WithValue(value))

    /// <summary>Sets the VerticalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalOffset value.</param>
    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: double) =
        this.AddScalar(PopupFlyoutBase.VerticalOffset.WithValue(value))

    /// <summary>Sets the PlacementAnchor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementAnchor value.</param>
    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PopupAnchor) =
        this.AddScalar(PopupFlyoutBase.PlacementAnchor.WithValue(value))

    /// <summary>Sets the PlacementGravity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementGravity value.</param>
    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PopupGravity) =
        this.AddScalar(PopupFlyoutBase.PlacementGravity.WithValue(value))

    /// <summary>Sets the ShowMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowMode value.</param>
    [<Extension>]
    static member inline showMode(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: FlyoutShowMode) =
        this.AddScalar(PopupFlyoutBase.ShowMode.WithValue(value))

    /// <summary>Sets the OverlayInputPassThroughElement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OverlayInputPassThroughElement value.</param>
    [<Extension>]
    static member inline overlayInputPassThroughElement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: IInputElement) =
        this.AddScalar(PopupFlyoutBase.OverlayInputPassThroughElement.WithValue(value))

    /// <summary>Sets the PlacementConstraintAdjustment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementConstraintAdjustment value.</param>
    [<Extension>]
    static member inline placementConstraintAdjustment(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PopupPositionerConstraintAdjustment) =
        this.AddScalar(PopupFlyoutBase.PlacementConstraintAdjustment.WithValue(value))

    /// <summary>Listens to the PopupFlyoutBase Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is opening.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, fn: 'msg) =
        this.AddScalar(PopupFlyoutBase.Opening.WithValue(MsgValue fn))

    /// <summary>Listens to the PopupFlyoutBase Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is closing.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(PopupFlyoutBase.Closing.WithValue(fn))
