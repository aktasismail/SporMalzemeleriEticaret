using DataAccessLayer;
using Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BussinessLayer
{
    public class MarkaManager
    {
        EntityConnection connection = new EntityConnection();
        public List<Marka> GetAll()
        {
            return connection.Markalar.ToList();
        }
        public Marka Get(int Id)
        {
            return connection.Markalar.Find(Id);
        }
        public int Add(Marka marka)
        {
            connection.Markalar.Add(marka);
            return connection.SaveChanges();
        }public int Update(Marka marka)
        {
            connection.Markalar.AddOrUpdate(marka);
            return connection.SaveChanges();
        }
        public int Delete(int id)
        {
            connection.Markalar.Remove(Get(id));
            return connection.SaveChanges();
        }

    }
}
















