using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerApp
{
    internal abstract class MediaItem : IPlayable
    {
        public string Title { get; }
        public int DurationInSeconds { get; }

        public MediaItem(string title, int durationInSeconds)
        {
            Title = title;
            DurationInSeconds = durationInSeconds;
        }

        public abstract void Play();
        public virtual void Pause()
        {
            Console.WriteLine($"Pausing media item: {Title} ({DurationInSeconds} seconds)");
        }
    }
}
