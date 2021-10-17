using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioRutas
    {
        List<Rutas> rutas;
        private readonly AppContext _appContext = new AppContext();
 
    public IEnumerable<Rutas> GetAll()
    {
      /*   return _appContext.Rutas; */
         return _appContext.Rutas.Include(u => u.origen)
                       .Include(u => u.destino);

    }
 
    public Rutas GetRutaWithId(int id){
        return _appContext.Rutas.Find(id);
    }

    public Rutas Create(int origen, int destino, int tiempo_estimado)
        {
            var newRuta = new Rutas();
            newRuta.destino = _appContext.Aeropuertos.Find(origen);
            newRuta.origen = _appContext.Aeropuertos.Find(destino);          
            newRuta.tiempo_estimado = tiempo_estimado;
           var addRuta = _appContext.Rutas.Add(newRuta);
            _appContext.SaveChanges();
            return addRuta.Entity;
        }

    public void Delete(int id)
        {
        var ruta = _appContext.Rutas.Find(id);
        if (ruta == null)
            return;
        _appContext.Rutas.Remove(ruta);
        _appContext.SaveChanges();
        }

    public Rutas Update(Rutas newRuta){
            var ruta = _appContext.Rutas.Find(newRuta.id);
            if(ruta != null){
                ruta.origen = newRuta.origen;
                ruta.destino = newRuta.destino;
                ruta.tiempo_estimado = newRuta.tiempo_estimado;
                _appContext.SaveChanges();
            }
        return ruta;
        }
    }
}