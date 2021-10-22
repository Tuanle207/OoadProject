using SE214L22.Data.Entity.Others;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface IParameterService : IBaseService
    {
        Parameter GetParameterByName(string nameParameter);
        IEnumerable<Parameter> GetParameters();
        bool UpdateParameterByName(string nameParameter, int value);
    }
}