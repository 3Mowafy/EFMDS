using System;
using System.Collections.Generic;

namespace EFMDS.Web.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Specialty { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public List<string> AvailableAppointments { get; set; } = new List<string>();
        public string WaitTime { get; set; }
        
        // Detailed properties for doctor details page
        public string About { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
    }
}
