using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasNegocio
{
    public class Base<TDominio>
    {
        public virtual ICollection<TDominio> Listar()
        {
            return new HashSet<TDominio>();
        }

        public virtual TDominio Novo()
        {
            return Activator.CreateInstance<TDominio>();
        }

        public virtual bool Gravar(ref TDominio model)
        {
            return true;
        }

        public virtual bool Excluir(TDominio model)
        {
            return true;
        }

        public virtual bool Excluir(int id)
        {
            return true;
        }

        protected void Converter<TTabela>(ref TDominio dominio, TTabela tabela)
        {
            foreach (var property in dominio.GetType().GetProperties())
            {
                property.SetValue(dominio, tabela.GetType().GetProperty(property.Name).GetValue(tabela));
            }
        }

        protected void ConverterParaTabela<TTabela>(ref TTabela tabela, TDominio dominio)
        {
            foreach (var property in tabela.GetType().GetProperties())
            {
                property.SetValue(tabela, dominio.GetType().GetProperty(property.Name).GetValue(dominio));
            }
        }
    }
}
