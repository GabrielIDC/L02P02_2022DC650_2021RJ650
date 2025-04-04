using L02P02_2022DC650_2021RJ650.Models;
using Microsoft.AspNetCore.Mvc;
using L02P02_2022DC650_2021RJ650.Helpers;

namespace L02P02_2022DC650_2021RJ650.Controllers
{
    public class VentaController : Controller
    {
        private readonly librosDbContext _context;
        public VentaController(librosDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var libros = _context.libros
                .Where(l => l.estado == "A") // si solo querés los activos
                .ToList();

            ViewBag.Total = HttpContext.Session.GetDecimal("Total") ?? 0;
            return View(libros);
        }

        [HttpPost]
        public IActionResult Agregar(int idLibro)
        {
            int? pedidoId = HttpContext.Session.GetInt32("PedidoId");

            if (pedidoId == null)
                return RedirectToAction("Index", "Inicio");

            var libro = _context.libros.FirstOrDefault(l => l.id == idLibro);
            if (libro == null)
                return RedirectToAction("Index");

            // Insertar en pedido_detalle
            var detalle = new pedido_detalle
            {
                id_pedido = pedidoId.Value,
                id_libro = idLibro,
                created_at = DateTime.Now
            };
            _context.pedido_detalles.Add(detalle);
            _context.SaveChanges();

            // Obtener total actual de sesión y sumarle el nuevo precio
            decimal totalActual = HttpContext.Session.GetDecimal("Total") ?? 0;
            totalActual += libro.precio;
            HttpContext.Session.SetDecimal("Total", totalActual);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Completar()
        {
            return RedirectToAction("Index", "Cierre"); // Prototipo 03
        }
    }
}