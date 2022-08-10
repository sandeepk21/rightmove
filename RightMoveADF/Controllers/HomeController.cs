using Microsoft.AspNetCore.Mvc;
using RightMoveADF.API;
using RightMoveADF.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace RightMoveADF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;
      
        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            //string password=EncryptionModel.Encrypt("rightmove@123");
            return View();
        }
        public ActionResult UserList()
        {
            return View();
        }

        public IActionResult Register()
        {
            //string password=EncryptionModel.Encrypt("rightmove@123");
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            //string password=EncryptionModel.Encrypt("rightmove@123");
            return View();
        }


        public IActionResult ChangePassword()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [HttpPost]
        public IActionResult ChangePassword(string toMail)
        {
            try
            {
                string host = this.Configuration.GetValue<string>("Smtp:Server");
                int port = this.Configuration.GetValue<int>("Smtp:Port");
                string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
                string userName = this.Configuration.GetValue<string>("Smtp:UserName");
                string password = this.Configuration.GetValue<string>("Smtp:Password");

                using (MailMessage mm = new MailMessage(fromAddress, toMail))
                {
                    mm.Subject ="Password Changed";
                    
                    mm.Body = "Your password is==>";

                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = host;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = port;
                        smtp.Send(mm);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json("");
        }

        public IActionResult ForgotPassword()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult ForgetPassword(string EmailAddress)
        {
            string host = this.Configuration.GetValue<string>("Smtp:Server");
            int port = this.Configuration.GetValue<int>("Smtp:Port");
            string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
            string userName = this.Configuration.GetValue<string>("Smtp:UserName");
            string password = this.Configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, EmailAddress))
            {
                mm.Subject = "Password Changed";

                mm.Body = "Your password is==>";

                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(mm);
                }
            }
            return Json("");
        }

        //[SwaggerOperation(Summary = "Getting some information of logged in user to display on dashboard")]
        //[Route("GetLoggedInUserDetail/{userEmail}")]
        //public ResponceData GetLoggedInUserDetail(string userEmail)
        //{
        //    ResponceData responce = new ResponceData();
        //    try
        //    {
        //        List<dynamic> result = new List<dynamic>();
        //        using (var context = new CoreDbContext())
        //        {
        //            var dbResult = context.UserLogins.Where(x=>x.UserId==userEmail.ToString()).ToList();
        //            foreach (var item in dbResult)
        //            {
        //                result.Add(new { UserEmail = item.UserId });
        //            }
        //        }
        //        responce.Entity = result.ToList();
        //        responce.StatusCode = 200;
        //        responce.Message = "Ok";
        //    }
        //    catch (Exception ex)
        //    {
        //        responce.Entity = string.Empty;
        //        responce.StatusCode = ex.InnerException == null ? 400 : ex.InnerException.HResult;
        //        responce.Message = ex.Message;
        //        throw;
        //    }

        //    return responce;
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}