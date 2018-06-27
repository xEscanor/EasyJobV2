using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyJob.Models;

namespace EasyJob.Controllers
{
    public class CompaniesController : ApiController
    {
        private EasyJobContext db = new EasyJobContext();

        // GET: api/Companies
        public IQueryable<Company> GetCompanies()
        {
            return db.Companies.Include(b => b.VilleId).Include(b=>b.FieldOfActivity).Include(b=>b.UserId);
        }

        // GET: api/authors/5
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> GetCompany(int id)
        {
            Company company = await db.Companies.Include(b => b.VilleId).Include(b => b.FieldOfActivity).SingleOrDefaultAsync(b=>b.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(void))]
        public IHttpActionResult ChangeNom(int id, String nom)
        {
            var BDD = db.Set<Company>();
            //test pour faire des updates
            var result = BDD.SingleOrDefault(b => b.Id == id);
            if (result != null)
            {
                result.CompanyName = nom;
                db.SaveChanges();
            }
            return Ok();
            //fin du test
        }

        // POST: api/companies
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> PostAuthor(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        }

        // DELETE: api/authors/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteCompany(int id)
        {
            Company company = await db.Companies.Include(b => b.VilleId).Include(b => b.FieldOfActivity).SingleOrDefaultAsync(b => b.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            await db.SaveChangesAsync();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.Id == id) > 0;
        }
    }
}