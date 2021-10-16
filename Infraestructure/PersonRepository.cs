using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Objetos
Nombre del Maestro: Chuc Uc Joel Ivan
Practica: Actividad 1
Nombre del alumno: Pedro Victor Ruvalcaba Novelo
Cuatrimestre: 4
Grupo: B
Parcial: 2
*/

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // Obtencion de toda la informacion //

        public IEnumerable<Person> Todalainfo ()
        {
            return _persons;
        }

        // Obtencion de informacion especifica //

        public IEnumerable<Object> InformacionEspecifica ()
        {
            var query = _persons.Select(person => new {

                NombreCompleto = $"{person.FirstName} {person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1).Year,
                CorreoElcetronico = person.Email 
            });
            
            return query;
        }

        // Obtencion de informacion de generos //

        public IEnumerable<Person> Infomraciondegenero (char genero)
        {
            var query = _persons.Where(person => person.Gender == genero);
            return query;
        }

        // Obtencion de valores de un rango //
        
        public IEnumerable<Person> InforamcionRangodeEdades (int edadmin, int edadmax)
        {
            var query = _persons.Where(person => person.Age > edadmin && person.Age < edadmax);
            return query;
        }

        // Obtencion de informacion de trabajos //
        
        public IEnumerable<string> TodoslosTrabajos()
        {
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        } 

        // Obtencion de informacion con palabras clave //
        
        public IEnumerable<Person> InfoClave (string letraclave)
        {
            var query = _persons.Where(person => person.FirstName.Contains(letraclave));
            return query;
        }

        // Obtencion de varias edades //

        public IEnumerable<Person> MultiplesEdades (int dato1, int dato2, int dato3)
        {
            var edades = new List<int>{dato1,dato2,dato3};
            var query = _persons.Where(person => edades.Contains(person.Age));
            return query;
        }

        // Obtencion de informacion apartir de un punto //
        
        public IEnumerable<Person> Edadesdespuesdeunpunto (int edad)
        {
            var query = _persons.Where(person => person.Age > edad).OrderBy(person => person.Age);
            return query;
        }

        // Obtencion de informacion por genero y rango de edades //

        public IEnumerable<Person> ObtenciondeEdadyRango (int rangoMin, int rangoMax, char genero)
        {
            var query = _persons.Where(person => person.Age > rangoMin && person.Age < rangoMax &&  person.Gender ==  genero).OrderByDescending(person =>  person.Gender);
            return query;
        }

        // Contador de genero //
        
        public IEnumerable<Person> ListaseparadadeGenero (char genero)
        {
            var query = _persons.Where(person => person.Gender == genero);
            return query;
        }

        // Buscador de existencia //

        public bool ExistenciadeValores (string apellido)
        {
            var query = _persons.Any(p => p.LastName == apellido);

            return query;
        }

        // Filtro de informacion de trabajo y Edad //

        public IEnumerable<Person> FiltroTrabajoyEdad (string trabajo, int edad)
        {
            var query = _persons.Where(person => person.Job == trabajo && person.Age == edad);
            return query;
        }

        // Buscador de los 3 primeros resultados //
        
        public IEnumerable<Person> ObtenerPrimeros3 (string trabajo, int obtencion)
        {
            var query = _persons.Where(person => person.Job == trabajo).Take(obtencion);
            return query;
        }

        // Buscador que omita los 3 primeros resultados y otorge los 3 siguientes //
        public IEnumerable<Person> Saltode3Personas (string trabajo, int obtencionomitida)
        {

            var query = _persons.Where(person => person.Job == trabajo).TakeLast(obtencionomitida);
            return query;
        }

        // Obtencion de informacion de las siguiente 3 personas de las iniciales //
        
        public IEnumerable<Person> Saltode3PersonasyObtenciondedatos(string trabajo, int salto, int obtencionomitida)
        {
            var query = _persons.Where(person => person.Job == trabajo).Skip(salto).Take(obtencionomitida);
            return query;
        }
    }
}