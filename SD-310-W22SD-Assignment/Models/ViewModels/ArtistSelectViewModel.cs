using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD_310_W22SD_Assignment.Models.ViewModels
{
    public class ArtistSelectViewModel
    {
            public List<SelectListItem> ArtistSelectItems { get; set; }
            public List<Artist> Artists { get; set; }
            public bool Selected { get; set; } = false;
            public Artist SelectedArtist { get; set; }
            public ArtistSelectViewModel(List<Artist> artists)
            {
                Artists = artists;

                ArtistSelectItems = new List<SelectListItem>();
                Artists.ForEach(a =>
                {
                    ArtistSelectItems.Add(new SelectListItem(a.Name, a.Id.ToString()));
                });
            }
    }
}
