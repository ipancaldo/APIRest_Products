using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    interface IABMLogic<T>
    {
        /// <summary>
        /// Retorna todos los elementos de la base de datos.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Retorna un objeto en base al ID que se le pase.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetData(int id);

        /// <summary>
        /// Devuelve último ID de la lista. Será utilizado con un +1 para no generar conflictos al generar un nuevo producto.
        /// </summary>
        /// <returns></returns>
        int GetLastID();

        void Add(T newObject);

        void Update(T objectSelected);

        void Delete(int id);
    }
}
