using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerApp
{
    internal class Playlist
    {
        private ICollection<IPlayable> _mediaItems;

        public Playlist()
        {
            _mediaItems = [];
        } 

        public void Add(IPlayable mediaItem)
        {
            _mediaItems.Add(mediaItem);
        }

        public void PlayAll()
        {
            foreach (var mediaItem in _mediaItems)
            {
                mediaItem.Play();
                mediaItem.Pause();
            }
        }
    }
}
