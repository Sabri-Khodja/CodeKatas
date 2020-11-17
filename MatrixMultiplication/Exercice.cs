using System.Collections;

namespace MatrixMultiplication
{
    // TODO: optimize this class
    //multi dimensional array implementation
    public class Matrix : IEnumerable
    {
        private int[,] _data;

        public int Rows { get { return _data.GetLength(0); } }
        public int Columns { get { return _data.GetLength(1); } }

        public int this[int row, int col]
        {
            get { return _data[row, col]; }
            set { _data[row, col] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public Matrix(int[,] value)
        {
            _data = value;
        }
    }

    //Jaded array implementation
    public class MatrixOptimized1 : IEnumerable
    {
        private int[][] _data;

        public int Rows { get { return _data.GetLength(0); } }
        public int Columns { get { return _data[0].GetLength(0); } }

        public int this[int row, int col]
        {
            get { return _data[row][col]; }
            set { _data[row][col] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public MatrixOptimized1(int[][] value)
        {
            _data = value;
        }
    }

    //Flattened array implementation
    public class MatrixOptimized2 : IEnumerable
    {
        private int[] _data;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public int this[int row, int col]
        {
            get { return _data[row * Columns + col]; }
            set { _data[row * Columns + col] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public MatrixOptimized2(int[] value, int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _data = value;
        }
    }

    public class Exercise
    {
        public static Matrix Multiply(Matrix a, Matrix b)
        {
            var result = new Matrix(new int[a.Rows, b.Columns]);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += (a[i, k] * b[k, j]);
                }
            }
            return result;
        }

        public static MatrixOptimized1 Multiply(MatrixOptimized1 a, MatrixOptimized1 b)
        {
            var arrayResult = new int[a.Rows][];
            for (int i = 0; i < a.Rows; i++)
            {
                arrayResult[i] = new int[b.Columns];
            }

            var result = new MatrixOptimized1(arrayResult);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += (a[i, k] * b[k, j]);
                }
            }
            return result;
        }

        public static MatrixOptimized2 Multiply(MatrixOptimized2 a, MatrixOptimized2 b)
        {
            var result = new MatrixOptimized2(new int[a.Rows * b.Columns], a.Rows, b.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += (a[i, k] * b[k, j]);
                }
            }
            return result;
        }
    }
}