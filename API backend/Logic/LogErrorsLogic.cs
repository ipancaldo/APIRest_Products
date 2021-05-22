using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    public class LogErrorsLogic
    {
        /// <summary>
        /// Almacena el error en un archivo .TXT en el D:/
        /// </summary>
        /// <param name="error"></param>
        public void LogError(string error)
        {
            TextWriter txt = null;
            StringBuilder errorConcatenado = new StringBuilder();
            errorConcatenado.AppendLine("Time:            " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            errorConcatenado.AppendLine("Error message:   " + error);

            string curFile = "D:\\ErrorsMVC" + ".txt";

            if (System.IO.File.Exists(curFile))
            {
                txt = new StreamWriter(curFile, append: true);
            }
            else
            {
                txt = new StreamWriter(curFile);
            }

            txt.WriteLine(errorConcatenado);
            txt.Close();
        }
    }
}
