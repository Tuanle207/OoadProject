using SE214L22.Data.Entity.Others;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IParameterRepository : IBaseRepository<Parameter>
    {
        Parameter GetParameterByName(string nameParameter);
        IEnumerable<Parameter> GetParameters();
    }
}