using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Song
{
    public const int MinNameLenght = 3;
    public const int MaxArtistNameLenght = 20;
    public const int MaxSongNameLenght = 30;
    public const int MinSongLenght = 0;
    public const int MaxMinutesLenght = 14;
    public const int MaxSecondsLenght = 59;

    private string artistName;

    public string ArtistName
    {
        get { return artistName; }
        private set
        {
            if (value?.Length < MinNameLenght || value.Length > MaxArtistNameLenght)
            {
                throw new InvalidArtistNameException();
            }
            artistName = value;
        }
    }

    private string songName;

    public string SongName
    {
        get { return songName; }
        private set
        {
            if (value?.Length < MinNameLenght || value?.Length > MaxSongNameLenght)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }


    private string lenght;

    public string Lenght
    {
        get { return lenght; }
        private set
        {
            Regex pattern = new Regex(@"^\d+:\d+");

            if (!pattern.IsMatch(value))
            {
                throw new InvalidSongLengthException();
            }

            int[] timeTokens = value.Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int minutes = timeTokens[0];
            int seconds = timeTokens[1];

            if (minutes < MinSongLenght || minutes > MaxMinutesLenght)
            {
                throw new InvalidSongMinutesException();
            }

            if (seconds < MinSongLenght || seconds > MaxSecondsLenght)
            {
                throw new InvalidSongSecondsException();
            }
            lenght = value;
        }
    }


    public Song(string artistName, string songName, string lenght)
    {
        ArtistName = artistName;
        SongName = songName;
        Lenght = lenght;
    }
}