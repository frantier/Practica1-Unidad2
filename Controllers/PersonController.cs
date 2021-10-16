using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Objetos
Nombre del Maestro: Chuc Uc Joel Ivan
Practica: Actividad 1
Nombre del alumno: Pedro Victor Ruvalcaba Novelo
Cuatrimestre: 4
Grupo: B
Parcial: 2
*/

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        // Todos los datos //

        [HttpGet]
        [Route("DatosGenerales")]
        public IActionResult DatosGenerales ()
        {
            var repository = new PersonRepository();
            var persons = repository.Todalainfo();
            return Ok(persons);
        } 

        // Informacion Especifica //

        [HttpGet]
        [Route("DatosEspecificios")]
        public IActionResult DatosEspecificos ()
        {
            var repository = new PersonRepository();
            var persons = repository.InformacionEspecifica();
            return Ok(persons);
        } 

        // Informacion de Generos //
        
        [HttpGet]
        [Route("FiltrodeGeneros")]
        public IActionResult FiltradodeGeneros (char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.Infomraciondegenero(genero);
            return Ok(persons);
        } 

        // Inforamcion de rango de edades //

        [HttpGet]
        [Route("RangodeEdades")]
        public IActionResult RangodeEdades (int edadmin, int edadmax)
        {
            var repository = new PersonRepository();
            var persons = repository.InforamcionRangodeEdades(edadmin, edadmax);
            return Ok(persons);
        }

        // Informacion de Trabajos //

        [HttpGet]
        [Route("TodoslosTrabajos")]
        public IActionResult InfodeTrabajos ()
        {
            var repository = new PersonRepository();
            var persons = repository.TodoslosTrabajos();
            return Ok(persons);
        } 

        // Buscador de letras clave //

        [HttpGet]
        [Route("LetraClave")]
        public IActionResult InfoClave (string letraclave)
        {
            var repository = new PersonRepository();
            var persons = repository.InfoClave(letraclave);
            return Ok(persons);
        }

        // Buscador de multiples edades //
        [HttpGet]
        [Route("EdadesMultiples")]
        public IActionResult BuscadorMultipledeEdades (int dato1, int dato2, int dato3)
        {
            var repository = new PersonRepository();
            var persons = repository.MultiplesEdades(dato1, dato2, dato3);
            return Ok(persons);
        } 

        // Obtencion de informacion desde un punto //

        [HttpGet]
        [Route("InformacionOrdenadaSegunUnPunto")]
        public IActionResult BuscarPersonasOrdenadas (int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.Edadesdespuesdeunpunto(edad);
            return Ok(persons);
        }

        // Buscador de Genero y Edad //

        [HttpGet]
        [Route("FiltradodeGeneroyRangodeEdad")]
        public IActionResult InformacionRangoEdadyGenero (int edadmin, int edadmax, char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenciondeEdadyRango(edadmin, edadmax, genero);
            return Ok(persons);
        } 

        // Contador de Genero //

        [HttpGet]
        [Route("ConteoDeGenero")]
        public IActionResult ListadeGenero (char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.ListaseparadadeGenero(genero);
            return Ok(persons);
        }

        // Buscador de Apellidos //

        [HttpGet]
        [Route("ExistenciaDeApellido")]
        public IActionResult BuscadordeApellido (string apellido)
        {
            var repository = new PersonRepository();
            var persons = repository.ExistenciadeValores(apellido);
            return Ok(persons);
        }

        // Filtro de trabajo y edad //

        [HttpGet]
        [Route("InformacionDeTrabajoyEdad")]
        public IActionResult InformacionEdadyTrabajo (string trabajo, int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.FiltroTrabajoyEdad(trabajo, edad);
            return Ok(persons);
        } 

        // Buscador de los 3 primero resultados //

        [HttpGet]
        [Route("Los3PrimerosResultados")]
        public IActionResult Obtener3Personas (string trabajo, int obtencion)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerPrimeros3(trabajo, obtencion);
            return Ok(persons);
        }

        // Buscador que omita los 3 primeros resultados y otorge los 3 siguientes //

        [HttpGet]
        [Route("SaltoDeLosPrimeros3")]
        public IActionResult SaltadorDePersonas (string trabajo, int obtencionomitida)
        {
            var repository = new PersonRepository();
            var persons = repository.Saltode3Personas(trabajo, obtencionomitida);
            return Ok(persons);
        } 

        // Obtencion de informacion de las siguiente 3 personas de las iniciales //

        [HttpGet]
        [Route("Los3Siguientes")]
        public IActionResult Salto3personas (string trabajo, int salto, int obtencionomitida)
        {
            var repository = new PersonRepository();
            var persons = repository.Saltode3PersonasyObtenciondedatos(trabajo, salto, obtencionomitida);
            return Ok(persons);
        }
    }
}
