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
            //return resturantsList;
            return from r in resturantsList
                   orderby r.Name
                   select r;
        }
    }
}
