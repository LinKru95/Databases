using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_6
{
    public class Playlist
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; } = null!;
        public List<Song> Items { get; set; } = null!;

        public Playlist(string username)
        {
            Username = username;
            Items = new List<Song>();
        }
    }
}
