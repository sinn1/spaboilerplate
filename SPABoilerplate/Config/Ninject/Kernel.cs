using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace SPABoilerplate.Config.Ninject
{
    public static class Kernel
    {
        private static KernelBase _instance;
        public static KernelBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Ninject Kernel Instance has not been set");
                }
                return _instance;
            }
            set
            {
                if (_instance != null)
                {
                    throw new Exception("Ninject Kernel Instance has already been set");
                }
                _instance = value;
            }
        }
    }
}