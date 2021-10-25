using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        public IEnumerable<Parameter> GetParameters()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Parameters.ToList();
            }
        }

        public Parameter GetParameterByName(string nameParameter)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Parameters.Where(p => p.Key == nameParameter).FirstOrDefault();
            }
        }

    }
}
