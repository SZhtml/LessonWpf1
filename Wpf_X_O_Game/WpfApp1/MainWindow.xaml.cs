using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Tern = true;
        int count = 1;
        string[,] mat= new string[3,3];
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            
            Button b = e.OriginalSource as Button;
            if(b.Content == null)
            {
                Tern = !Tern;
                count++;
                int row =(int) b.GetValue(Grid.RowProperty);
                int col =(int) b.GetValue(Grid.ColumnProperty);
                if (Tern)
                {
                    b.Content = "X";
                    mat[row-1, col-1] = "X";
                }
                else
                {
                    b.Content = "O";
                    mat[row-1, col-1] = "O";
                }

                if (count > 5)
                {
                    if(GameIsOver()==1)
                        MessageBox.Show("X win");
                    if(GameIsOver() == 2)
                        MessageBox.Show("O win");

                }
            }
        }

        private int GameIsOver()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i, 0] == mat[i, 1] && mat[i, 0] == mat[i, 2] && mat[i, 2]!=null)
                    if (mat[i, 0] == "X") return 1;
                    else return 2;

                if (mat[0, i] == mat[1, i] && mat[0, i] == mat[2, i] && mat[2, i] != null)
                    if (mat[0, i] == "X") return 1;
                    else return 2;

                if (mat[0, 0] == mat[1, 1] && mat[0, 0] == mat[2, 2] && mat[2, 2] != null)
                    if (mat[0, 0] == "X") return 1;
                    else return 2;

                if (mat[0, 2] == mat[1, 1] && mat[0, 2] == mat[2, 0] && mat[2, 0] != null)
                    if (mat[0, 2] == "X") return 1;
                    else return 2;
            }
            return 0;
        }
    }
}
