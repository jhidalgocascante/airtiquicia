using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;

namespace AirTiquicia.Controllers
{
    public class ReservaController : Controller
    {
        ReservaDatos _ReservaDatos = new ReservaDatos();
        VueloDatos _VueloDatos = new VueloDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _ReservaDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar(int CodVuelo)
        {
            //Devolver solo la vista formato hmtml
            //return View();

            //string DestinoBusqueda1 = Request.Form["city"].ToString();
            //string FechaInicio1 = Request.Form["check-in"].ToString();
            //string FechaFinal1 = Request.Form["check-out"].ToString();

            //la vista mostrará una lista de contactos
            var oVuelo = _ReservaDatos.ObtenerDetalleVuelo(CodVuelo);
            return View(oVuelo);

            //VueloModel ObtenerDetalleVuelo(int CodVuelo)


        }

        [HttpPost]
        public IActionResult Guardar(ReservaModel oReserva)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ReservaDatos.Guardar(oReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodReserva)
        {
            //Devolver solo la vista formato hmtml
            var oReserva = _ReservaDatos.Obtener(CodReserva);
            return View(oReserva);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(ReservaModel oReserva)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ReservaDatos.Editar(oReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodReserva)
        {
            //Devolver solo la vista formato hmtml
            var oReserva = _ReservaDatos.Obtener(CodReserva);
            return View(oReserva);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(ReservaModel oReserva)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ReservaDatos.Eliminar(oReserva.CodReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        //Buscar vuelos

    }
}
