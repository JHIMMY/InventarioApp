using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;

namespace Inventario.DAL;
public class RepositotioMateriales : IRepositorio<Material>
{
    private string dbName = "Inventario.db";
    private string tableName = "Materiales";

    public List<Material> Read
    {
        get
        {
            List < Material > datos = new();
            using(var db = new LiteDatabase(dbName))
            {
                datos = db.GetCollection<Material>(tableName).FindAll().ToList();
            }

            return datos;
        }
    }

    public bool Create(Material entidad)
    {
        entidad.Id = Guid.NewGuid().ToString();

        try
        {
            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Material>(tableName);
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
                var coleccion = db.GetCollection<Material>(tableName);
                coleccion.Delete(id);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(Material entidadModificada)
    {
        try
        {
            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Material>(tableName);
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
