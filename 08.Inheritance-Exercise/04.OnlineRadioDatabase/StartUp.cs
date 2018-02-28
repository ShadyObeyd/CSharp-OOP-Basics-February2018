using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Song> playlist = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            string[] songTokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (songTokens.Length != 3)
            {
                Console.WriteLine("Invalid song.");
                continue;
            }

            string artistName = songTokens[0];
            string songName = songTokens[1];
            string lenght = songTokens[2];

            try
            {
                Song song = new Song(artistName, songName, lenght);
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        long totalSeconds = 0;

        foreach (Song song in playlist)
        {
            int[] timeTokens = song.Lenght.Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            long songTotalSeconds = (timeTokens[0] * 60) + timeTokens[1];

            totalSeconds += songTotalSeconds;
        }

        TimeSpan t = TimeSpan.FromSeconds(totalSeconds);

        string result = string.Format($"{t.Hours}h {t.Minutes}m {t.Seconds}s");

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {result}");
    }
}