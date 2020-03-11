using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorAppSegundoParcial.Data;
using BlazorAppSegundoParcial.Models;

namespace BlazorAppSegundoParcial.Controllers
{
    public class LlamadasControllers
    {

        public bool Guardar(Llamadas llamadas)
        {
            Contexto contexto = new Contexto();
            bool paso = true;
            try
            {
                if(llamadas.LlamadasId == 0)
                {
                    Insertar(llamadas);
                } else if(Buscar(llamadas.LlamadasId)==null)
                {
                    paso = false;
                }
                else
                {
                    Modificar(llamadas);
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public bool Insertar(Llamadas Llamadas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Add(Llamadas);
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            return paso;
        }

        public bool Modificar(Llamadas Llamadas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var anterior = Buscar(Llamadas.LlamadasId);

                foreach (var item in Llamadas.LlamadasDetalles)
                {
                    if (item.LlamadaDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                }

                foreach (var item in anterior.LlamadasDetalles)
                {
                   if(!Llamadas.LlamadasDetalles.Any(A=>A.LlamadaDetalleId == item.LlamadaDetalleId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                contexto.Entry(Llamadas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;


            }
            catch
            {
                throw;
            }
            return paso;

        }


        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Llamadas llamadas = contexto.Llamadas.Find(id);
                if (llamadas != null)
                {
                    contexto.Entry(llamadas).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;
            }
            return paso;
        }


        public Llamadas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Llamadas llamadas = new Llamadas();

            try
            {
                llamadas = contexto.Llamadas.Where(A => A.LlamadasId == id).Include(A => A.LlamadasDetalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return llamadas;
        }


        public List<Llamadas> GetList(Expression<Func<Llamadas,bool>> expression)
        {
            List<Llamadas> lista = new List<Llamadas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Llamadas.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
