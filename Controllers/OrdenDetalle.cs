using MaestroDetalle.DBContexts;  
using MaestroDetalle.Models;  
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.Data.Entity;  
using System.Data.Entity.Infrastructure;  

  
namespace MaestroDetalle.Controllers  
{  
    [Route("api/[controller]")]  
    [ApiController]  
    public class OrdenDetalleController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public OrdenDetalleController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<OrdenDetalle> Get()  
        {  
            return (this.myDbContext.OrdenDetalles.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<OrdenDetalle>> Post(OrdenDetalle ordenDetalles)
        {
            myDbContext.OrdenDetalles.Add(ordenDetalles);
            await myDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = ordenDetalles.Id }, ordenDetalles);
        }

    }  
}   