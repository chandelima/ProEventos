using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _eventos = new Evento[] {
            new Evento() {
                   EventoId = 1,
                   Tema = "Angular 11 e .NET 5",
                   Local = "Belo Horizonte",
                   Lote = "1º Lote",
                   QtdPessoas = 250,
                   DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                   ImagemUrl = "foto1.png"
            },
            new Evento() {
                EventoId = 2,
                Tema = "Angular e suas novidades",
                Local = "São Paulo",
                Lote = "2º Lote",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "foto2.png"
            },
        };
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _eventos;
        }

        [HttpGet("{id:int}")]
        public Evento Get(int id)
        {
           return _eventos
                    .Where(x => x.EventoId == id)
                    .FirstOrDefault();
        }
    }
}
