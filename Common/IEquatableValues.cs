using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommLibrary
{
    /// <summary>Поддерживает сравнение экземпляров по значению</summary>
    /// <typeparam name="T">Тип экземпляра</typeparam>
    interface IEquatableValues<in T>
    {
        /// <summary>Метод сравнивающий значения</summary>
        /// <param name="other">Другой экземпляр с чьими значениями происходит сравнение</param>
        /// <returns></returns>
        bool EqualValues(T other);
    }
}
