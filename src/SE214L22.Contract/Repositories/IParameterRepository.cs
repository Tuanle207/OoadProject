using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IParameterRepository : IBaseRepository<Parameter>
    {
        Parameter GetParameterByName(string nameParameter);
        IEnumerable<Parameter> GetParameters();
    }
}