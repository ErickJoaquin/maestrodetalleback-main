using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.Models  
{  
    public class OrdenDetalle  
    {  
        public int Id { get; set; }
        public int productoId { get; set;}  
        public int cantidad { get; set;}    
        public int precio { get; set;}    
        public int ordenId { get; set;}    

        public Producto Producto {get; set;}
        public Orden Orden {get; set;}
    }  
}  