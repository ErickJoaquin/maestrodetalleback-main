using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.Models  
{  
    public class Cliente  
    {  
        public int Id { get; set;}  
        public string Nombre { get; set;}    

        public List<Orden> Ordens { get; set; }
    }  
}  