using System;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    public static class ListTExtensions
    {
        #region Methods

        public static bool TryFind<T>(this List<T> list, Predicate<T> predicate, out T element)
        {
            int elementIndex = list.FindIndex(predicate);
            if (elementIndex != -1)
            {
                element = list[elementIndex];
                return true;
            }
            else
            {
                element = default(T);
                return false;
            }
        }
    }

    #endregion Methods
}
