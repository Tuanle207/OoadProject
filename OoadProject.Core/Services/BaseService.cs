using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services
{
    public class BaseService
    {
        protected IMapper _mapper;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = AutoMapper.Config.CreateMapper();
                }
                return _mapper;
            }
        }
    }
}
