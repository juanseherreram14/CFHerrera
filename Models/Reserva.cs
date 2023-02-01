using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFHerrera.Models
{
    [Table ("reserva")]
    public class Reserva
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Name { get; set; }
       
        public DateTime Fecha { get; set; }
        public int Jugadores { get; set; }
      


        public Cancha Cancha { get; set; }
        
        


    }
}
