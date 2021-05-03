using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel2._0.Entity
{
    partial class Guest
    {
        public string ArrDate
        {
            get
            {
                string ad = ArrivalDate.ToString();
                ad =ad.Substring(0, 10);
                return ad;
            }
        }
        public string DepDate
        {
            get
            {
                string dd = DepartureDate.ToString();
                dd = dd.Substring(0, 10);
                return dd;
            }
        }
        public string FullName
        {
            get
            {
                return Surname + " " + Name + " " + Patronymic;
            }
        }
    }
    partial class Employers
    {
        public string BirthDate
        {
            get
            {
                string bd = BirthdayDate.ToString();
                bd = bd.Substring(0, 10);
                return bd;
            }
        }
        public string WorkDate
        {
            get
            {
                string bd = WorkingStartDate.ToString();
                bd = bd.Substring(0, 10);
                return bd;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName + " " + Patronymic;
            }
        }

        public string Passport
        {
            get
            {
                return PassportSerial + " " + PassportNumber;
            }
        }
    }
    
}
