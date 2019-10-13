using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.ViewModels
{
    public class UserDetailViewModel
    {
        public Users user { get; set; }
        public List<EventViewModel> Events { get; set; }
    }
}
