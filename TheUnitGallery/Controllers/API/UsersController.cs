using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using TheUnitGallery.Models;
using TheUnitGalery.ViewModels;


namespace TheUnitGallery.Controllers.API
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/users/staff
        public IHttpActionResult GetStaffUsers()
        {
            var staff = (from user in _context.Users
                         select new
                         {
                             UserId = user.Id,
                             Username = user.UserName,
                             Email = user.Email,
                             RoleNames = (from userRole in user.Roles
                                          join role in _context.Roles on userRole.RoleId
                                          equals role.Id
                                          select role.Name).ToList()
                         }).ToList().Select(p => new UsersInRolesViewModel()

                         {
                             UserId = p.UserId,
                             Username = p.Username,
                             Email = p.Email,
                             Role = string.Join(",", p.RoleNames)
                         });

            staff = staff.Where(u => u.Role == "Staff" || u.Role == "Admin").ToList();

            return Ok(staff);
        }

        //DELETE API/users/staff
        public IHttpActionResult DeleteUser(string id)
        {
            var user = _context.Users.Find(id);

                _context.Users.Remove(user);
                _context.SaveChanges();

            return Ok();
        }
        
    }
}
