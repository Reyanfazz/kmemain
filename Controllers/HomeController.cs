
using kme.Models;
using kme.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using kme.Models.Topics;
using System.Runtime.CompilerServices;

namespace kme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserContext _userdb;
        IWebHostEnvironment _hostEnvironment;
        TopicContext _topicContext;
        

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment hc, TopicContext tc)
        {
            _logger = logger;
            _configuration = configuration;
            _userdb = new UserContext();
            _hostEnvironment = hc;
            _topicContext = tc;
     

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult loggedin()
        {

            string username = HttpContext.Session.GetString("username");

            ViewBag.Username = username;
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _userdb.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    //_user.Password = GetMD5(_user.Password);
                    // _userdb.Configuration.ValidateOnSaveEnabled = false;

                    _userdb.Users.Add(_user);
                    _userdb.SaveChanges();


                    /* if (file != null && file.Length > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "docu", "image", filename);
                        using (var stream = new FileStream(imgpath, FileMode.Create))
                        {
                            file.CopyToAsync(stream);
                        }
                        _user.Uimg = "~/docu/image/" + filename;
                    }*/

                    using (var context = new UserContext())
                    {
                        context.Database.EnsureCreated();

                        UserRepository userRepository = new UserRepository(context);

                        // Add a user
                        // User newUser = new User { Username = "john_doe", Email = "john.doe@example.com" };
                        // userRepository.AddUser(newUser);

                        // Retrieve a user by ID
                        User? retrievedUser = userRepository.GetUserByEmail(_user.Email);
                        if (retrievedUser != null)
                        {
                            string username = retrievedUser.UserName;
                            ViewData["Uname"] = username;
                            HttpContext.Session.SetString("username", username);
                            return RedirectToAction("Loggedin", "Home");

                            //Console.WriteLine($"User ID: {retrievedUser.Id}, Username: {retrievedUser.UserName}, Email: {retrievedUser.Email}");
                        }
                        else
                        {
                            ViewData["message"] = "Username & Password are wrong!";
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }

            }

            return View();
        }
        public IActionResult Search()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel lc)
        {
            using (var context = new UserContext())
            {
                context.Database.EnsureCreated();

                UserRepository userRepository = new UserRepository(context);

                // Add a user
               // User newUser = new User { Username = "john_doe", Email = "john.doe@example.com" };
               // userRepository.AddUser(newUser);

                // Retrieve a user by ID
                User? retrievedUser = userRepository.GetUserByEmail(lc.Email);
                if (retrievedUser != null)
                {
                           string username = retrievedUser.UserName;
                           ViewData["Uname"] = username;
                           HttpContext.Session.SetString("username", username);
                        return RedirectToAction("Loggedin", "Home");

                    //Console.WriteLine($"User ID: {retrievedUser.Id}, Username: {retrievedUser.UserName}, Email: {retrievedUser.Email}");
                }
                else
                {
                    ViewData["message"] = "Username & Password are wrong!";
                    return View();
                }

         
        }



   // string mainconn = _configuration.GetConnectionString("KmeCnn");

            //using (SqlConnection sqlconn = new SqlConnection(mainconn))
            //{
            //    string sqlquery = "SELECT Uimg, Email, Password FROM [dbo].[Users] WHERE Email=@Email AND Password=@Password";
            //    sqlconn.Open();

            //    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
            //    {
            //        sqlcomm.Parameters.AddWithValue("@Email", lc.Email);
            //        sqlcomm.Parameters.AddWithValue("@Password", lc.Password);

            //        using (SqlDataReader sdr = sqlcomm.ExecuteReader())
            //        {
            //            if (sdr.Read())
            //            {
            //                string s = sdr["Uimg"].ToString();
            //                ViewData["Img"] = s;
            //                HttpContext.Session.SetString("emailid", lc.Email);
            //                return RedirectToAction("Index", "Home");
            //            }
            //            else
            //            {
            //                ViewData["message"] = "Username & Password are wrong!";
            //            }
            //        }
            //    }
            //}

            return View();
        }
        [HttpGet]
        public IActionResult AdminPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminPage(TopicsModel tc)
        {
            string Image = "";

            if(tc.Timg!=null)
            {
                string uploadfolder = Path.Combine("wwwroot", "uploads");
                Image = tc.Timg.FileName;
                string filePath = Path.Combine(uploadfolder, Image);
                tc.Timg.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            string Ebook = "";

            if (tc.EbookFileld != null)
            {
                string uploadfolder = Path.Combine("wwwroot", "uploads");
                Ebook =tc.EbookFileld.FileName;
                string filePath = Path.Combine(uploadfolder, Ebook);
                tc.EbookFileld.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            string Video = "";

            if (tc.Yvideo != null)
            {
                string uploadfolder = Path.Combine("wwwroot", "uploads"); 
                Video =  tc.Yvideo.FileName;
                string filePath = Path.Combine(uploadfolder, Video);
                tc.Yvideo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            string Audio = "";

            if (tc.AudioFileId != null)
            {
                string uploadfolder = Path.Combine("wwwroot", "uploads");
                Audio = tc.AudioFileId.FileName;  // Use Path.Combine for proper path concatenation
                string filePath = Path.Combine(uploadfolder, Audio);
                tc.AudioFileId.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Topic tp = new Topic
            {
                Name = tc.Name,
                EbookId = tc.EbookId,
                Timg = Image,
                //EbookName=,
                EbookFileld = Ebook,
                AudioFileId = Audio,
                // AudioName=,
                Yvideo = Video,
                TotalEbookParts = tc.TotalEbookParts,
                TotalAudioFiles = tc.TotalAudioFiles,
                EbCategory = tc.EbCategory,

            };

            _topicContext.Topics.Add(tp);
            _topicContext.SaveChanges();
            ViewBag.success = "Record Added";
            return View();
        }


        public IActionResult Adminloggin()
        {
            return View();
        }
        public IActionResult Topics()
        {
            return View();
        }

        public IActionResult TopicsGuest()
        {
            return View();
        }

        public IActionResult TopicsUser()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Paymentplans()
        {
            return View();
        }

        public IActionResult Docupages()
        {
            return View();
        }

        public IActionResult CategoryPage()
        {
            return View();
        }

        //Logout
        public ActionResult Logout()
    {
    //Session.Clear();//remove session
    return RedirectToAction("Login");
      }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}