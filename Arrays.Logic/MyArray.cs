﻿namespace Vectors.Logic
{
    public class MyArray
    {
        #region Attributes
        private int _top; // Logic size
        private int[] _array;
        #endregion

        #region Constructors
        public MyArray(int n)
        {
            N = n;
            _array = new int[N];
            _top = 0;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Indicates if the array is full
        /// </summary>
        public bool IsFull => _top == N;

        /// <summary>
        /// Indicates if the array is empty
        /// </summary>
        public bool IsEmpty => _top == 0;

        public int N { get; } // Physical size
        #endregion

        #region Methods
        public void Add(int number)
        {
            if (IsFull)
            {
                throw new Exception("The array is full.");
            }

            _array[_top] = number;
            _top++;
        }

        public void Insert(int number, int position)
        {
            if (IsFull)
            {
                throw new Exception("The array is full.");
            }

            if (position < 0)
            {
                position = 0;
            }

            if (position > _top)
            {
                position = _top;
            }

            for (int i = _top; i > position; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[position] = number;
            _top++;
        }

        public void Remove(int position)
        {
            if (IsEmpty)
            {
                throw new Exception("The array is empty.");
            }

            if (position < 0)
            {
                position = 0;
            }

            if (position > _top)
            {
                position = _top;
            }

            for (int i = position; i < _top - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _top--;
        }

        public void Fill()
        {
            Fill(1, 100);
        }

        public void Fill(int minimun, int maximun)
        {
            Random random = new();
            for (int i = 0; i < N; i++)
            {
                _array[i] = random.Next(minimun, maximun);
            }
            _top = N;
        }

        
        public MyArray GetEven()
        {
            int evenCount = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsEven(_array[i]))
                {
                    evenCount++;
                }
            }

            var evenArray = new MyArray(evenCount);
            for (int i = 0; i < _top; i++)
            {
                if (IsEven(_array[i]))
                {
                    evenArray.Add(_array[i]);
                }
            }

            return evenArray;
        }

        public MyArray GetOdd()
        {
            int oddsCount = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsOdd(_array[i]))
                {
                    oddsCount++;
                }
            }

            var oddArray = new MyArray(oddsCount);
            for (int i = 0; i < _top; i++)
            {
                if (IsOdd(_array[i]))
                {
                    oddArray.Add(_array[i]);
                }
            }

            return oddArray;
        }

        public MyArray GetPrimes()
        {
            int primesCount = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsPrime(_array[i]))
                {
                    primesCount++;
                }
            }

            var primesArray = new MyArray(primesCount);
            for (int i = 0; i < _top; i++)
            {
                if (IsPrime(_array[i]))
                {
                    primesArray.Add(_array[i]);
                }
            }

            return primesArray;

        }

        public MyArray GetNonRepeated()
        {
            int nonRepeatedCount = 0;
            for (int i = 0; i < _top; i++)
            {
                bool isRepeated = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j && _array[i] == _array[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (!isRepeated)
                {
                    nonRepeatedCount++;
                }
            }

            var nonRepeated = new MyArray(nonRepeatedCount);
            for (int i = 0; i < _top; i++)
            {
                bool isRepeated = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j && _array[i] == _array[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (!isRepeated)
                {
                    nonRepeated.Add(_array[i]);
                }
            }
            return nonRepeated;
        }

        public MyArray GetMostRepeated()
        {
            int[,] matrixCount = new int[_top, 2];
            int topMatrix = FillMatrixCount(matrixCount);
            OrderMatrixCount(matrixCount, topMatrix);
            int repeatedCounter = GetRepeatedCounter(matrixCount, topMatrix);
            return FillMostRepeated(repeatedCounter, matrixCount);
        }

        public MyArray InvertedArray()
        {
            var invertedArray = new MyArray(_top);
            for (int i = 0; i < _top; i++)
            {
                invertedArray.Add(_array[_top - i - 1]);
            }
            return invertedArray;
        }

        public int SumArray()
        {
            int sum = 0;
            for (int i = 0; i < _top; i++)
            {
                sum += _array[i];
            }

            return sum;
        }

        public float MeanArray()
        {
            float mean = (float)SumArray() / _top;
            return mean;
        }

        public MyArray FillFibonacciArray()
        {
            var fiboArray = new MyArray(_top);
            int a = 0;
            int b = 1;
            int Aux;
            fiboArray.Add(a);
            fiboArray.Add(b);
            for (int i = 2; i < _top; i++)
            {
                Aux = a;
                a = b;
                b = Aux + a;
                fiboArray.Add(b);
            }

            return fiboArray;
        }

        public void Sort()
        {
            Sort(descending: false);
        }

        public void Sort(bool descending)
        {
            for (int i = 0; i < _top - 1; i++)
            {
                for (int j = i + 1; j < _top; j++)
                {
                    if (descending)
                    {
                        if (_array[i] < _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                    else
                    {
                        if (_array[i] > _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Empty array.";
            }

            string output = string.Empty;
            int count = 0;
            for (int i = 0; i < _top; i++)
            {
                output += $"{_array[i]}\t";
                count++;
                if (count > 9)
                {
                    count = 0;
                    output += "\n";
                }
            }
            return output;
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        private bool IsOdd(int n)
        {
            return n % 2 != 0;
        }

        private bool IsPrime(int n)
        {
            if (n == 1) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void Change(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        private int FillMatrixCount(int[,] matrixCount)
        {
            int topMatrix = 0;
            for (int i = 0; i < _top; i++)
            {
                int j = 0;
                for (; j < topMatrix; j++)
                {
                    if (_array[i] == matrixCount[j, 0])
                    {
                        matrixCount[j, 1]++;
                        break;
                    }
                }
                if (j == topMatrix)
                {
                    matrixCount[topMatrix, 0] = _array[i];
                    matrixCount[topMatrix, 1] = 1;
                    topMatrix++;
                }
            }

            return topMatrix;
        }

        private void OrderMatrixCount(int[,] matrixCount, int topMatrix)
        {
            for (int i = 0; i < topMatrix - 1; i++)
            {
                for (int j = i + 1; j < topMatrix; j++)
                {
                    if (matrixCount[i, 1] < matrixCount[j, 1])
                    {
                        Change(ref matrixCount[i, 0], ref matrixCount[j, 0]);
                        Change(ref matrixCount[i, 1], ref matrixCount[j, 1]);
                    }
                }
            }
        }

        private int GetRepeatedCounter(int[,] matrixCount, int topMatrix)
        {
            int repeatedCounter = 1;
            for (; repeatedCounter < topMatrix; repeatedCounter++)
            {
                if (matrixCount[0, 1] != matrixCount[repeatedCounter, 1])
                {
                    break;
                }
            }
            return repeatedCounter;
        }

        private MyArray FillMostRepeated(int repeatedCounter, int[,] matrixCount)
        {
            var mostRepeated = new MyArray(repeatedCounter);
            for (int i = 0; i < repeatedCounter; i++)
            {
                mostRepeated.Add(matrixCount[i, 0]);
            }
            return mostRepeated;
        }
        #endregion

    }
}