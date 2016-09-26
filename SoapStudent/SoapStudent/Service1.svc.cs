using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapStudent
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static List<Student> Students = new List<Student>();

        public void GetAll(Student student)
        {
            foreach (var student1 in Students)
            {
                Students.Add(student1);
            }
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }
        public void Update(Student student)
        {
            foreach (Student student1 in Students)
            {
                if (student1.Id == student1.Id)
                {
                    student1.FirstName = student1.FirstName;
                    student1.LastName = student1.LastName;
                }
            }
        }

        public void Delete(Student student)
        {
            foreach (var student1 in Students)
            {
                if (student1.Id == student1.Id)
                {
                    Students.Remove(student);
                }
            }
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public Student GetDataUsingDataContract(Student composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            return composite;
        }
    }
}
