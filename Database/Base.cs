using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class Base<T> where T : class
    {
        protected GolContext Contexto { get; set; }

        public virtual ICollection<T> Listar()
        {
            try
            {
                Contexto = new GolContext();

                return Contexto.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Contexto.Dispose();
            }
        }

        public virtual bool Gravar(ref T objeto)
        {
            try
            {
                var model = objeto as Airplanes;
                var id = (long)objeto.GetType().GetProperty("Id").GetValue(objeto);

                Contexto = new GolContext();

                if (id == 0)
                {
                    Contexto.Set<T>().Add(objeto);
                }
                else
                {
                    var atual = Contexto.Set<T>().Find(id);
                    //var atual = (from c in Contexto.Airplanes
                    //            where c.Id == id
                    //            select c).First();

                    foreach (var property in atual.GetType().GetProperties())
                    {
                        try
                        {
                            property.SetValue(atual, objeto.GetType().GetProperty(property.Name).GetValue(objeto));
                        }
                        catch (Exception e)
                        {
                            var erro = e.Message;
                        }
                    }

                    //atual.Modelo = model.Modelo;
                    //atual.Passageiros = model.Passageiros;
                }

                Contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Contexto.Dispose();
            }
        }

        public virtual bool Excluir(long id)
        {
            try
            {
                Contexto = new GolContext();

                var atual = Contexto.Set<T>().Find(id);

                Contexto.Set<T>().Remove(atual);

                Contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Contexto.Dispose();
            }
        }
    }
}
