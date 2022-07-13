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
        public IActionResult Index()
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
                    List<Song> songs = _db.Songs.Where(s => s.UserId == userId).ToList();
                    return View(songs);
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

        public IActionResult Artists()
        {
            return View(_db.Artists.ToList());
        }
    }
}
