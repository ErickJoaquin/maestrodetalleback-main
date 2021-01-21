using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.Models  
{  
    public class Orden  
    {  
        public int Id { get; set;}  
        public DateTime fechaCreacion { get; set;}    
        public int clientId { get; set;}    
        public int total { get; set;}   

        public Cliente Cliente {get; set;}
        public List<OrdenDetalle> OrdenDetalles{get; set;}

    }  
}  