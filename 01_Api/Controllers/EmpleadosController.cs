using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using _04_Data.Data;

namespace _01_Api.Controllers
{
    //[EnableCors(origins: "http://localhost", headers: "*", methods: "*")]

    public class EmpleadosController : ApiController
    {
        private NorthWindTuneadoDbContext db = new NorthWindTuneadoDbContext();

        // GET: api/Empleados
        public IList<Empleado> GetEmpleado()
        {
            var empleados = db.Empleado;
            IList<Empleado> empleadosSinHijos = new List<Empleado>();
            foreach (Empleado empleado in empleados)
            {
                Empleado empleadoSinHijos = new Empleado();
                empleadoSinHijos.EmployeeID = empleado.EmployeeID;
                empleadoSinHijos.FirstName = empleado.FirstName;
                empleadoSinHijos.LastName  = empleado.LastName ;
                empleadosSinHijos.Add(empleadoSinHijos);
            }
            return empleadosSinHijos;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id)
        {
            Empleado empleado = db.Empleado.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            Empleado empleadoSinHijos = new Empleado();
            empleadoSinHijos.EmployeeID = empleado.EmployeeID;
            empleadoSinHijos.FirstName = empleado.FirstName;
            empleadoSinHijos.LastName = empleado.LastName;

            return Ok(empleadoSinHijos);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleado.Add(empleado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleado.EmployeeID }, empleado);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleado.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.Empleado.Count(e => e.EmployeeID == id) > 0;
        }
    }
}