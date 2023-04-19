using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModel;
using System.Drawing;
using System.Text.Json;
using X.PagedList;

namespace prjMvcCoreDemo.Controllers
{
    
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page, CQueryKeywordViewModel vm)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            //dbDemoContext db = new dbDemoContext();
            //IQueryable<Post> datas = null; // 使用 IQueryable 而不是 IEnumerable
            //if (string.IsNullOrEmpty(vm.txtKeyword))
            //{
            //    datas = from p in db.Posts
            //            select p;
            //}
            //else
            //{
            //    datas = db.Posts.Where(p => p.tContent.Contains(vm.txtKeyword));
            //}

            return View(await _context.posts.ToPagedListAsync(pageNumber, pageSize)); // 使用 datas 而不是 _context.posts
        }


        public IActionResult Create()
        {
  
            var member =HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            var memberid = JsonSerializer.Deserialize<TCustomer>(member);
            ViewBag.ID=memberid.Fid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PostID,UserID,Title,tContent,CreatedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {                
                post.CreatedAt = DateTime.Now;
                post.tContent = post.tContent.Replace("\n", "<br>");
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
    }
}
