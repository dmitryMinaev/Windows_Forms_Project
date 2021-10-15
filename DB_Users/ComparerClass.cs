using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Users
{
    class ComparerName : IComparer<InformationUser>
    {
        public int Compare(InformationUser user1, InformationUser user2)
        {
            if (user1.Name == user2.Name)
                return 0;

            int i = 0;
            while (true)
            {
                if (user1.Name[i] == user2.Name[i])
                {
                    i++;
                    continue;
                }

                return user1.Name[i] > user2.Name[i] ? 1 : -1;
            }
        }
    }

    class ComparerSurname : IComparer<InformationUser>
    {
        public int Compare(InformationUser user1, InformationUser user2)
        {
            if (user1.Surname == user2.Surname)
                return 0;

            int i = 0;
            while (true)
            {
                if (user1.Surname[i] == user2.Surname[i])
                {
                    i++;
                    continue;
                }

                return user1.Surname[i] > user2.Surname[i] ? 1 : -1;
            }
        }
    }

    class ComparerAge : IComparer<InformationUser>
    {
        public int Compare(InformationUser user1, InformationUser user2)
        {
            if (user1.Age == user2.Age)
                return 0;

            return user1.Age > user2.Age ? 1 : -1;
        }
    }

    class ComparerWorkExperience : IComparer<InformationUser>
    {
        public int Compare(InformationUser user1, InformationUser user2)
        {
            if (user1.WorkExperience == user2.WorkExperience)
                return 0;

            return user1.WorkExperience > user2.WorkExperience ? 1 : -1;
        }
    }
}
