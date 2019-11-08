using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class PeopleRepository
    {
        public People GetPeopleById(int id)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.People.Where(d => d.Id == id).FirstOrDefault();

            }
        }

        public IEnumerable<People> GetAllPeople()
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.People.ToList();
            }
        }

        public People GetPeopleByCity(string City)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.People.Where(d => d.City == City).Single();
            }
        }

        public void Create(People people)
        {
            using (var db = new ContosoDataDbContext())
            {
                db.People.Add(people);
                db.SaveChanges();
            }
        }
    }
}
