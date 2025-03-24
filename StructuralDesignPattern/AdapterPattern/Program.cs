using System;

// Step 1: Target Interface
public interface IAudioPlayer
{
    void Play(string audioType, string fileName);
}

// Step 2: Adaptee
public class VlcPlayer
{
    public void PlayVlc(string fileName)
    {
        Console.WriteLine($"Playing VLC file: {fileName}");
    }
}

public class Mp4Player
{
    public void PlayMp4(string fileName)
    {
        Console.WriteLine($"Playing MP4 file: {fileName}");
    }
}

// Step 3: Adapter
public class MediaAdapter : IAudioPlayer
{
    private readonly VlcPlayer _vlcPlayer = new VlcPlayer();
    private readonly Mp4Player _mp4Player = new Mp4Player();

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            _vlcPlayer.PlayVlc(fileName);
        }
        else if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _mp4Player.PlayMp4(fileName);
        }
        else
        {
            Console.WriteLine($"Audio type {audioType} not supported.");
        }
    }
}

// Step 4: Client
class Program
{
    static void Main()
    {
        IAudioPlayer player = new MediaAdapter();

        player.Play("mp3", "song1.mp3");   // Unsupported
        player.Play("vlc", "movie1.vlc"); // Adapted
        player.Play("mp4", "video1.mp4"); // Adapted
    }
}
