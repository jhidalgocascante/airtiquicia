using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;

namespace AirTiquicia.Controllers
{
    public class AvionController : Controller
    {

        AvionDatos _AvionDatos = new AvionDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _AvionDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AvionModel oAvion)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _AvionDatos.Guardar(oAvion);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodAvion)
        {
            //Devolver solo la vista formato hmtml
            var oAvion = _AvionDatos.Obtener(CodAvion);
            return View(oAvion);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(AvionModel oAvion)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _AvionDatos.Editar(oAvion);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodAvion)
        {
            //Devolver solo la vista formato hmtml
            var ocontacto = _AvionDatos.Obtener(CodAvion);
            return View(ocontacto);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(AvionModel oAvion)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _AvionDatos.Eliminar(oAvion.CodAvion);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
