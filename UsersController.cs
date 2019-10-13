using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNetCore.Mvc.Binder;
using Assignment.Models;
using System.Linq.Dynamic.Core;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly AssignmentDBContext _context;
        public UsersController(AssignmentDBContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet()]
        public IActionResult Get([DataTablesRequest] DataTablesRequest dataRequest)
       {
            //var users = _context.User.ToList();
            IEnumerable<Users> users = _context.User.ToList();
            int recordsTotal = users.Count();
            int recordsFilterd = recordsTotal;

            if (!string.IsNullOrEmpty(dataRequest.Search?.Value))
            {
                users = users.Where(e => e.Name.Contains(dataRequest.Search.Value) || e.Email.Contains(dataRequest.Search.Value) || e.SelectedEvents.Contains(dataRequest.Search.Value));
                recordsFilterd = users.Count();
            }
           users = users.Skip(dataRequest.Start).Take(dataRequest.Length).AsQueryable().OrderBy(dataRequest.Columns.ToList()[dataRequest.Orders.First().Column].Data + " " + dataRequest.Orders.First().Dir);

            return Json(users
                .Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    RegisteredDate = e.RegisteredDate.ToShortDateString(),
                    Gender = e.Gender,
                    SelectedEvents = e.SelectedEvents,
                    AdditionalRequest = e.AdditionalRequest
                })
                .ToDataTablesResponse(dataRequest, recordsTotal, recordsFilterd));
        }

       
    }
}
