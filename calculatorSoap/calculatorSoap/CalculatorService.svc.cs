﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace calculatorSoap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalculatorService.svc or CalculatorService.svc.cs at the Solution Explorer and start debugging.
    public class CalculatorService : ICalculatorService
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiplier(double a, double b)
        {
            return a * b;
        }

        public double Division(double a, double b)
        {
            return a / b;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
