using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Deserealize
    {
        public static T DeserealizeOdject<T>()
        {
            //Выбор файла для десериализации 
            OpenFileDialog dialog = new OpenFileDialog();

            //Если все хорошо, то проходит чтение и десериализация файла
            if (dialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }

            //Иначе, возвращается значение типа данных по умолчанию
            else
            {
                return default(T);
            }
        }
    }
}
