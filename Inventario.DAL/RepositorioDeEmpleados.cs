using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;

namespace Inventario.DAL;

public class RepositorioDeEmpleados : IRepositorio<Empleado>
{
    private string dbName = "Inventario.db";
    private string tableName = "Empleados";

    public delegate void CRUDdelegate(LiteDatabase db);

    public List<Empleado> Read
    {
        get
        {
            List<Empleado> datos = new();
            using (var db = new LiteDatabase(dbName)) // if already exists then it only opens the db
            {
                datos = db.GetCollection<Empleado>(tableName).FindAll().ToList();
            }

            return datos;
        }
    }

    // old full methods for CUD
    public bool Create(Empleado entidad)
    {
        entidad.Id = Guid.NewGuid().ToString(); // guid generates an aleatory 37 digits number

        try
        {
            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Empleado>(tableName);
                coleccion.Insert(entidad);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool Update(Empleado entidadModificada)
    {
        try
        {
            using (var db = new LiteDatabase(dbName))
            {
                var coleccion = db.GetCollection<Empleado>(tableName);
                coleccion.Update(entidadModificada);
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
                var coleccion = db.GetCollection<Empleado>(tableName);
                coleccion.Delete(new BsonValue(id));
                //r = coleccion.Delete(e => e.Id == id); // this was for many 
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    /// <summary>
    /// Method that represents Create, Update and Delete operations
    /// </summary>
    /// <param name="execute">A delegate to perform the desired task could be any CUD</param>
    /// <returns></returns>
    public bool CudOperation(CRUDdelegate execute)
    {
        try
        {
            using (var db = new LiteDatabase(dbName))
            {
                execute?.Invoke(db);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}