using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;

namespace AirTiquicia.Controllers
{
    public class DestinosController : Controller
    {
        DestinosDatos _DestinosDatos = new DestinosDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _DestinosDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(DestinosModel oDestino)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _DestinosDatos.Guardar(oDestino);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodDestino)
        {
            //Devolver solo la vista formato hmtml
            var oDestino = _DestinosDatos.Obtener(CodDestino);
            return View(oDestino);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(DestinosModel oDestino)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _DestinosDatos.Editar(oDestino);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodDestino)
        {
            //Devolver solo la vista formato hmtml
            var ocontacto = _DestinosDatos.Obtener(CodDestino);
            return View(ocontacto);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(DestinosModel oDestino)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _DestinosDatos.Eliminar(oDestino.CodDestino);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
