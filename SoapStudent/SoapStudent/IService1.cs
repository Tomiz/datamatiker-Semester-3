using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapStudent
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Add(Student student);

        [OperationContract]
        void Update(Student student);

        [OperationContract]
        void Delete(Student student);

        [OperationContract]
        Student GetDataUsingDataContract(Student composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private int _id;

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
