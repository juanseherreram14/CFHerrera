using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CFHerrera.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Name { get; set; }
        [MaxLength(250), Unique]
        public string Deporte { get; set; }
        [MaxLength(250), Unique]
        public string Ciudad { get; set; }
    }
}
