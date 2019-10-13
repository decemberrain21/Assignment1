using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment.Models;
using Assignment.ViewModels;
namespace Assignment.Controllers
{
    public class UsersController : Controller
    {
        private readonly AssignmentDBContext _context;

        public UsersController(AssignmentDBContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            Users userdtl = new Users();
            return View(userdtl);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
           
            UserViewModel userdtl = new UserViewModel()
            {
                Events = new List<EventViewModel>
                {
                    new EventViewModel {EventName="Day 1",IsSelected=false},
                    new EventViewModel {EventName="Day 2",IsSelected=false},
                    new EventViewModel {EventName="Day 3",IsSelected=false}

                }
            
            };
            return View(userdtl);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Gender,RegisteredDate,SelectedEvents,AdditionalRequest,Events")] UserViewModel users)
        {
            for (int i = 0; i < users.Events.Count(); i++)
            {
                if(users.Events[i].IsSelected)
                {
                    if(users.SelectedEvents != null)
                    {
                        users.SelectedEvents += ","+users.Events[i].EventName;
                    }
                    else
                    {
                        users.SelectedEvents += users.Events[i].EventName;
                    }
                    
                    ModelState.Remove("SelectedEvents");

                }
            }
            
            if (ModelState.IsValid)
            {
                Users usr = new Users()
                {
                    Email = users.Email,
                    Name = users.Name,
                    Gender = users.Gender,
                    RegisteredDate = users.RegisteredDate,
                    SelectedEvents = users.SelectedEvents,
                    AdditionalRequest = users.AdditionalRequest,
                    Id = Guid.NewGuid()

                };
               
                _context.Add(usr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            users.Events = new List<EventViewModel>
                {
                    new EventViewModel {EventName="Day 1",IsSelected=false},
                    new EventViewModel {EventName="Day 2",IsSelected=false},
                    new EventViewModel {EventName="Day 3",IsSelected=false}

                };

            
            return View(users);
        }

        
    }
}
