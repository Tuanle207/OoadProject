using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IParameterService : IBaseService
    {
        Parameter GetParameterByName(string nameParameter);
        IEnumerable<Parameter> GetParameters();
        bool UpdateParameterByName(string nameParameter, int value);
    }
}