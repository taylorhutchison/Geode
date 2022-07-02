﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Exceptions
{
    public class MultipleGeometriesException: Exception
    {
        public MultipleGeometriesException():base() { }
        public MultipleGeometriesException(string message) : base(message)
        {

        }
        public MultipleGeometriesException(string message, Exception ex):base(message,ex)
        {

        }

    }
}
