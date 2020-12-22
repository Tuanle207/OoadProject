using OoadProject.Data.Entity.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class ParameterRepository : BaseRepository<Parameter>
    {
        public IEnumerable<Parameter> GetParameters()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Parameters.ToList();
            }
        }

        public Parameter GetParameterByName( string nameParameter)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Parameters.Where(p=> p.Key == nameParameter).FirstOrDefault();
            }
        }

    }
}
