using OdeToFood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Persistance
{
    public interface IResturantData
    {
        IEnumerable<Resturants> GetAllResturants();
        IEnumerable<Resturants> GetResturantByName(string name);
        Resturants GetResturantByID(int id);
    }

    public class InMemoryResturantData : IResturantData
    {
        readonly List<Resturants> resturantsList;
        public InMemoryResturantData()
        {
            resturantsList = new List<Resturants>()
            {
                new Resturants(){Id = 1 ,Name="Al monofy",Location="6 th of october city",Cusine = CusineType.Egyptian},
                new Resturants(){Id = 2 ,Name="Fish Market",Location="6 th of october city",Cusine = CusineType.Egyptian},
                new Resturants(){Id = 3 ,Name="Sizziler",Location="6 th of october city",Cusine = CusineType.Italian}

        };
        }
        public IEnumerable<Resturants> GetAllResturants()
        {
            return resturantsList;
            
        }

        public IEnumerable<Resturants> GetResturantByName(string name = null)
        {
            return from r in resturantsList
                   where string.IsNullOrEmpty(name)  || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Resturants GetResturantByID(int resturantId)
        {
            return resturantsList.SingleOrDefault(r => r.Id == resturantId);
        }
    }
}
