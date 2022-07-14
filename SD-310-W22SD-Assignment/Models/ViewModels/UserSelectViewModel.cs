using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD_310_W22SD_Assignment.Models.ViewModels
{
    public class UserSelectViewModel
    {
        public List<SelectListItem> UserSelectItems { get; set; }
        public List<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public bool Selected { get; set; } = false;
        public UserSelectViewModel(List<User> users, List<Song> songs)
        {
            Users = users;

            UserSelectItems = new List<SelectListItem>();
            Users.ForEach(u =>
            {
                UserSelectItems.Add(new SelectListItem(u.UserName, u.Id.ToString()));
            });

            Songs = songs;
        }
    }
}
