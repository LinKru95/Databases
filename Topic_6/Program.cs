using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Topic_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var playlistCollection = client.GetDatabase("Playlists").GetCollection<Playlist>("UsersPlaylists");

            // INSERT

            var playlist = new Playlist("Linas");
            var songs = new List<Song>
                {
                    new Song
                    {
                        SongName = "Highway to Hell",
                        Author = "author"
                    }
                };

            playlist.Items = songs;

            playlistCollection.InsertOne(playlist);

            //SELECT

            //var filter = Builders<Playlist>.Filter.Eq("Username", "Linas");
            //var results = playlistCollection.Find(filter).ToList();

            //DELETE

            //var filter = Builders<Playlist>.Filter.Eq("Username", "Linas");

            //playlistCollection.DeleteOne(filter);

            //UPDATE

            //var filter = Builders<Playlist>.Filter.Eq("Username", "Linas");
            //var update = Builders<Playlist>.Update.AddToSet<string>("Items", "Song1");

            //playlistCollection.UpdateMany(filter, update);

        }
    }
}
