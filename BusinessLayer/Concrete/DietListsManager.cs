using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DietListsManager
    {
        Repository<DietList> repository = new Repository<DietList>();
        
        public List<DietList> GetAllLists()
        {
            return repository.List().ToList();
        }

        public DietList GetDietListByID(int id)
        {
            DietList dietlist = repository.Find(x=>x.DietListId == id);
            return dietlist;
        }
        public int Update(DietList dietlist)
        {
            return repository.Update(dietlist);
        }
    }
}
