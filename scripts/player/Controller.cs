using Godot;
using System;
using System.Linq;
using Arhythmetic.scripts.Types;

public partial class Controller : Node2D
{
	public static double Time;
	public SongData SongData;
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is not InputEventKey) return;
		
		if (new[] {"A", "S", "D", "F", "J", "K", "L", ";"}.Contains(@event.AsText()))
		{
			// GetNode<Button>($"Button_{@event.AsText()}").ButtonPressed = @event.IsPressed();

			if (@event.IsPressed())
			{
				GD.Print($"{@event.AsText()} Pressed");
			}
		}
	}

	public void StartAudio()
	{
		
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Time = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Time += delta;
	}

	public int GetBeat() => (int)Math.Floor(SongData.bpm / 60 * Time);
	public int FormatBeat() => GetBeat() % SongData.timeSignature[0];
	public int FormatMeasure() => (int)Math.Floor((double)(GetBeat() / SongData.timeSignature[0]));
}
