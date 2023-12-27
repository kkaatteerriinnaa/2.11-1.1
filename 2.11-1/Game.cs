using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._11_1
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Game
    {
        public event EventHandler BoardChanged;

        private int[,] _board;
        private Random random = new Random();

        public int[,] Board
        {
            get { return _board; }
            private set
            {
                if (_board != value)
                {
                    _board = value;
                    BoardChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Game()
        {
            _board = new int[4, 4];
            GenerateNewTile();
        }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUp();
                    break;
                case MoveDirection.Down:
                    MoveDown();
                    break;
                case MoveDirection.Left:
                    MoveLeft();
                    break;
                case MoveDirection.Right:
                    MoveRight();
                    break;
            }
            GenerateNewTile();
        }

        private void GenerateNewTile()
        {
            while (true)
            {
                int row = random.Next(0, 4);
                int col = random.Next(0, 4);

                if (_board[row, col] == 0)
                {
                    _board[row, col] = random.Next(1, 11) == 1 ? 4 : 2;
                    break;
                }
            }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                SlideRow(i);
                CombineRow(i);
                SlideRow(i);
            }
        }
        private void MoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                SlideRowRight(i);
                CombineRowRight(i);
                SlideRowRight(i);
            }
        }
        private void MoveUp()
        {
            for (int j = 0; j < 4; j++)
            {
                SlideColumn(j);
                CombineColumn(j);
                SlideColumn(j);
            }
        }
        private void MoveDown()
        {
            for (int j = 0; j < 4; j++)
            {
                SlideColumnDown(j);
                CombineColumnDown(j);
                SlideColumnDown(j);
            }
        }
        private void SlideRow(int row)
        {
            int[] tempRow = new int[4];
            int index = 0;

            for (int j = 0; j < 4; j++)
            {
                if (_board[row, j] != 0)
                {
                    tempRow[index] = _board[row, j];
                    index++;
                }
            }

            for (int j = 0; j < 4; j++)
            {
                _board[row, j] = tempRow[j];
            }
        }
        private void SlideRowRight(int row)
        {
            int[] tempRow = new int[4];
            int index = 3;

            for (int j = 3; j >= 0; j--)
            {
                if (_board[row, j] != 0)
                {
                    tempRow[index] = _board[row, j];
                    index--;
                }
            }

            for (int j = 0; j < 4; j++)
            {
                _board[row, j] = tempRow[j];
            }
        }
        private void SlideColumn(int column)
        {
            int[] tempColumn = new int[4];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                if (_board[i, column] != 0)
                {
                    tempColumn[index] = _board[i, column];
                    index++;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                _board[i, column] = tempColumn[i];
            }
        }
        private void SlideColumnDown(int column)
        {
            int[] tempColumn = new int[4];
            int index = 3;

            for (int i = 3; i >= 0; i--)
            {
                if (_board[i, column] != 0)
                {
                    tempColumn[index] = _board[i, column];
                    index--;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                _board[i, column] = tempColumn[i];
            }
        }
        private void CombineRow(int row)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[row, j] == _board[row, j + 1] && _board[row, j] != 0)
                {
                    _board[row, j] *= 2;
                    _board[row, j + 1] = 0;
                }
            }
        }
        private void CombineRowRight(int row)
        {
            for (int j = 3; j > 0; j--)
            {
                if (_board[row, j] == _board[row, j - 1] && _board[row, j] != 0)
                {
                    _board[row, j] *= 2;
                    _board[row, j - 1] = 0;
                }
            }
        }
        private void CombineColumn(int column)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, column] == _board[i + 1, column] && _board[i, column] != 0)
                {
                    _board[i, column] *= 2;
                    _board[i + 1, column] = 0;
                }
            }
        }
        private void CombineColumnDown(int column)
        {
            for (int i = 3; i > 0; i--)
            {
                if (_board[i, column] == _board[i - 1, column] && _board[i, column] != 0)
                {
                    _board[i, column] *= 2;
                    _board[i - 1, column] = 0;
                }
            }
        }
    }

}
