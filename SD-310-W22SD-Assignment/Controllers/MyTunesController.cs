using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_310_W22SD_Assignment.Models;
using SD_310_W22SD_Assignment.Models.ViewModels;

namespace SD_310_W22SD_Assignment.Controllers
{
    public class MyTunesController : Controller
    {
        private MyTunesMichaelContext _db { get; set; }
        public MyTunesController(MyTunesMichaelContext context)
        {
            _db = context;
        }
        public IActionResult SongsUsers()
        {
            return View(_db.Songs.Include(u => u.Users));
        }
        public IActionResult SelectUser()
        {
            UserSelectViewModel userselect = new UserSelectViewModel(_db.Users.Include(u => u.Songs).ToList(),
                _db.Songs.ToList());
            return View(userselect);
        }
        public IActionResult Songs(int? userId)
        {
            if(userId != null)
            {
                try
                {
                    List<Song> songs = _db.Songs.Where(s => s.UserId == userId).Include(s => s.Artist).ToList();
                    UserSelectViewModel userselect = new UserSelectViewModel(_db.Users.
                        Include(u => u.Songs).ThenInclude(s => s.Artist).ToList(),
                        songs);
                    userselect.Selected = true;
                    userselect.Artists = new List<Artist>();
                    
                    foreach(User user in userselect.Users)
                    {
                        if(user.Id == userId)
                        {
                            userselect.SelectedUser = user;
                        }
                    }
                    return View("SelectUser", userselect);
                }
                catch
                {
                    return View("Index", "Home");
                }
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public IActionResult SelectUserToAddSongs()
        {
            UserSelectViewModel userselect = new UserSelectViewModel(_db.Users.ToList(),
                _db.Songs.Include(s => s.Artist).ToList());
            return View(userselect);
        }

        public IActionResult AllSongs(int? userId)
        {
            if (userId != null)
            {
                try
                {
                    UserSelectViewModel userselect = new UserSelectViewModel(_db.Users.
                        Include(u => u.Songs).ToList(),
                        _db.Songs.Include(s => s.Artist).ToList());
                    userselect.Selected = true;
                    foreach (User user in _db.Users)
                    {
                        if (user.Id == userId)
                        {
                            userselect.SelectedUser = user;
                        }
                    }
                    return View("SelectUserToAddSongs", userselect);
                }
                catch
                {
                    return View("Index", "Home");
                }
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public IActionResult AddToCollection(int userId, int songId)
        {
            Song selectedSong = new Song();
            foreach(Song song in _db.Songs)
            {
                if(song.Id == songId)
                {
                    selectedSong = song;
                }
            }
            foreach(User user in _db.Users)
            {
                if(user.Id == userId)
                {
                    user.Songs.Add(selectedSong);
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Songs", new { userId = userId});
        }

        public IActionResult SelectArtist()
        {
            ArtistSelectViewModel artistselect = new ArtistSelectViewModel(_db.Artists.ToList(),
                _db.Songs.ToList());
            return View(artistselect);
        }

        public IActionResult Artists()
        {
            return View(_db.Artists.ToList());
        }
    }
}
