using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Users
{
    class StreamFileRead : IDisposable
    {
        string _pathFile;
        int _countLine;
        StreamReader _streamRead;

        public int CountLine { get => _countLine; }

        public StreamFileRead()
        {
            _pathFile = "baseInfo.txt";
            _countLine = 0;
            _streamRead = null;

            try
            {
                _streamRead = new StreamReader(_pathFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<InformationUser>> readFileAsync()
        {
            List<InformationUser> listUsers = null;

            if (_streamRead != null)
            {
                try
                {
                    if (_streamRead.BaseStream.Length == 0)
                        throw new FileEmptyException();

                    string allFile = await _streamRead.ReadToEndAsync().ConfigureAwait(false);
                    _countLine += allFile.Where((l) => l == '\n').Count();
                    _streamRead.BaseStream.Seek(0, SeekOrigin.Begin);

                    InformationUser user = new InformationUser();
                    listUsers = new List<InformationUser>();

                    for (int i = 0; i < _countLine; i++)
                    {
                        string line = await _streamRead.ReadLineAsync().ConfigureAwait(false);
                        user.Name = Regex.Replace(Regex.Match(line, @"Name:(.*) Surname:").Groups[1].Value, @"\s+", "");
                        user.Surname = Regex.Replace(Regex.Match(line, @"Surname:(.*) Age:").Groups[1].Value, @"\s+", "");
                        user.Age = Convert.ToInt32(Regex.Replace(Regex.Match(line, @"Age:(.*) Specialty:").Groups[1].Value, @"\s+", ""));
                        user.Specialty = Regex.Replace(Regex.Match(line, @"Specialty:(.*) Work experience:").Groups[1].Value, @"\s+", "");
                        user.WorkExperience = Convert.ToInt32(Regex.Replace(Regex.Match(line, @"Work experience:(.*)").Groups[1].Value, @"\s+", ""));
                        user.isObjectNull = false;

                        listUsers.Add(user);
                        user = new InformationUser();
                    }
                }
                catch (FileEmptyException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return listUsers;
        }

        public void Dispose() => _streamRead?.Close();
    }
}
