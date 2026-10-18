using Arhythmetic.scripts.Types;

namespace Arhythmetic.scripts.Data;

public class Levels
{
    public SongData SampleSong = new()
    {
        title = "Sample Song",
        author = "benmu",
        songName = "Sample Song",
        songArtist = "benmu",
        bpm = 120f,
        timeSignature = new int[] { 4, 4 },
        events = new()
        {
            new NoteEvent { beat = 1f, note = 63 },
            new NoteEvent { beat = 1f, note = 64 },
        }
    };
}