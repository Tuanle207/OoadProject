using SE214L22.Core.Interfaces.Services;
using SE214L22.Data.Entity.Others;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class ParameterService : BaseService, IParameterService
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public IEnumerable<Parameter> GetParameters()
        {
            return _parameterRepository.GetParameters();
        }
        public Parameter GetParameterByName(string nameParameter)
        {
            return _parameterRepository.GetParameterByName(nameParameter);
        }
        public bool UpdateParameterByName(string nameParameter, int value)
        {
            var editingParameter = GetParameterByName(nameParameter);
            editingParameter.Value = value;
            return _parameterRepository.Update(editingParameter);

        }
    }
}
