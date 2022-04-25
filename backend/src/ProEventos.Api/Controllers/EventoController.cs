using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Api.Data;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _context;

        public EventoController(DataContext context)
        {
            this._context = context;
            
        }
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _context.Eventos;
        }

        [HttpGet("{id:int}")]
        public Evento Get(int id)
        {
           return _context.Eventos
                    .FirstOrDefault(x => x.EventoId == id);
        }
    }
}
