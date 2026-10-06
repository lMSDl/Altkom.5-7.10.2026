using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerApp
{
    internal class Podcast : IPlayable
    {
        public string Title { get; }
        public int EpisodeNumber { get; }
        public Podcast(string title, int episodeNumber)
        {
            Title = title;
            EpisodeNumber = episodeNumber;
        }
        public void Pause()
        {
            Console.WriteLine($"Pausing podcast: {Title} Episode {EpisodeNumber}");
        }
        public void Play()
        {
            Console.WriteLine($"Playing podcast: {Title} Episode {EpisodeNumber}");
        }
    }
}
