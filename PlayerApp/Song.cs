namespace PlayerApp
{
    internal class Song : IPlayable
    {
        public string Title { get; }
        public string Artist { get; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public void Pause()
        {
            Console.WriteLine($"Pausing song: {Title} by {Artist}");
        }

        public void Play()
        {
            Console.WriteLine($"Playing song: {Title} by {Artist}");
        }
    }
}
