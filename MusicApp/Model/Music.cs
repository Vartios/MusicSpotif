using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Model
{
    public class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public string CoverImage { get; set; } = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/821/325x325/versace-1599566427-BsQuqrChev.jpg";
        public bool IsRecent { get; set; }
    }
}
