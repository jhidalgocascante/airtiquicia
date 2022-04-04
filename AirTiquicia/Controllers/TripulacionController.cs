using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;

namespace AirTiquicia.Controllers
{
    public class TripulacionController : Controller
    {
        TripulacionDatos _TripulacionDatos = new TripulacionDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _TripulacionDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(TripulacionModel oTripulacion)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _TripulacionDatos.Guardar(oTripulacion);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodTripulante)
        {
            //Devolver solo la vista formato hmtml
            var oTripulacion = _TripulacionDatos.Obtener(CodTripulante);
            return View(oTripulacion);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(TripulacionModel oTripulacion)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _TripulacionDatos.Editar(oTripulacion);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodTripulante)
        {
            //Devolver solo la vista formato hmtml
            var ocontacto = _TripulacionDatos.Obtener(CodTripulante);
            return View(ocontacto);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(TripulacionModel oTripulacion)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _TripulacionDatos.Eliminar(oTripulacion.CodTripulante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
