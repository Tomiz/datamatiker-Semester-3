using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MockExam_Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // properties servicen bruger 
        [OperationContract]
        double Celcius(double c);

        [OperationContract]
        double Fehrenheit(double f);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "MockExam_Soap.ContractType".
    [DataContract]
    public class CompositeType
    {
        //Data type den bruger
        private double _celcius;
        private double _fehrenheit;

        [DataMember]
        public double Celcius
        {
            get { return _celcius; }
            set { _celcius = value; }
        }

        [DataMember]
        public double Fehrenheit
        {
            get { return _fehrenheit; }
            set { _fehrenheit = value; }
        }
    }
}
