using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFHerrera.Models;
using SQLite;

namespace CFHerrera.Data
{
    public class CanchaFacilDB
    {
        string _dbPath;                                  //String que tendrá la conexión a la base de datos
        private SQLiteConnection conn;                   //Variable que tendrá la conexión
        private SQLiteConnection connR;
        public CanchaFacilDB(string DatabasePath)     //Constructor de la clase
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)                            
                return;
            conn = new SQLiteConnection(_dbPath);        
            conn.CreateTable<Cancha>();
            
                                                            
        }

        private void InitReserva()
        {
            if (connR != null)
                return;
            connR = new SQLiteConnection(_dbPath);
            connR.CreateTable<Reserva>();

        }
        public int AddNewCancha(Cancha cancha)         
        {
            Init();
            try
            {
                int result = conn.Insert(cancha);
                return result;
            }
            catch (Exception e)
            {
                return 404;
            }

        }

        public int AddNewReserva(Reserva reserva)
        {
            InitReserva();
            try
            {
                int result = connR.Insert(reserva);
                return result;
            }
            catch (Exception e)
            {
                return 404;
            }

        }

        public List<Cancha> GetAllCanchas()            //Crea la conexión, recupera una lista de todas las filas, regresa la lista
        {
            Init();
            List<Cancha> canchas = conn.Table<Cancha>().ToList();
            return canchas;
        }

        public List<Reserva> GetAllReservas()            //Crea la conexión, recupera una lista de todas las filas, regresa la lista
        {
            InitReserva();
            List<Reserva> reservas = connR.Table<Reserva>().ToList();
            return reservas;
        }

        public List<Cancha> GetCanchasByName(string contiene)
        {
            Init();
            var cancha = from b in conn.Table<Cancha>()
                         where b.Name.Contains(contiene)
                         select b;

            return cancha.ToList();
        }

        public List<Reserva> GetReservasByName(string contiene)
        {
            InitReserva();
            var reserva = from b in connR.Table<Reserva>()
                         where b.Name.Contains(contiene)
                         select b;

            return reserva.ToList();
        }

        public Cancha GetById(int id)
        {
            Init();
            var cancha = from b in conn.Table<Cancha>()
                         where b.Id == id
                         select b;

            return cancha.FirstOrDefault();
        }

        public Reserva GetReservaById(int id)
        {
            InitReserva();
            var reserva = from b in connR.Table<Reserva>()
                         where b.Id == id
                         select b;

            return reserva.FirstOrDefault();
        }

        public void actualizarCancha(int id, string nom, string dep, string ciu)
        {
            Init();
            var canchanueva = conn.Table<Cancha>().Where(r => r.Id == id).FirstOrDefault();
            if (canchanueva != null)
            {
                // Update the values
                canchanueva.Name = nom;
                canchanueva.Deporte = dep;
                canchanueva.Ciudad = ciu;

                // Submit the changes to the database
                conn.Update(canchanueva);
            }
        }

        public void actualizarReserva(int id, string nom, DateTime fec, int jug, Cancha can )
        {
            InitReserva();
            var reservanueva = connR.Table<Reserva>().Where(r => r.Id == id).FirstOrDefault();
            if (reservanueva != null)
            {
                // Update the values
                reservanueva.Name = nom;
                reservanueva.Fecha = fec;

                reservanueva.Jugadores= jug;
                reservanueva.Cancha= can;


                // Submit the changes to the database
                conn.Update(reservanueva);
            }
        }

        public void eliminarCancha(int id)
        {
            var canchaeliminada = conn.Table<Cancha>().Where(r => r.Id == id).FirstOrDefault();
            if (canchaeliminada != null)
            {
                conn.Delete(canchaeliminada);
            }
        }

        public void eliminarReserva(int id)
        {
            var reservaeliminada = connR.Table<Reserva>().Where(r => r.Id == id).FirstOrDefault();
            if (reservaeliminada != null)
            {
                conn.Delete(reservaeliminada);
            }
        }

        public void eliminarTodasCanchas()
        {
            conn.DeleteAll<Cancha>();
            conn.Execute("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'cancha'");
        }

        public void eliminarTodasReservas()
        {
            connR.DeleteAll<Reserva>();
            connR.Execute("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'cancha'");
        }
    }
}
