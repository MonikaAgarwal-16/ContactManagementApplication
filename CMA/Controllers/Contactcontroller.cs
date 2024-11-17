using Business;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CMA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Contactcontroller : ControllerBase
    {

        private readonly IContactBusiness _contactbusiness;
        public Contactcontroller(IContactBusiness _contactbusiness)
        {
            this._contactbusiness = _contactbusiness;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Contact contact)
        {

           // return Ok(this._contactbusiness.Create(contact));
            return Ok(new { message = _contactbusiness.Create(contact) });
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(new { message = _contactbusiness.Delete(id) });
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Contact> GetAll()
        {
            return _contactbusiness.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public Contact? GetById(int id)
        {
            return _contactbusiness.GetById(id);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Contact contact)
        {

            return Ok(new { message = _contactbusiness.Update(contact) });
           // return Ok(_contactbusiness.Update(contact));
        }

    }
}
