using System.Collections.Generic;

namespace EFMDS.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DoctorViewModel> Doctors { get; set; } = new List<DoctorViewModel>();
    }
}
