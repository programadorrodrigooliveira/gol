using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Database.Model;

namespace RegrasNegocio
{
    public class AirplanesRN: Base<Domain.Airplanes>
    {
        private static ICollection<Domain.Airplanes> avioes = new HashSet<Domain.Airplanes>
        {
            new Domain.Airplanes
            {
                Criacao = DateTime.Now.AddDays(-3),
                Id = 1,
                Modelo = "Boeing 767",
                Passageiros = 300
            },
            new Domain.Airplanes
            {
                Criacao = DateTime.Now.AddDays(-2),
                Id = 2,
                Modelo = "Boeing 757",
                Passageiros = 200
            },
            new Domain.Airplanes
            {
                Criacao = DateTime.Now.AddDays(-1),
                Id = 3,
                Modelo = "Boeing 747",
                Passageiros = 150
            },
        };


        public override ICollection<Domain.Airplanes> Listar()
        {
            //return avioes;
            var retorno = new HashSet<Domain.Airplanes>();
            var airplanes = Globais.Controles.Airplanes.Listar();

            foreach (var airplane in airplanes)
            {
                var itemRetorno = new Domain.Airplanes();
                Converter(ref itemRetorno, airplane);

                retorno.Add(itemRetorno);
            }

            return retorno;
        }

        public override bool Gravar(ref Domain.Airplanes model)
        {
            var objeto = new Database.Model.Airplanes();

            ConverterParaTabela(ref objeto, model);

            return Globais.Controles.Airplanes.Gravar(ref objeto);
            //var id = model.Id;
            //if (model.Id == 0)
            //{
            //    model.Id = avioes.Max(a => a.Id) + 1;
            //    avioes.Add(model);
            //}
            //else
            //{
            //    var aviao = avioes.First(a => a.Id == id);
            //    aviao.Modelo = model.Modelo;
            //    aviao.Passageiros = model.Passageiros;
            //}

            //return true;
        }

        public override bool Excluir(int id)
        {
            return Globais.Controles.Airplanes.Excluir(id);
        }
    }
}
