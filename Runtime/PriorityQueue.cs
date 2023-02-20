using System;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    // Original Source: https://www.redblobgames.com/pathfinding/a-star/implementation.html#csharp

    // When I wrote this code in 2015, C# didn't have a PriorityQueue<> class. It was added in 2020;
    // see https://github.com/dotnet/runtime/issues/14032
    //
    // This is a placeholder PriorityQueue<> that runs inefficiently but will allow you to run the
    // sample code on older C# implementations.
    //
    // If you're using a version of C# that doesn't have PriorityQueue<>, consider using one of
    // these fast libraries instead of my slow placeholder:
    //
    // * https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
    // * https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    // * http://xfleury.github.io/graphsearch.html
    // * http://stackoverflow.com/questions/102398/priority-queue-in-net
    public class PriorityQueue<TElement, TPriority>
    {
        #region Fields

        private readonly List<Tuple<TElement, TPriority>> _elements = new List<Tuple<TElement, TPriority>>();

        #endregion Fields

        #region Properties

        public int Count
        {
            get { return _elements.Count; }
        }

        #endregion Properties

        #region Methods

        public TElement Dequeue()
        {
            Comparer<TPriority> comparer = Comparer<TPriority>.Default;
            int bestIndex = 0;

            for (int i = 0; i < _elements.Count; i++)
            {
                if (comparer.Compare(_elements[i].Item2, _elements[bestIndex].Item2) < 0)
                {
                    bestIndex = i;
                }
            }

            TElement bestItem = _elements[bestIndex].Item1;
            _elements.RemoveAt(bestIndex);
            return bestItem;
        }

        public void Enqueue(TElement item, TPriority priority)
        {
            _elements.Add(Tuple.Create(item, priority));
        }

        #endregion Methods
    }
}
