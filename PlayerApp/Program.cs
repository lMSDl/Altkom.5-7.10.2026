

using PlayerApp;

IEnumerable<IPlayable> mediaCollection =
[
    new Song("Shape of You", "Ed Sheeran"),
    new Podcast("The Daily", 123),
    new Song("Blinding Lights", "The Weeknd"),
    new Podcast("Science Vs", 45)
];

foreach (var media in mediaCollection)
{
    Player.PlayMedia(media);
}