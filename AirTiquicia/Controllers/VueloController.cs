using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;
namespace AirTiquicia.Controllers
{
    public class VueloController : Controller
    {

        VueloDatos _VueloDatos = new VueloDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _VueloDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(VueloModel oVuelo)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _VueloDatos.Guardar(oVuelo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodVuelo)
        {
            //Devolver solo la vista formato hmtml
            var oAvion = _VueloDatos.Obtener(CodVuelo);
            return View(oAvion);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(VueloModel oVuelo)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _VueloDatos.Editar(oVuelo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodVuelo)
        {
            //Devolver solo la vista formato hmtml
            var ocontacto = _VueloDatos.Obtener(CodVuelo);
            return View(ocontacto);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(VueloModel oVuelo)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _VueloDatos.Eliminar(oVuelo.CodVuelo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
