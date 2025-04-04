using L02P02_2022DC650_2021RJ650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022DC650_2021RJ650.Controllers
{
    public class InicioController : Controller
    {
        private readonly librosDbContext _context;
        public InicioController(librosDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(clientes cliente)
        {
            // Guardar cliente
            _context.clientes.Add(cliente);
            _context.SaveChanges();

            // Crear encabezado del pedido
            var pedido = new pedido_encabezado
            {
                id_cliente = cliente.id,
                cantidad_libros = 0,
                total = 0,
                estado = "P"
            };

            _context.pedido_encabezado.Add(pedido);
            _context.SaveChanges();

            // Guardar el id del pedido en sesión
            HttpContext.Session.SetInt32("PedidoId", pedido.id);

            // Redirigir al Prototipo 02 (Venta)
            return RedirectToAction("Index", "Venta");
        }

        [HttpPost]
        public IActionResult IniciarVenta(clientes cliente)
        {
            if (ModelState.IsValid)
            {
                // Guardamos el cliente
                _context.clientes.Add(cliente);
                _context.SaveChanges();

                // Creamos el pedido con estado 'P'
                var pedido = new pedido_encabezado
                {
                    id_cliente = cliente.id,
                    cantidad_libros = 0,
                    total = 0,
                    estado = "P"
                };

                _context.pedido_encabezado.Add(pedido);
                _context.SaveChanges();

                // Guardamos el id del pedido en la sesión si lo necesitas
                HttpContext.Session.SetInt32("PedidoId", pedido.id);

                // Redirigir a Prototipo02
                return RedirectToAction("Index", "Libros"); // Asumiendo que LibrosController tiene el Prototipo02
            }

            return View("Index", cliente); // Si hay errores, vuelve al form
        }
    }
}
