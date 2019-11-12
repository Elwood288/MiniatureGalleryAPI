using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Miniature_Gallery_API.ApiModels;
using Miniature_Gallery_API.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniature_Gallery_API.Controllers
{
    // TODO: Prep Part 2: Add authorization
    //[Authorize]
    [Route("api/[controller]")]
   
    public class MiniaturesController : Controller
    {
        private IMiniatureService _miniatureService;

        public MiniaturesController(IMiniatureService miniaturesService)
        {
            _miniatureService = miniaturesService;
        }

        // TODO: Class Project: Add CurrentUserId property
       /* private string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }
        */

        // GET api/miniatures
        [HttpGet]
        public IActionResult Get()
        {
            var allMiniatures = _miniatureService
                    .GetAll()
                    .ToApiModels();
            return Ok(allMiniatures);





            // if the user is an Admin, return all miniatures
            /*if (User.IsInRole("Admin"))
            {
                var allMiniatures = _miniatureService
                    .GetAll()
                    .ToApiModels();
                return Ok(allMiniatures);
            }
            */
            // otherwise return only the user's miniatures
            /* var miniatureModels = _miniatureService
                 .GetAllForUser(CurrentUserId)
                 .ToApiModels();
             return Ok(miniatureModels); */
        }

        // get specific miniature by id
        // GET api/miniatures/:id
        
     
     // get specific miniature by id
     // GET api/miniatures/:id
     [HttpGet("{id}")]
     public IActionResult Get(int id)
        {
            var miniature = _miniatureService.Get(id);
            if (miniature == null) return NotFound();
            return Ok(miniature.ToApiModel());


            // if the miniature does not belong to the current user and the current user is not an admin
            /*if (miniature.Id != CurrentUserId && !User.IsInRole("Admin"))
            {
                ModelState.AddModelError("UserId", "You can only retrieve your own miniatures.");
                return BadRequest(ModelState);
            }
            */

        }

        // create a new miniature
        // POST api/miniatures
        [HttpPost]
        public IActionResult Post([FromBody] MiniatureModel miniatureModel)
        {
            try
            {
                // add the new miniature
                _miniatureService.Add(miniatureModel.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddMiniature", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = miniatureModel.Id }, miniatureModel);
        }

        // PUT api/miniatures/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MiniatureModel updatedMiniature)
        {
            var miniature = _miniatureService.Update(updatedMiniature.ToDomainModel());
            if (miniature == null) return NotFound();
            return Ok(miniature.ToApiModel());
        }

        // DELETE api/miniatures/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var miniature = _miniatureService.Get(id);
            if (miniature == null) return NotFound();
            _miniatureService.Remove(miniature);
            return NoContent();
        }

        // TODO: Class Project: Add new Delete route
        // DELETE /api/miniatures
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete()
        {
            // code to delete all miniatures goes here...

            return Ok("Deleted all miniatures");
        }
    }
}