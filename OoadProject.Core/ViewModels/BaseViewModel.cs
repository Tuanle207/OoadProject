﻿
using AutoMapper;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OoadProject.Core.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property = null, string value = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

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
