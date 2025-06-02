using Microsoft.AspNetCore.Mvc;
using Gestper.Data;
using Gestper.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestper.Controllers
{
    public class SeguimientoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeguimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mostrar formulario de seguimiento
        public IActionResult Create(int idTicket)
        {
            ViewBag.IdTicket = idTicket;
            return View();
        }

        // POST: Guardar seguimiento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int idTicket, string comentario)
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");

            if (idUsuario == null)
            {
                TempData["Error"] = "Debe iniciar sesión.";
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrWhiteSpace(comentario))
            {
                TempData["Error"] = "El comentario es obligatorio.";
                ViewBag.IdTicket = idTicket;
                return View();
            }

            var seguimiento = new Seguimiento
            {
                IdTicket = idTicket,
                IdUsuario = idUsuario.Value,
                Fecha = DateTime.Now,
                Comentario = comentario
            };

            _context.Seguimientos.Add(seguimiento);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Comentario guardado correctamente.";
            return RedirectToAction("Index", "Home");
        }
    }
}