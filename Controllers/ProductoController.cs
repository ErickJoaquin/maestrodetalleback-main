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
    public class ProductoController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public ProductoController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Producto> Get()  
        {  
            return (this.myDbContext.Productos.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            myDbContext.Productos.Add(producto);
            await myDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetTodoItem(int id)
        {
            var producto = await myDbContext.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

    }  
}   