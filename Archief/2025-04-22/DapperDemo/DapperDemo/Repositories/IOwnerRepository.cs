using DapperDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repositories
{
    internal interface IOwnerRepository
    {
        void Create(Owner owner);
        Owner GetById(int id);
        Owner GetByIdIncludePets(int id);
        List<Owner> GetAll();
    }
}
