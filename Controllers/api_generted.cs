using API.Donnees;
using API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class api_genert : ControllerBase
    {
        private readonly GestionDb context;

        public api_genert(GestionDb context)
        {
            this.context = context;
        }

        //get all salaries
        [HttpGet]
        public async Task<IEnumerable<Salarie>> GetProducts()
        {
            return await context.salaries.ToListAsync();
        }

        //get salary by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarie>> GetSalarie(int id)
        {
            var salarie = await context.salaries.FindAsync(id);

            if (salarie == null)
            {
                return NotFound();
            }

            return salarie;
        }
        //add salary
        [HttpPost]
        public async Task<ActionResult<Salarie>> PostSalarie(Salarie salarie)
        {
            context.salaries.Add(salarie);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSalarie", new { id = salarie.id }, salarie);
        }
        //update salary
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalarie(int id, Salarie salarie)
        {
            if (id != salarie.id)
            {
                return BadRequest();
            }

            context.Entry(salarie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalarieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //delete salary
        [HttpDelete("{id}")]
        public async Task<ActionResult<Salarie>> DeleteSalarie(int id)
        {
            var salarie = await context.salaries.FindAsync(id);
            if (salarie == null)
            {
                return NotFound();
            }

            context.salaries.Remove(salarie);
            await context.SaveChangesAsync();

            return salarie;
        }

        private bool SalarieExists(int id)
        {
            return context.salaries.Any(e => e.id == id);
        }


        //add    departement
        [HttpPost("departements")]
        public async Task<ActionResult<Departement>> PostDepartement(Departement departement)
        {
            context.departements.Add(departement);
            await context.SaveChangesAsync();

            return Ok(departement);
        }

        //get all departements
        [HttpGet("departements")]
        public async Task<IEnumerable<Departement>> GetDepartements()
        {
            return await context.departements.ToListAsync();
        }

        //update departement
        [HttpPut("departements/{id}")]
        public async Task<IActionResult> PutDepartement(int id, Departement departement)
        {
            if (id != departement.id)
            {
                return BadRequest();
            }

            context.Entry(departement).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool DepartementExists(int id)
        {
            return context.departements.Any(e => e.id == id);
        }

        //delete departement
        [HttpDelete("departements/{id}")]
        public async Task<ActionResult<Departement>> DeleteDepartement(int id)
        {
            var departement = await context.departements.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }

            context.departements.Remove(departement);
            await context.SaveChangesAsync();

            return departement;
        }

        //add salary with departement
        [HttpPost("departements/{id_dep}/salaries")]
        public async Task<ActionResult<Salarie>> PostSalarieWithDepartement(int id_dep, Salarie salarie)
        {
            var departement = await context.departements.FindAsync(id_dep);
            if (departement == null)
            {
                return NotFound();
            }

            salarie.departement = departement;
            context.salaries.Add(salarie);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSalarie", new { id = salarie.id }, salarie);
        }

    }
}
