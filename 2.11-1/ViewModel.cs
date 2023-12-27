using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._11_1
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Game _game;

        public int[,] GameBoard
        {
            get { return _game.Board; }
        }

        public ViewModel()
        {
            _game = new Game();
            _game.BoardChanged += Game_BoardChanged;
        }
        public void NewGame()
        {
            _game = new Game();
            _game.BoardChanged += Game_BoardChanged;
            OnPropertyChanged("GameBoard");
        }
        private void Game_BoardChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("GameBoard");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
