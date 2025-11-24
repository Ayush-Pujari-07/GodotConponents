using Godot;
using System;

/// <summary>
/// A reusable animation component that provides hover effects for Control nodes.
/// Attaches to a Control node as a child and animates its scale property when the mouse enters or exits.
/// </summary>
/// <remarks>
/// This component automatically:
/// - Connects to the parent Control node's mouse signals
/// - Sets the pivot point to center if configured
/// - Animates scale transitions using tweens
/// 
/// Usage: Add this node as a child of any Control node you want to animate on hover.
/// </remarks>
public partial class AnimationComponent : Node
{
	[Export] bool fromCenter = true;
	[Export] Vector2 hoverScale = new(1, 1);
	[Export] float delay = 0.0f;
	[Export] Tween.TransitionType transitionType;

	private Control target;
	private Vector2 defaultScale;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		target = GetParent<Control>();
		ConnectSignals();
		CallDeferred("Setup");
	}

	private void ConnectSignals()
	{
		target.MouseEntered += OnHover;
		target.MouseExited += OffHover;
	}

	private void Setup()
	{
		if (fromCenter)
		{
			target.SetPivotOffset(target.GetSize() / 2);
		}
		defaultScale = target.Scale;
	}

	private void OnHover()
	{
		AddTween("scale", hoverScale, delay);
	}

	private void OffHover()
	{
		AddTween("scale", defaultScale, delay);
	}

	private void AddTween(string property, Variant value, float seconds)
	{
		var tween = GetTree().CreateTween();
		tween.TweenProperty(target, property, value, seconds)
			.SetTrans(transitionType);
	}
}
