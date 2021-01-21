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
    public class ClienteController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public ClienteController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Cliente> Get()  
        {  
            return (this.myDbContext.Clientes.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(Cliente cliente)
        {
            myDbContext.Clientes.Add(cliente);
            await myDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

    }  
}   