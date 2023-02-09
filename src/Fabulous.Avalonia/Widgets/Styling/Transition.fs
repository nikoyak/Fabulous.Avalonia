namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous

type IFabTransition =
    inherit IFabElement

type IDoubleTransition =
    inherit IFabTransition

module DoubleTransition =
    let WidgetKey = Widgets.register<DoubleTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "DoubleTransition_Duration" (fun target -> (target :?> DoubleTransition).Duration) (fun target value ->
            (target :?> DoubleTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "DoubleTransition_Delay" (fun target -> (target :?> DoubleTransition).Delay) (fun target value ->
            (target :?> DoubleTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "DoubleTransition_Easing" (fun target -> (target :?> DoubleTransition).Easing) (fun target value ->
            (target :?> DoubleTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "DoubleTransition_Property" (fun target -> (target :?> DoubleTransition).Property) (fun target value ->
            (target :?> DoubleTransition).Property <- value)

[<AutoOpen>]
module DoubleTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member DoubleTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IDoubleTransition>(
                DoubleTransition.WidgetKey,
                DoubleTransition.Property.WithValue(property),
                DoubleTransition.Duration.WithValue(duration)
            )

[<Extension>]
type DoubleTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IDoubleTransition>, value: TimeSpan) =
        this.AddScalar(DoubleTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IDoubleTransition>, value: Easing) =
        this.AddScalar(DoubleTransition.Easing.WithValue(value))

type IFabBoxShadowsTransition =
    inherit IFabTransition

module BoxShadowsTransition =

    let WidgetKey = Widgets.register<BoxShadowsTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "BoxShadowsTransition_Duration" (fun target -> (target :?> BoxShadowsTransition).Duration) (fun target value ->
            (target :?> BoxShadowsTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "BoxShadowsTransition_Delay" (fun target -> (target :?> BoxShadowsTransition).Delay) (fun target value ->
            (target :?> BoxShadowsTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "BoxShadowsTransition_Easing" (fun target -> (target :?> BoxShadowsTransition).Easing) (fun target value ->
            (target :?> BoxShadowsTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "BoxShadowsTransition_Property" (fun target -> (target :?> BoxShadowsTransition).Property) (fun target value ->
            (target :?> BoxShadowsTransition).Property <- value)


[<AutoOpen>]
module BoxShadowsTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member BoxShadowsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabBoxShadowsTransition>(
                BoxShadowsTransition.WidgetKey,
                BoxShadowsTransition.Property.WithValue(property),
                BoxShadowsTransition.Duration.WithValue(duration)
            )

[<Extension>]
type BoxShadowsTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabBoxShadowsTransition>, value: TimeSpan) =
        this.AddScalar(BoxShadowsTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabBoxShadowsTransition>, value: Easing) =
        this.AddScalar(BoxShadowsTransition.Easing.WithValue(value))


type IFabBrushTransition =
    inherit IFabTransition

module BrushTransition =

    let WidgetKey = Widgets.register<BrushTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "BrushTransition_Duration" (fun target -> (target :?> BrushTransition).Duration) (fun target value ->
            (target :?> BrushTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "BrushTransition_Delay" (fun target -> (target :?> BrushTransition).Delay) (fun target value ->
            (target :?> BrushTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "BrushTransition_Easing" (fun target -> (target :?> BrushTransition).Easing) (fun target value ->
            (target :?> BrushTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "BrushTransition_Property" (fun target -> (target :?> BrushTransition).Property) (fun target value ->
            (target :?> BrushTransition).Property <- value)

[<AutoOpen>]
module BrushTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member BrushTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabBrushTransition>(
                BrushTransition.WidgetKey,
                BrushTransition.Property.WithValue(property),
                BrushTransition.Duration.WithValue(duration)
            )

[<Extension>]
type BrushTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabBrushTransition>, value: TimeSpan) =
        this.AddScalar(BrushTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabBrushTransition>, value: Easing) =
        this.AddScalar(BrushTransition.Easing.WithValue(value))

type IFabColorTransition =
    inherit IFabTransition

module ColorTransition =
    let WidgetKey = Widgets.register<ColorTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "ColorTransition_Duration" (fun target -> (target :?> ColorTransition).Duration) (fun target value ->
            (target :?> ColorTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "ColorTransition_Delay" (fun target -> (target :?> ColorTransition).Delay) (fun target value ->
            (target :?> ColorTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "ColorTransition_Easing" (fun target -> (target :?> ColorTransition).Easing) (fun target value ->
            (target :?> ColorTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "ColorTransition_Property" (fun target -> (target :?> ColorTransition).Property) (fun target value ->
            (target :?> ColorTransition).Property <- value)

[<AutoOpen>]
module ColorTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member ColorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabColorTransition>(
                ColorTransition.WidgetKey,
                ColorTransition.Property.WithValue(property),
                ColorTransition.Duration.WithValue(duration)
            )

[<Extension>]
type ColorTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabColorTransition>, value: TimeSpan) =
        this.AddScalar(ColorTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabColorTransition>, value: Easing) =
        this.AddScalar(ColorTransition.Easing.WithValue(value))

type IFabCornerRadiusTransition =
    inherit IFabTransition

module CornerRadiusTransition =

    let WidgetKey = Widgets.register<CornerRadiusTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "CornerRadiusTransition_Duration" (fun target -> (target :?> CornerRadiusTransition).Duration) (fun target value ->
            (target :?> CornerRadiusTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "CornerRadiusTransition_Delay" (fun target -> (target :?> CornerRadiusTransition).Delay) (fun target value ->
            (target :?> CornerRadiusTransition).Delay <- value)


    let Easing =
        Attributes.definePropertyWithGetSet "CornerRadiusTransition_Easing" (fun target -> (target :?> CornerRadiusTransition).Easing) (fun target value ->
            (target :?> CornerRadiusTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "CornerRadiusTransition_Property" (fun target -> (target :?> CornerRadiusTransition).Property) (fun target value ->
            (target :?> CornerRadiusTransition).Property <- value)

[<AutoOpen>]
module CornerRadiusTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member CornerRadiusTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabCornerRadiusTransition>(
                CornerRadiusTransition.WidgetKey,
                CornerRadiusTransition.Property.WithValue(property),
                CornerRadiusTransition.Duration.WithValue(duration)
            )

[<Extension>]
type CornerRadiusTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabCornerRadiusTransition>, value: TimeSpan) =
        this.AddScalar(CornerRadiusTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabCornerRadiusTransition>, value: Easing) =
        this.AddScalar(CornerRadiusTransition.Easing.WithValue(value))

type IFabFloatTransition =
    inherit IFabTransition

module FloatTransition =
    let WidgetKey = Widgets.register<FloatTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "FloatTransition_Duration" (fun target -> (target :?> FloatTransition).Duration) (fun target value ->
            (target :?> FloatTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "FloatTransition_Delay" (fun target -> (target :?> FloatTransition).Delay) (fun target value ->
            (target :?> FloatTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "FloatTransition_Easing" (fun target -> (target :?> FloatTransition).Easing) (fun target value ->
            (target :?> FloatTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "FloatTransition_Property" (fun target -> (target :?> FloatTransition).Property) (fun target value ->
            (target :?> FloatTransition).Property <- value)

[<AutoOpen>]
module FloatTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member FloatTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabFloatTransition>(
                FloatTransition.WidgetKey,
                FloatTransition.Property.WithValue(property),
                FloatTransition.Duration.WithValue(duration)
            )

[<Extension>]
type FloatTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabFloatTransition>, value: TimeSpan) =
        this.AddScalar(FloatTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabFloatTransition>, value: Easing) =
        this.AddScalar(FloatTransition.Easing.WithValue(value))

type IFabIntegerTransition =
    inherit IFabTransition

module IntegerTransition =
    let WidgetKey = Widgets.register<IntegerTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "IntegerTransition_Duration" (fun target -> (target :?> IntegerTransition).Duration) (fun target value ->
            (target :?> IntegerTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "IntegerTransition_Delay" (fun target -> (target :?> IntegerTransition).Delay) (fun target value ->
            (target :?> IntegerTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "IntegerTransition_Easing" (fun target -> (target :?> IntegerTransition).Easing) (fun target value ->
            (target :?> IntegerTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "IntegerTransition_Property" (fun target -> (target :?> IntegerTransition).Property) (fun target value ->
            (target :?> IntegerTransition).Property <- value)

[<AutoOpen>]
module IntegerTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member IntegerTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabIntegerTransition>(
                IntegerTransition.WidgetKey,
                IntegerTransition.Property.WithValue(property),
                IntegerTransition.Duration.WithValue(duration)
            )

[<Extension>]
type IntegerTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabIntegerTransition>, value: TimeSpan) =
        this.AddScalar(IntegerTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabIntegerTransition>, value: Easing) =
        this.AddScalar(IntegerTransition.Easing.WithValue(value))

type IFabPointTransition =
    inherit IFabTransition

module PointTransition =

    let WidgetKey = Widgets.register<PointTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "PointTransition_Duration" (fun target -> (target :?> PointTransition).Duration) (fun target value ->
            (target :?> PointTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "PointTransition_Delay" (fun target -> (target :?> PointTransition).Delay) (fun target value ->
            (target :?> PointTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "PointTransition_Easing" (fun target -> (target :?> PointTransition).Easing) (fun target value ->
            (target :?> PointTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "PointTransition_Property" (fun target -> (target :?> PointTransition).Property) (fun target value ->
            (target :?> PointTransition).Property <- value)

[<AutoOpen>]
module PointTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member PointTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabPointTransition>(
                PointTransition.WidgetKey,
                PointTransition.Property.WithValue(property),
                PointTransition.Duration.WithValue(duration)
            )

[<Extension>]
type PointTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabPointTransition>, value: TimeSpan) =
        this.AddScalar(PointTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabPointTransition>, value: Easing) =
        this.AddScalar(PointTransition.Easing.WithValue(value))

type IFabSizeTransition =
    inherit IFabTransition

module SizeTransition =

    let WidgetKey = Widgets.register<SizeTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "SizeTransition_Duration" (fun target -> (target :?> SizeTransition).Duration) (fun target value ->
            (target :?> SizeTransition).Duration <- value)


    let Delay =
        Attributes.definePropertyWithGetSet "SizeTransition_Delay" (fun target -> (target :?> SizeTransition).Delay) (fun target value ->
            (target :?> SizeTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "SizeTransition_Easing" (fun target -> (target :?> SizeTransition).Easing) (fun target value ->
            (target :?> SizeTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "SizeTransition_Property" (fun target -> (target :?> SizeTransition).Property) (fun target value ->
            (target :?> SizeTransition).Property <- value)

[<AutoOpen>]
module SizeTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member SizeTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabSizeTransition>(
                SizeTransition.WidgetKey,
                SizeTransition.Property.WithValue(property),
                SizeTransition.Duration.WithValue(duration)
            )

[<Extension>]
type SizeTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabSizeTransition>, value: TimeSpan) =
        this.AddScalar(SizeTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabSizeTransition>, value: Easing) =
        this.AddScalar(SizeTransition.Easing.WithValue(value))

type IFabThicknessTransition =
    inherit IFabTransition

module ThicknessTransition =

    let WidgetKey = Widgets.register<ThicknessTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet "ThicknessTransition_Duration" (fun target -> (target :?> ThicknessTransition).Duration) (fun target value ->
            (target :?> ThicknessTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet "ThicknessTransition_Delay" (fun target -> (target :?> ThicknessTransition).Delay) (fun target value ->
            (target :?> ThicknessTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet "ThicknessTransition_Easing" (fun target -> (target :?> ThicknessTransition).Easing) (fun target value ->
            (target :?> ThicknessTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet "ThicknessTransition_Property" (fun target -> (target :?> ThicknessTransition).Property) (fun target value ->
            (target :?> ThicknessTransition).Property <- value)

[<AutoOpen>]
module ThicknessTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member ThicknessTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabThicknessTransition>(
                ThicknessTransition.WidgetKey,
                ThicknessTransition.Property.WithValue(property),
                ThicknessTransition.Duration.WithValue(duration)
            )

[<Extension>]
type ThicknessTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabThicknessTransition>, value: TimeSpan) =
        this.AddScalar(ThicknessTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabThicknessTransition>, value: Easing) =
        this.AddScalar(ThicknessTransition.Easing.WithValue(value))

type IFabTransformOperationsTransition =
    inherit IFabTransition

module TransformOperationsTransition =

    let WidgetKey = Widgets.register<TransformOperationsTransition>()

    let Duration =
        Attributes.definePropertyWithGetSet
            "TransformOperationsTransition_Duration"
            (fun target -> (target :?> TransformOperationsTransition).Duration)
            (fun target value -> (target :?> TransformOperationsTransition).Duration <- value)

    let Delay =
        Attributes.definePropertyWithGetSet
            "TransformOperationsTransition_Delay"
            (fun target -> (target :?> TransformOperationsTransition).Delay)
            (fun target value -> (target :?> TransformOperationsTransition).Delay <- value)

    let Easing =
        Attributes.definePropertyWithGetSet
            "TransformOperationsTransition_Easing"
            (fun target -> (target :?> TransformOperationsTransition).Easing)
            (fun target value -> (target :?> TransformOperationsTransition).Easing <- value)

    let Property =
        Attributes.definePropertyWithGetSet
            "TransformOperationsTransition_Property"
            (fun target -> (target :?> TransformOperationsTransition).Property)
            (fun target value -> (target :?> TransformOperationsTransition).Property <- value)

[<AutoOpen>]
module TransformOperationsTransitionBuilders =

    type Fabulous.Avalonia.View with

        static member TransformOperationsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabTransformOperationsTransition>(
                TransformOperationsTransition.WidgetKey,
                TransformOperationsTransition.Property.WithValue(property),
                TransformOperationsTransition.Duration.WithValue(duration)
            )

[<Extension>]
type TransformOperationsTransitionModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabTransformOperationsTransition>, value: TimeSpan) =
        this.AddScalar(TransformOperationsTransition.Delay.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabTransformOperationsTransition>, value: Easing) =
        this.AddScalar(TransformOperationsTransition.Easing.WithValue(value))
