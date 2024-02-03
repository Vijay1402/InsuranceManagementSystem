using System.Collections.Generic;
using System.Web.Http;
using DAL;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class AdminsController : ApiController
    {
        private InsuranceService _insuranceService;

        public AdminsController()
        {
            
            _insuranceService = new InsuranceService(new InsuranceDAL(new InsuranceDbContext()));
        }

        public AdminsController(InsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return _insuranceService.GetAllAdmins();
        }

        public IHttpActionResult GetAdmin(int id)
        {
            Admin admin = _insuranceService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        public IHttpActionResult PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _insuranceService.AddAdmin(admin);

            return CreatedAtRoute("DefaultApi", new { id = admin.Id }, admin);
        }

        public IHttpActionResult PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.Id)
            {
                return BadRequest();
            }

            _insuranceService.UpdateAdmin(admin);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteAdmin(int id)
        {
            Admin admin = _insuranceService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            _insuranceService.DeleteAdmin(id);

            return Ok(admin);
        }
    }
}
