using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.DAL;
public class RepositorioVales : IRepositorio<Vale>
{
    private string dbName = "Inventario.db";
    private string tableName = "Empleados";

    public List<Vale> Read
    {
        get
        {
            List<Vale> datos = new();
            using(var db = new LiteDatabase(dbName))
            {
                datos = db.GetCollection<Vale>(tableName).FindAll().ToList();
            }

            return datos;
        }
    }

    public bool Create(Vale entidad)
    {
        entidad.Id = Guid.NewGuid().ToString();

        try
        {

            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Vale>(tableName);
                coleccion.Insert(entidad);
            }

            return true;
           
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(string id)
    {
        try
        {

            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Vale>(tableName);
                coleccion.Delete(id);
            }

            return true;

        }
        catch (Exception)
        {
            return false;
        }

    }

    public bool Update(Vale entidadModificada)
    {
        try
        {

            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Vale>(tableName);
                coleccion.Update(entidadModificada);
            }

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }
}
