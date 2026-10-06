

using PlayerApp;

Playlist playlist = new Playlist();
playlist.Add(new Song("Shape of You", "Ed Sheeran", 245));
playlist.Add(new Podcast("The Daily", 123, 3600));
playlist.Add(new Song("Blinding Lights", "The Weeknd", 200));
playlist.Add(new Podcast("Science Vs", 45, 1800));

playlist.PlayAll();