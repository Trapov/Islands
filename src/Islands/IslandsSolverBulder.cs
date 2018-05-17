using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Islands
{
    public class IslandsSolverBulder
    {
        private int[,] _array;

        public IslandsSolverBulder SetArray(int[,] array)
        {
            _array = array;
            return this;
        }

        public IslandsSolver Build() => new IslandsSolver(_array);
    }

    public class IslandsSolver
    {
        private readonly ObjectGraph _objectGraph = new ObjectGraph();
        private readonly int[,] _array;
        private readonly (int rowsNumber, int columnsNuber) _lengths;

        public IslandsSolver(int[,] array)
        {
            _array = array;
            _lengths = (_array.GetLength(0), _array.GetLength(1));
        }

        /// <summary>
        /// Returns the number of graphs; CA -> O(n^5)
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {
            for (var i = 0; i < _lengths.rowsNumber; i++)
            {
                for (var j = 0; j < _lengths.columnsNuber; j++)
                {
                    if (_array[i, j] != 1) continue;
                    _objectGraph.SearchIntersectAndAppend(GetNeighbors(i, j).ToArray(),
                        new Index(row: i, column: j));
                }
            }

            return _objectGraph.Count;

            #region parrallel

            //Task.Run(() => Parallel.For(0, _lengths.rowsNumber, i => {

            //    for (var j = 0; j < _lengths.columnsNuber; j++)
            //    {
            //        if (_array[i, j] != 1) continue;
            //        _objectGraph.SearchIntersectAndAppend(GetNeighbors(i, j).ToArray(),
            //            new Index(row: i, column: j));
            //    }

            //})).GetAwaiter().GetResult();
            //return _objectGraph.Count;

            #endregion
        }

        /// <summary>
        /// Gets 8 neighbors of the cell, CA -> O(n^2)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private IEnumerable<Index> GetNeighbors(int row, int column)
        {
            for (var rw = row > 0 ? row - 1 : row; rw <= (row < _lengths.rowsNumber - 1 ? row + 1 : row); rw++)
            {
                for (var clmn = column > 0 ? column - 1 : column;
                    clmn <= (column < _lengths.columnsNuber - 1 ? column + 1 : column);
                    clmn++)
                {
                    if (rw != row || clmn != column)
                    {
                        yield return new Index(row: rw, column: clmn);
                    }
                }
            }
        }
    }

    #region Entities

    public class ObjectGraph : ConcurrentDictionary<Index[], int>
    {
        /// <summary>
        /// Searches thru all keys for the intersection with the supplied index
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="index"></param>
        public void SearchIntersectAndAppend(Index[] indexes, Index index)
        {
            if (!Keys.Any())
            {
                TryAdd(indexes, 1);
                return;
            }

            // if the given index does exist in any of the graphs then append it neighbors to that graph
            var indexToDelete = Keys.FirstOrDefault(keys => keys.Contains(index));
            if (indexToDelete != null)
            {
                TryGetValue(indexToDelete, out var prevValue);

                var newIndex = indexes
                    .Except(indexToDelete)
                    .Concat(indexToDelete)
                    .ToArray();

                //Remove old indexes
                TryRemove(indexToDelete, out var _);
                TryAdd(newIndex, prevValue + 1);
            }
            else
            {
                TryAdd(indexes, 1);
            }
        }
    }

    public struct Index
    {
        public Index(int row, int column) : this()
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }

    #endregion
}