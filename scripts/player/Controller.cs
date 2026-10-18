using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using Arhythmetic.scripts.Data;
using Arhythmetic.scripts.Types;

public partial class Controller : Node2D
{
	private const bool DEV = true;
	
	public double Score;
	public static double Time;
	public SongData SongData;
	public AudioStreamPlayer AudioStream;
	public Label ScoreLabel;
	public Label AccuracyLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (DEV) SongData = new Levels().SampleSong;
		
		AudioStream = GetNode<AudioStreamPlayer>("Song");
		ScoreLabel = GetNode<Label>("Score");
		AccuracyLabel = GetNode<Label>("Accuracy");
		
		Time = 0;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Time += delta;

		ScoreLabel.SetText($"{Score}");
		AccuracyLabel.SetText("accuracy would go here");
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is not InputEventKey) return;
		
		if (new[] {"A", "S", "D", "F", "J", "K", "L", "Semicolon"}.Contains(@event.AsText()))
		{
			// GetNode<Button>($"Button_{@event.AsText()}").ButtonPressed = @event.IsPressed();

			if (@event.IsPressed())
			{
				
				
				GD.Print($"{@event.AsText()} Pressed");
			}
		}
	}

	List<NoteEvent> GetCurrentEvents()
	{
		List<NoteEvent> currentEvents = new List<NoteEvent>();
		foreach (NoteEvent noteEvent in SongData.events)
		{
			if (Mathf.Abs(noteEvent.beat - TimeToBeat(Time, SongData.bpm)) < 0.1f )
			{
				currentEvents.Add(noteEvent);
			}
		}
		return currentEvents;
	}

	public void StartAudio()
	{
		
	}
	
	public float TimeToBeat(double time, float bpm) => bpm / 60 * (float)time;
	public int FormatBeat(float beat) => (int)(beat % SongData.timeSignature[0]);
	public int FormatMeasure(float beat) => (int)Math.Floor(beat / SongData.timeSignature[0]);
}
