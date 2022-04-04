using Microsoft.AspNetCore.Mvc;
using AirTiquicia.Datos;
using AirTiquicia.Models;

namespace AirTiquicia.Controllers
{
    public class RangoEquipajeController : Controller
    {
        RangoEquipajeDatos _RangoEquipajeDatosDatos = new RangoEquipajeDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _RangoEquipajeDatosDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(RangoEquipajeModel oRangoEquipaje)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _RangoEquipajeDatosDatos.Guardar(oRangoEquipaje);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodRangoEquipaje)
        {
            //Devolver solo la vista formato hmtml
            var oRangoEquipaje = _RangoEquipajeDatosDatos.Obtener(CodRangoEquipaje);
            return View(oRangoEquipaje);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(RangoEquipajeModel oRangoEquipaje)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _RangoEquipajeDatosDatos.Editar(oRangoEquipaje);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodRangoEquipaje)
        {
            //Devolver solo la vista formato hmtml
            var oRangoEquipaje = _RangoEquipajeDatosDatos.Obtener(CodRangoEquipaje);
            return View(oRangoEquipaje);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(RangoEquipajeModel oRangoEquipaje)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _RangoEquipajeDatosDatos.Eliminar(oRangoEquipaje.CodRangoEquipaje);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }




    }
}
