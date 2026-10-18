using System.Collections.Generic;

namespace Arhythmetic.scripts.Types;

public class SongData
{
    public string title;
    public string author;
    public string songName;
    public string songArtist;
    public float bpm;
    public int[] timeSignature; // [numerator, denominator]
    public List<NoteEvent> events;
}

public class NoteEvent
{
    public float beat;
    public int note;
    public float duration = 0f;
}