using EaseChashProject.DtoLayer.Dtos.AppUserDtos;
using EaseChashProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EaseChashProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if(ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Usurname,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City ="ANKARA",
                    District ="sincan",
                    ImageUrl="www.google.com",
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage(); // mesaj sınıfı oluşturuldu
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("EasyCash Admin", "xjudhko@gmail.com"); // gönderen kişinin adresi ve gönderen kişi
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email); // gönderilecek kişinin mail adresi appuser üzerinden alıyoruz bunu 

                    mimeMessage.From.Add(mailboxAddressFrom); // mimekit ile mesajı gönder 
                    mimeMessage.To.Add(mailboxAddressTo); // mimekit ile mesajı göndereceğimiz kişi

                    var bodyBuilder = new BodyBuilder();// 
                    bodyBuilder.TextBody = "kayıt işlemini tamamlamak için gereken onay kodunuz:" + code; // mail içeriğinde çıkacak bölüm
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "EasyCash Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false); // bağlantı,türkiye kodu, güvenlik açılsın mı
                    client.Authenticate("xjudhko@gmail.com", "fofmpvlmrihbbjgk");
                    client.Send(mimeMessage); // 
                    client.Disconnect(true);

                    TempData["mail"] = appUserRegisterDto.Email;

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
