using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioAviones
    {
        List<Aviones> aviones;
        private readonly AppContext _appContext = new AppContext();
 
    public IEnumerable<Aviones> GetAll()
    {
       return _appContext.Aviones;
    }
 
    public Aviones GetAvionWithId(int id){
        return _appContext.Aviones.Find(id);
    }

    public Aviones Create(Aviones newAvion)
        {
           var addAvion = _appContext.Aviones.Add(newAvion);
            _appContext.SaveChanges();
            return addAvion.Entity;
        }

    public void Delete(int id)
        {
        var avion = _appContext.Aviones.Find(id);
        if (avion == null)
            return;
        _appContext.Aviones.Remove(avion);
        _appContext.SaveChanges();
        }

    public Aviones Update(Aviones newAvion){
            var avion = _appContext.Aviones.Find(newAvion.id);
            if(avion != null){
                avion.marca = newAvion.marca;
                avion.modelo = newAvion.modelo;
                avion.numero_banos = newAvion.numero_banos;
                avion.numero_asientos = newAvion.numero_asientos;
                avion.capacidad_max_peso = newAvion.capacidad_max_peso;
                _appContext.SaveChanges();
            }
        return avion;
        }
    }
}