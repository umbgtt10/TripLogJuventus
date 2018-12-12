﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel()
        {

        }

        public abstract void Init();
        public abstract void Init(TripLogEntry entry);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
