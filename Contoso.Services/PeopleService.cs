using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;
using Contoso.Data;

namespace Contoso.Services
{
    public class PeopleService
    {
        //private object repo;

        PeopleRepository pplrepo;
        public PeopleService()
        {
            pplrepo = new PeopleRepository();
        }
        public People GetPeopleByID(int id)
        {
            return pplrepo.GetPeopleById(id);
            //Console.WriteLine("Enter the Id: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //People result = pplrepo.GetPeopleById(id);
            //if (result != null)
            //{
            //    Console.WriteLine(result.Id + result.LastName + result.FirstName);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid ID");
            //}
        }

        public IEnumerable<People> GetPeople()
        {
            return pplrepo.GetAllPeople();
        }

        public People GetPeopleByCity(string city)
        {
            return pplrepo.GetPeopleByCity(city);
        }

        public void AddPeople(People people)
        {
            pplrepo.Create(people);
        }
    }



  
}
