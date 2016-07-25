using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string artistName, string name, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidSongNameException();
                }

                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.name = value;
            }
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArtistNameException();
                }

                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }

            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }

            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }

    public class InvalidSongException : Exception
    {
        private const string Message = "Invalid song.";

        public InvalidSongException(string message) : base(message)
        {
        }

        public InvalidSongException() : base(Message)
        {
            
        }
    }

    public class InvalidArtistNameException : InvalidSongException
    {
        private const string Message = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException() : base(Message)
        {
        }
    }

    public class InvalidSongNameException : InvalidSongException
    {
        private const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException() : base(Message)
        {
        }
    }

    public class InvalidSongLengthException : InvalidSongException
    {
        private const string Message = "Invalid song length.";

        public InvalidSongLengthException(string message) : base(message)
        {
        }

        public InvalidSongLengthException() : base(Message)
        {
        }
    }

    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException() : base(Message)
        {
        }
    }

    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        private const string Message = "Song minutes should be between 0 and 14.";

        public InvalidSongMinutesException() : base(Message)
        {
        }
    }

    public static class PlayList
    {
        public static List<Song> songs = new List<Song>();

        public static string PlaylistLength()
        {
            long minutes = 0;
            long seconds = 0;

            foreach (var song in songs)
            {
                minutes += song.Minutes;
                seconds += song.Seconds;
            }

            minutes += seconds/60;
            seconds %= 60;
            long hours = minutes/60;
            minutes %= 60;

            return string.Format("Playlist length: {0}h {1}m {2}s",
                hours, minutes, seconds);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(';');
                string artistName = tokens[0];
                string songName = tokens[1];
                string length = tokens[2];

                if (!Regex.IsMatch(length, @"[0-9]+:[0-9]+"))
                {
                    Console.WriteLine("Invalid song length.");
                    continue;
                }

                string[] lengthTokens = length.Split(':');
                int min = int.Parse(lengthTokens[0]);
                int sec = int.Parse(lengthTokens[1]);

                try
                {
                    var song = new Song(artistName, songName, min, sec);
                    PlayList.songs.Add(song);

                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ise)
                {

                    Console.WriteLine(ise.Message);
                }
            }

            Console.WriteLine($"Songs added: {PlayList.songs.Count}");

            Console.WriteLine(PlayList.PlaylistLength());
        }
    }
}
