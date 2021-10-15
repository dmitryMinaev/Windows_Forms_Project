using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Users
{
    class FormatUserString
    {
        private int _maxLenghtName;
        private int _maxLenghtSurname;
        private int _maxLenghtSpecialty;

        public FormatUserString() {}

        public void NewMaxLenght(List<InformationUser> listUsers)
        {
            _maxLenghtName = _maxLenghtSpecialty = _maxLenghtSurname = int.MinValue;

            foreach (var user in listUsers)
            {
                _maxLenghtName = _maxLenghtName > user.Name.Length ? _maxLenghtName : user.Name.Length;
                _maxLenghtSurname = _maxLenghtSurname > user.Surname.Length ? _maxLenghtSurname : user.Surname.Length;
                _maxLenghtSpecialty = _maxLenghtSpecialty > user.Specialty.Length ? _maxLenghtSpecialty : user.Specialty.Length;
            }
        }

        public string FormatUserLineListBox(InformationUser user)
        {
            return user.Name + string.Concat(Enumerable.Repeat(" ", _maxLenghtName - user.Name.Length)) + "\t" +
                   user.Surname + string.Concat(Enumerable.Repeat(" ", _maxLenghtSurname + 3 - user.Surname.Length)) + "\t" +
                   user.Age + "\t" +
                   user.Specialty + string.Concat(Enumerable.Repeat(" ", _maxLenghtSpecialty + 8 - user.Specialty.Length)) + "\t" +
                   user.WorkExperience + "\n";
        }

        public string FormatUserLineFile(InformationUser user)
        {
            return "Name:" + user.Name + string.Concat(Enumerable.Repeat(' ', _maxLenghtName - user.Name.Length)) + " " +
                   "Surname:" + user.Surname + string.Concat(Enumerable.Repeat(' ', _maxLenghtSurname - user.Surname.Length)) + " " +
                   "Age:" + user.Age + " " +
                   "Specialty:" + user.Specialty + string.Concat(Enumerable.Repeat(' ', _maxLenghtSpecialty - user.Specialty.Length)) + " " +
                   "Work experience:" + user.WorkExperience;
        }
    }
}
