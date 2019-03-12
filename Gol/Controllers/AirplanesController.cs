using Domain;
using Microsoft.AspNetCore.Mvc;
using RegrasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gol.Controllers
{
    [Route("api/Airplanes")]
    public class AirplanesController : Controller
    {
        //private static ICollection<Airplanes> avioes = new HashSet<Airplanes>
        //{
        //    new Airplanes
        //    {
        //        Criacao = DateTime.Now.AddDays(-3),
        //        Id = 1,
        //        Modelo = "Boeing 767",
        //        Passageiros = 300
        //    },
        //    new Airplanes
        //    {
        //        Criacao = DateTime.Now.AddDays(-2),
        //        Id = 2,
        //        Modelo = "Boeing 757",
        //        Passageiros = 200
        //    },
        //    new Airplanes
        //    {
        //        Criacao = DateTime.Now.AddDays(-1),
        //        Id = 3,
        //        Modelo = "Boeing 747",
        //        Passageiros = 150
        //    },
        //};

        private static AirplanesRN regra = new AirplanesRN();

        [HttpGet("Listar")]
        public ICollection<Airplanes> Listar()
        {
            return regra.Listar();
        }

        [HttpPost("Gravar")]
        public void Gravar([FromBody] Aviao model)
        {
            var aviao = new Airplanes
            {
                Id = model.Id,
                Modelo = model.Modelo,
                Passageiros = model.Passageiros,
                Criacao = DateTime.Now,
            };

            regra.Gravar(ref aviao);
            //if (model.Id == 0)
            //{
            //    avioes.Add(new Airplanes
            //    {
            //        Id = avioes.Max(a => a.Id) + 1,
            //        Modelo = model.Modelo,
            //        Passageiros = model.Passageiros,
            //        Criacao = DateTime.Now,
            //    });
            //}
            //else
            //{
            //    var aviao = avioes.First(a => a.Id == model.Id);
            //    aviao.Modelo = model.Modelo;
            //    aviao.Passageiros = model.Passageiros;
            //}
        }

        [HttpDelete("Excluir/{id}")]
        public void Excluir(int id)
        {
            regra.Excluir(id);
            //avioes.Remove(avioes.First(a => a.Id == id));
        }

        public class Aviao
        {
            public int Id { get; set; }
            public string Modelo { get; set; }
            public int Passageiros { get; set; }
        }
    }
}
