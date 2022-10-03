using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context; //esto va dentro de la calse y antes del metodo index. Se aplica el apllicationDbContext, esto es lo que nos permite ingresar a la BDD

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        //HTTP GET: Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }

        //HTTP GET: Create
        public IActionResult Create()
        {
            
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken] //(SOLO PARA LOS POST)PROTECCION PARA LOS FORMUARIOS PARA QUE UN BOT POR EJEMPLO NO ENVIA PETICIONES CONTSTANTEMENTE
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                //CON ESTAS 2 LINEAS AGREGO UN REGISTRO A LA BASE DE DATOS, AGREGO UN LIBRO EN ESTE CASO
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ah creado Correctamente"; //ESTE ES EL MSJ Q VA A SALTAR EN UNA VENTA EMERGENTE DSP DE CREAR EL LIBRO
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id) //con ? se hace que la id pueda ser nula
        {
            if (id == null || id==0 )
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //(SOLO PARA LOS POST)PROTECCION PARA LOS FORMUARIOS PARA QUE UN BOT POR EJEMPLO NO ENVIA PETICIONES CONTSTANTEMENTE
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                //CON ESTAS 2 LINEAS AGREGO UN REGISTRO A LA BASE DE DATOS, AGREGO UN LIBRO EN ESTE CASO
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ah actualizador Correctamente"; //ESTE ES EL MSJ Q VA A SALTAR EN UNA VENTA EMERGENTE DSP DE CREAR EL LIBRO
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id) //con ? se hace que la id pueda ser nula
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //(SOLO PARA LOS POST)PROTECCION PARA LOS FORMUARIOS PARA QUE UN BOT POR EJEMPLO NO ENVIA PETICIONES CONTSTANTEMENTE
        public IActionResult DeleteLibro(int? id)
        {
            //obtener libro por id
            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            
            //CON ESTAS 2 LINEAS AGREGO UN REGISTRO A LA BASE DE DATOS, AGREGO UN LIBRO EN ESTE CASO
            _context.Libro.Remove(libro);
            _context.SaveChanges();

             TempData["mensaje"] = "El libro se ah Eliminado Correctamente"; //ESTE ES EL MSJ Q VA A SALTAR EN UNA VENTA EMERGENTE DSP DE CREAR EL LIBRO
             return RedirectToAction("Index");
           
            
        }
    }
}
