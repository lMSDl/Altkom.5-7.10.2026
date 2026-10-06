namespace PlayerApp
{
    internal class Song : MediaItem
    {
        
        public string Artist { get; }

        public Song(string title, string artist, int durationInSeconds) : base(title, durationInSeconds)
        {
            Artist = artist;
        }

        public override void Pause()
        {
            Console.WriteLine($"Pausing song: {Title} by {Artist} ({DurationInSeconds} seconds)");
        }

        public override void Play()
        {
            Console.WriteLine($"Playing song: {Title} by {Artist} ({DurationInSeconds} seconds)");
        }
    }
}
