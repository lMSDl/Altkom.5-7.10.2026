namespace PlayerApp
{
    internal class Podcast : MediaItem
    {
        public int EpisodeNumber { get; }
        public Podcast(string title, int episodeNumber, int durationInSeconds) : base(title, durationInSeconds)
        {
            EpisodeNumber = episodeNumber;
        }

        public override void Play()
        {
            Console.WriteLine($"Playing podcast: {Title} Episode {EpisodeNumber} ({DurationInSeconds} seconds)");
        }
    }
}
