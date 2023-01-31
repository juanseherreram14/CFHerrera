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
       
        public DateOnly Fecha { get; set; }
        public TimeOnly hora { get; set; }
        public int jugadores { get; set; }
        public Cancha cancha { get; set; }

    }
}
