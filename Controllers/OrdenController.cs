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
    public class OrdenController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public OrdenController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Orden> Get()  
        {  
            return (this.myDbContext.Ordenes.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<Orden>> Post(Orden orden)
        {
            myDbContext.Ordenes.Add(orden);
            await myDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = orden.Id }, orden);
        }

    }  
}   