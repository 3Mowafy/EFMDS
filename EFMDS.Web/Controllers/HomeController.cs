using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EFMDS.Web.ViewModels;

namespace EFMDS.Web.Controllers
{
    public class HomeController : Controller
    {
        private List<DoctorViewModel> GetMockDoctors()
        {
            return new List<DoctorViewModel>
            {
                new DoctorViewModel {
                    Id = 1,
                    Name = "د. منى محمود",
                    Title = "أستاذ",
                    Specialty = "أسنان",
                    Location = "مدينة نصر، القاهرة",
                    Price = 300,
                    Rating = 4.5,
                    ReviewsCount = 120,
                    Gender = "Female",
                    WaitTime = "15 دقيقة",
                    ImageUrl = "https://ui-avatars.com/api/?name=Mona&background=0D8ABC&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "اليوم 05:00 م", "اليوم 06:30 م", "غداً 02:00 م", "غداً 04:30 م", "غداً 08:00 م" },
                    About = "د. منى محمود، أستاذ طب وجراحة الفم والأسنان. متخصصة في زراعة الأسنان وتجميل الأسنان بخبرة تزيد عن 20 عاماً في تقديم أحدث تقنيات العلاج.",
                    Education = "بكالوريوس طب الأسنان جامعة القاهرة، ماجستير ودكتوراه في زراعة الأسنان.",
                    Experience = "أكثر من 20 عاماً من الخبرة في كبرى المستشفيات والمراكز المتخصصة."
                },
                new DoctorViewModel {
                    Id = 2,
                    Name = "د. سارة محمد",
                    Title = "استشاري",
                    Specialty = "أطفال",
                    Location = "المعادي، القاهرة",
                    Price = 250,
                    Rating = 5.0,
                    ReviewsCount = 85,
                    Gender = "Female",
                    WaitTime = "10 دقائق",
                    ImageUrl = "https://ui-avatars.com/api/?name=Sara&background=E84B8E&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "غداً 10:00 ص", "غداً 11:30 ص", "غداً 12:00 م", "الخميس 01:00 م" },
                    About = "استشاري طب الأطفال وحديثي الولادة. تقدم رعاية متكاملة للأطفال وتتابع النمو وتوفر استشارات التغذية والتطعيمات.",
                    Education = "بكالوريوس الطب والجراحة، زمالة طب الأطفال.",
                    Experience = "خبرة 15 عاماً في مستشفى أبو الريش للأطفال."
                },
                new DoctorViewModel {
                    Id = 3,
                    Name = "د. نادية مصطفى",
                    Title = "مدرس",
                    Specialty = "باطنة",
                    Location = "الدقي، الجيزة",
                    Price = 400,
                    Rating = 4.0,
                    ReviewsCount = 45,
                    Gender = "Female",
                    WaitTime = "25 دقيقة",
                    ImageUrl = "https://ui-avatars.com/api/?name=Nadia&background=10B981&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "اليوم 08:00 م", "اليوم 09:30 م", "اليوم 10:00 م", "غداً 07:00 م" },
                    About = "مدرس أمراض الباطنة والجهاز الهضمي، متخصصة في علاج أمراض المعدة والقولون ومتابعة مرضى السكري والضغط.",
                    Education = "دكتوراه الأمراض الباطنة.",
                    Experience = "خبرة 10 سنوات في مستشفيات القصر العيني."
                },
                new DoctorViewModel {
                    Id = 4,
                    Name = "د. مريم سمير",
                    Title = "أخصائي",
                    Specialty = "جلدية",
                    Location = "مصر الجديدة، القاهرة",
                    Price = 350,
                    Rating = 4.8,
                    ReviewsCount = 200,
                    Gender = "Female",
                    WaitTime = "20 دقيقة",
                    ImageUrl = "https://ui-avatars.com/api/?name=Mariam&background=F59E0B&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "بعد غد 01:00 م", "بعد غد 03:00 م", "الجمعة 05:00 م", "الجمعة 06:30 م" },
                    About = "أخصائي الأمراض الجلدية والتجميل والليزر. تقدم أحدث علاجات تساقط الشعر، البوتكس، الفيلر، ونضارة البشرة.",
                    Education = "ماجستير الأمراض الجلدية والتناسلية.",
                    Experience = "خبرة 8 سنوات في مراكز التجميل الكبرى."
                },
                new DoctorViewModel {
                    Id = 5,
                    Name = "د. هند يوسف",
                    Title = "استشاري",
                    Specialty = "نساء وتوليد",
                    Location = "المهندسين، الجيزة",
                    Price = 450,
                    Rating = 4.9,
                    ReviewsCount = 310,
                    Gender = "Female",
                    WaitTime = "30 دقيقة",
                    ImageUrl = "https://ui-avatars.com/api/?name=Hend&background=8B5CF6&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "اليوم 04:00 م", "اليوم 05:30 م", "غداً 03:00 م", "غداً 04:00 م", "الأربعاء 07:00 م" },
                    About = "استشاري أمراض النساء والتوليد وتأخر الإنجاب. تتابع حالات الحمل الحرج وتجري جراحات المناظير النسائية.",
                    Education = "دكتوراه طب النساء والتوليد، زمالة الكلية الملكية.",
                    Experience = "أكثر من 18 عاماً من الخبرة."
                },
                new DoctorViewModel {
                    Id = 6,
                    Name = "د. ياسمين خالد",
                    Title = "أستاذ",
                    Specialty = "عيون",
                    Location = "التجمع الخامس، القاهرة",
                    Price = 500,
                    Rating = 4.7,
                    ReviewsCount = 150,
                    Gender = "Female",
                    WaitTime = "15 دقيقة",
                    ImageUrl = "https://ui-avatars.com/api/?name=Yasmine&background=EC4899&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "غداً 09:00 ص", "غداً 10:30 ص", "غداً 11:00 ص", "الخميس 02:00 م" },
                    About = "أستاذ طب وجراحة العيون، متخصصة في جراحات المياه البيضاء، تصحيح الإبصار بالليزك، وعلاج الشبكية.",
                    Education = "دكتوراه طب وجراحة العيون.",
                    Experience = "خبرة تزيد عن 22 عاماً."
                },
                new DoctorViewModel {
                    Id = 7,
                    Name = "د. ريم طارق",
                    Title = "أخصائي",
                    Specialty = "تغذية",
                    Location = "الشيخ زايد، الجيزة",
                    Price = 200,
                    Rating = 4.6,
                    ReviewsCount = 90,
                    Gender = "Female",
                    WaitTime = "5 دقائق",
                    ImageUrl = "https://ui-avatars.com/api/?name=Reem&background=06B6D4&color=fff&size=128&font-size=0.33",
                    AvailableAppointments = new List<string> { "اليوم 01:00 م", "اليوم 02:00 م", "غداً 01:00 م", "غداً 02:30 م", "غداً 04:00 م" },
                    About = "أخصائي التغذية العلاجية والسمنة والنحافة. تضع برامج غذائية مخصصة لحالات السكري، الضغط، والرياضيين.",
                    Education = "دبلوم التغذية العلاجية المعتمد.",
                    Experience = "خبرة 6 سنوات في تقديم استشارات التغذية."
                }
            };
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Doctors = GetMockDoctors()
            };
            return View(vm);
        }

        [Route("/Listing")]
        public IActionResult Listing(string specialty = null)
        {
            var doctors = GetMockDoctors().AsEnumerable();
            
            if (!string.IsNullOrEmpty(specialty))
            {
                doctors = doctors.Where(d => d.Specialty == specialty);
                ViewData["SelectedSpecialty"] = specialty;
            }

            var vm = new HomeViewModel
            {
                Doctors = doctors.ToList()
            };
            return View(vm);
        }

        public IActionResult DoctorDetails(int id)
        {
            var doctor = GetMockDoctors().FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpGet]
        public IActionResult FilterDoctors(string specialty, string title)
        {
            var doctors = GetMockDoctors().AsEnumerable();
            
            if (!string.IsNullOrEmpty(specialty))
            {
                doctors = doctors.Where(d => d.Specialty == specialty);
            }
            if (!string.IsNullOrEmpty(title))
            {
                doctors = doctors.Where(d => d.Title == title);
            }

            return PartialView("_DoctorListPartial", doctors.ToList());
        }
    }
}