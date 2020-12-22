using OoadProject.Data.Entity.Others;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class ParameterService: BaseService
    {
        private readonly ParameterRepository _parameterRepository;

        public ParameterService()
        {
            _parameterRepository = new ParameterRepository();
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
