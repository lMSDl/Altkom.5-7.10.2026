namespace PlayerApp
{
    internal static class Player
    {
        public static void PlayMedia(IPlayable media)
        {
            media.Play();
            media.Pause();
        }
    }
}
