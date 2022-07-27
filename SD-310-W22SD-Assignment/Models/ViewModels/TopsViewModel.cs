using System.Linq;

namespace SD_310_W22SD_Assignment.Models.ViewModels
{
    public class TopsViewModel
    {
        public List<Artist> TopSellingArtists { get; set; }
        public List<Song> TopSellingSongs { get; set; }
        public int? SongSales { get; set; }
        public TopsViewModel(List<Artist> artists, List<Song> songs)
        {
            TopSellingArtists = artists.ToList();
            TopSellingSongs = songs.ToList();
            SongSales = 0;
            foreach(Song song in TopSellingSongs)
            {
                SongSales += song.Sales;
            }

        }
    }
}