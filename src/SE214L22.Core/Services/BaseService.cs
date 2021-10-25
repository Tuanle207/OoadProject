using AutoMapper;
using SE214L22.Contract.Services;

namespace SE214L22.Core.Services
{
    public abstract class BaseService : IBaseService
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
