using Apoteka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
using WebApp_Apoteka.ViewModels.Account;

namespace WebApp_Apoteka.Controllers
{
    public class AccountController : Controller
    {
        MojDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,RoleManager<IdentityRole> role ,MojDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            roleManager = role;
            _db = db;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registracija()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            RegistracijaVM model = new RegistracijaVM()
            {
                Opstine = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList(),
                TipKorisnika = _db.tipKorisnika.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList()
            };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registracija(RegistracijaVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.DatumRodjenja.CompareTo(DateTime.Now) >= 0|| model.DatumRodjenja.CompareTo(DateTime.Parse("1900-01-01")) <= 0)
                {
                    ModelState.AddModelError("", "Datum nije uredan");
                    return View(model);
                }

                Korisnik k = new Korisnik()
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    DatumRodjenja = model.DatumRodjenja,
                    OpstinaRodjenjaID = model.OpstinaRodjenjaID,
                    Adresa = model.Adresa,
                    Telefon = model.Telefon,
                    TipKorisnikaID = model.TipKorisnikaID
                };
                _db.Add(k);
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    korisnik = k
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!_signInManager.IsSignedIn(User))
                    {
                        await DodijeliUloguFUnction(new DodijeliUloguVM { nazivUloge = "Korisnik", korisnikID = user.Id });
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    if(model.TwoWayAuth)
                    {
                        return RedirectToAction("ConfirmPhoneNumber",new { brTelefona= k.Telefon,Operacija="Registracija"});
                    }



                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            model.Opstine = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList();
            model.TipKorisnika = _db.tipKorisnika.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList();
            return View(model);
        }
        public async Task<bool> DodijeliUloguFUnction(DodijeliUloguVM model)
        {
            var role = await roleManager.FindByNameAsync(model.nazivUloge);
            if (role == null)
            {
                return false;
            }
            var user = await _userManager.FindByIdAsync(model.korisnikID);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return true;
                //if (role.Name == "Admin")
                //    return RedirectToAction("AddRemoveKorisnikaUlogu", "Administracija", new { UlogaID = role.Id });
                //else
                //    return RedirectToAction("Index", "Home");
            }
            return false;
        }
        public IActionResult ConfirmPhoneNumber(string brTelefona,string Operacija,string userName="")
        {
            ViewBag.Telefon = brTelefona;
            ViewBag.Operacija = Operacija;
            ViewBag.userName = userName;
            return View();
        }

        public IActionResult ConfirmPhoneNumberPost(string brTelefona,string Operacija,string userName)
        {
            string kod="";
            Random rnd = new Random();
            int[] rndnNiz = new int[6];
            for (int i = 0; i < 6; i++)
            {
                rndnNiz[i] = rnd.Next(0, 9);
                kod+= rndnNiz[i].ToString();
            }
            UporediKodZaKonfirmacijuTelefonaVM model = new UporediKodZaKonfirmacijuTelefonaVM()
            {
                GenerisaniKod=kod,
                Operacija=Operacija,
                userName=userName
            };
            TwilioClient.Init("AC7c8efc4e05d92e420e0b9c623425c404", "9e281b938bc10707504a2aba139524e9");
            var mess = MessageResource.Create
                (
                    body: "Vasa kod je: " + kod,
                    from: new Twilio.Types.PhoneNumber("+12183044332"),
                    to: new Twilio.Types.PhoneNumber(brTelefona)
                );
            return View("PotvrdiKod",model);
        }
        public async Task<IActionResult> ProvjeriKod(UporediKodZaKonfirmacijuTelefonaVM model)
        {
            if(ModelState.IsValid)
            {   
                if(model.Operacija=="Registracija")
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    if (user!=null)
                    {
                        await _userManager.SetTwoFactorEnabledAsync(user, true);
                        user.PhoneNumberConfirmed = true;
                        _db.SaveChanges();

                    }
                }
                else if(model.Operacija=="Login")
                {
                    var user = await _userManager.FindByNameAsync(model.userName);
                    if(user!=null)
                    {
                        await _signInManager.SignInAsync(user, true);

                    }
                }
                return RedirectToAction("Index", "Home");              
            }
            
            return View("PotvrdiKod", model);

        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult AddApotekara()
        {
            AddApotekarVM model = new AddApotekarVM()
            {
                MjestoRodjenja = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList()
            };
            return View(model);

        }

        [HttpPost]
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddApotekara(AddApotekarVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.DatumRodjenja.CompareTo(DateTime.Now) >= 0 || model.DatumRodjenja.CompareTo(DateTime.Parse("1900-01-01")) <= 0)
                {
                    ModelState.AddModelError("", "Datum rodjenja nije uredan");
                    return View(model);
                }
                if (model.DatumZaposlenja.CompareTo(DateTime.Now) >= 0 || model.DatumZaposlenja.CompareTo(DateTime.Parse("2010-01-01")) <= 0)
                {
                    ModelState.AddModelError("", "Datum rodjenja nije uredan");
                    return View(model);
                }
                Apotekar a = new Apotekar()
                {
                    Telefon=model.Telefon,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    DatumRodjenja = model.DatumRodjenja,
                    MjestoRodjenjaID = model.MjestoRodjenjaID,
                    JMBG = model.JMBG,
                    DatumZaposlenja = model.DatumZaposlenja,
                };
                _db.Add(a);
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    apotekar = a
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("DodijeliUlogu", "Administracija", new DodijeliUloguVM { nazivUloge = "Apotekar", korisnikID = user.Id });

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            model.MjestoRodjenja = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
               return RedirectToAction("Index", "Home");
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                var result1 = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (await _userManager.GetTwoFactorEnabledAsync(user)&& result1.Succeeded)
                {
                    if(await _userManager.IsInRoleAsync(user,"Korisnik"))
                        return RedirectToAction("ConfirmPhoneNumber",new { brTelefona = _db.korisnik.Where(k=>k.ID==user.KorisnikID).FirstOrDefault().Telefon, Operacija = "Login", userName = model.Email });
                    if (await _userManager.IsInRoleAsync(user, "Apotekar"))
                        return RedirectToAction("ConfirmPhoneNumber", new { brTelefona = _db.Apotekar.Where(a => a.ID == user.ApotekarID).FirstOrDefault().Telefon, Operacija = "Login", userName = model.Email });
                    else
                        return RedirectToAction("ConfirmPhoneNumber", new { brTelefona = user.PhoneNumber, Operacija = "Login", userName = model.Email });
                }
                if (result1.Succeeded)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid LoginAttempt");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmina()
        {
           
                return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmina(AddAdminaVM model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber=model.Telefon
                    
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("DodijeliUlogu", "Administracija",new DodijeliUloguVM {nazivUloge= "Admin", korisnikID = user.Id });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> DetaljiUsera()
        {
            var user =await _userManager.GetUserAsync(HttpContext.User);
            if (User != null)
            {
                DetaljiKorisnikaVM model;
                if (await _userManager.IsInRoleAsync(user,"Korisnik"))
                {
                    model = _db.korisnik.Where(kk => kk.ID == user.KorisnikID).Select(k => new DetaljiKorisnikaVM()
                    {
                        userID=user.Id,
                        Ime = k.Ime,
                        Prezime = k.Prezime,
                        Email = user.Email,
                        Adresa = k.Adresa,
                        ConfirmedTelefon = user.PhoneNumberConfirmed,
                        DatumRodjenja = k.DatumRodjenja.ToString("dd.MM.yyyy"),
                        OpstinaRodjenja = k.OpstinaRodjenja.Naziv,
                        Telefon = k.Telefon
                    }).FirstOrDefault();
                    return View(model);
                }
                else if(await _userManager.IsInRoleAsync(user,"Apotekar"))
                {
                    model = _db.Apotekar.Where(aa => aa.ID == user.ApotekarID).Select(a => new DetaljiKorisnikaVM()
                    {
                        userID=user.Id,
                        Ime = a.Ime,
                        Prezime = a.Prezime,
                        Email = user.Email,
                        JMBG=a.JMBG,
                        DatumZaposlenja=a.DatumZaposlenja.ToString("dd.MM.yyyy"),
                        ConfirmedTelefon = user.PhoneNumberConfirmed,
                        DatumRodjenja = a.DatumRodjenja.ToString("dd.MM.yyyy"),
                        OpstinaRodjenja = a.MjestoRodjenja.Naziv,
                        Telefon = a.Telefon
                    }).FirstOrDefault();
                    return View(model);
                }
                else
                {
                    model = new DetaljiKorisnikaVM()
                    {
                        userID=user.Id,
                        Email=user.Email,
                        Telefon =user.PhoneNumber,
                        ConfirmedTelefon=user.PhoneNumberConfirmed
                        
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> UrediUsera()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (User != null)
            {
                UrediKorisnikaVM model;
                if (await _userManager.IsInRoleAsync(user, "Korisnik"))
                {
                    model = _db.korisnik.Where(kk => kk.ID == user.KorisnikID).Select(k => new UrediKorisnikaVM()
                    {
                        userID = user.Id,
                        Email = user.Email,
                        ConfirmedTelefon = user.PhoneNumberConfirmed,
                        Telefon = k.Telefon
                    }).FirstOrDefault();
                    return View(model);
                }
                else if (await _userManager.IsInRoleAsync(user, "Apotekar"))
                {
                    model = _db.Apotekar.Where(aa => aa.ID == user.ApotekarID).Select(a => new UrediKorisnikaVM()
                    {
                        userID = user.Id,
                        Email = user.Email,
                        ConfirmedTelefon = user.PhoneNumberConfirmed,
                        Telefon = a.Telefon
                    }).FirstOrDefault();
                    return View(model);
                }
                else
                {
                    model = new UrediKorisnikaVM()
                    {
                        userID = user.Id,
                        Email = user.Email,
                        Telefon = user.PhoneNumber,
                        ConfirmedTelefon=user.PhoneNumberConfirmed
                        
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UrediUsera(UrediKorisnikaVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (User != null)
            {
                if (await _userManager.IsInRoleAsync(user, "Korisnik"))
                {
                    user.Email = model.Email;
                    Korisnik k = _db.korisnik.Find(user.KorisnikID);
                    if(k.Telefon!=model.Telefon)
                    {
                        await _userManager.SetTwoFactorEnabledAsync(user, false);
                        user.PhoneNumberConfirmed = false;
                    }
                    k.Telefon = model.Telefon;
                        _db.SaveChanges();
                    return RedirectToAction("DetaljiUsera");
                }
                else if (await _userManager.IsInRoleAsync(user, "Apotekar"))
                {
                    user.Email = model.Email;
                    Apotekar a = _db.Apotekar.Find(user.ApotekarID);
                    if (a.Telefon != model.Telefon)
                    {
                        await _userManager.SetTwoFactorEnabledAsync(user, false);
                        user.PhoneNumberConfirmed = false;
                    }
                    a.Telefon = model.Telefon; 
                        _db.SaveChanges();
                    return RedirectToAction("DetaljiUsera");

                }
                else
                {

                    user.Email = model.Email;
                    if (user.PhoneNumber != model.Telefon)
                    {
                        await _userManager.SetTwoFactorEnabledAsync(user, false);
                        user.PhoneNumberConfirmed = false;
                    }
                    user.PhoneNumber= model.Telefon;
                        _db.SaveChanges();
                    return RedirectToAction("DetaljiUsera");

                }
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}