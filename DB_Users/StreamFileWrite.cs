using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DB_Users
{
    class StreamFileWrite : IDisposable
    {
        string _pathFile;
        private StreamWriter _streamWrite;

        public StreamFileWrite()
        {
            _pathFile = @"baseInfo.txt";
            _streamWrite = null;

            try
            {
                _streamWrite = new StreamWriter(_pathFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public StreamFileWrite(string pathFile)
        {
            _pathFile = pathFile;
            _streamWrite = null;

            try
            {
                using (FileStream file = new FileStream(_pathFile, FileMode.Truncate))
                {
                    _streamWrite = new StreamWriter(file);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void writeFileAsync(List<InformationUser> listUsers, FormatUserString format)
        {
            foreach (var user in listUsers)
                _streamWrite.WriteLine(format.FormatUserLineFile(user));
        }

        public void Dispose() => _streamWrite?.Close();
    }
}
