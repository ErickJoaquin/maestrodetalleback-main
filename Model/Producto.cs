using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.Models  
{  
    public class Producto
    {  
         public int Id { get; set;}  
        public string descripcion { get; set;}    
        public string precioUnidad { get; set;}    
        public string existencia { get; set;}    
   
        public List<OrdenDetalle> ordenDetalles { get; set; }

    }  
}  