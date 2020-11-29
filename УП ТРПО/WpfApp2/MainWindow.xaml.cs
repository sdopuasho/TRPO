using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InsertWpf IWF = new InsertWpf();
        WorkWithBd wbd = new WorkWithBd();
        OperationsWithWork OON = new OperationsWithWork();
        public MainWindow()
        {
            InitializeComponent();
            Rbutton2.IsChecked = true;
            mat1_Copy7.Visibility = Visibility.Hidden;
            mat1_Copy8.Visibility = Visibility.Hidden;
            i_Copy1.Visibility = Visibility.Hidden;
            j_Copy1.Visibility = Visibility.Hidden;
        }
        public void PrintMatixTwo(int[,] matix, int numofcase)
        {
            switch (numofcase)
            {
                case 1:
                    for (int i = 0; i < matix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matix.GetLength(1); j++)
                        {
                            if (j == matix.GetLength(1) - 1)
                            {
                                InsertResult.Text += matix[i, j].ToString() + "\r\n";
                            }
                            else
                            {
                                InsertResult.Text += matix[i, j].ToString() + " ";
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < matix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matix.GetLength(1); j++)
                        {
                            if (j == matix.GetLength(1) - 1)
                            {
                                result.Text += matix[i, j].ToString() + "\r\n";
                            }
                            else
                            {
                                result.Text += matix[i, j].ToString() + " ";
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < matix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matix.GetLength(1); j++)
                        {
                            if (j == matix.GetLength(1) - 1)
                            {
                                result_Copy.Text += matix[i, j].ToString() + "\r\n";
                            }
                            else
                            {
                                result_Copy.Text += matix[i, j].ToString() + " ";
                            }
                        }
                    }
                    break;
            }
            
        }
        public void prinsolomatix(int[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                InsertResult.Text += matrix[i].ToString() + " ";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i.Text != j.Text)
            {
                result.Text = "";
                InsertResult.Text = "";
                result_Copy.Text = "";
                int[] check = Matrix.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(k => int.Parse(k.Trim())).ToArray();
                int check2 = Convert.ToInt32(j.Text) * Convert.ToInt32(i.Text);
                if (check.Length == check2)
                {
                    if (Rbutton1.IsChecked == true)
                    {
                        int[,] matr = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                        int checker = wbd.CheckFromBd(matr);
                        if (checker > 0)
                        {
                            if(CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matr, 1);
                                PrintMatixTwo(OON.VectorTranspos(matr, IWF.insertlow(Vector.Text)), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                 if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matr, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matr, 1, a);
                                }
                            }
                            else
                            {
                                PrintMatixTwo(matr, 1);
                                PrintMatixTwo(OON.VectorTranspos(matr, IWF.insertlow(Vector.Text)), 2);
                            }
                        }
                        else
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                wbd.addmatrixbd(matr);
                                PrintMatixTwo(matr, 1);
                                PrintMatixTwo(OON.VectorTranspos(matr, IWF.insertlow(Vector.Text)), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                 if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matr, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matr, 1, a);
                                }
                            }
                            else
                            {
                                wbd.addmatrixbd(matr);
                                PrintMatixTwo(matr, 1);
                                PrintMatixTwo(OON.VectorTranspos(matr, IWF.insertlow(Vector.Text)), 2);
                            }
                        }
                    }
                    else if (Rbutton2.IsChecked == true)
                    {
                        int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                        int checker = wbd.CheckFromBd(matrix);
                        if (checker > 0)
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.MatrixUmScalar(matrix), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                 if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 1, a);
                                }
                            }
                            else
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.MatrixUmScalar(matrix), 2);
                            }
                        }
                        else
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.MatrixUmScalar(matrix), 2);
                                wbd.addmatrixbd(matrix);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                }

                            }
                            else
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.MatrixUmScalar(matrix), 2);
                                wbd.addmatrixbd(matrix);

                            }
                        }
                    }
                    else if (Rbutton3.IsChecked == true)
                    {
                        int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                        int checker = wbd.CheckFromBd(matrix);
                        if (checker > 0)
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.matrixxscalar(matrix, Convert.ToInt32(Vector.Text)), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matrix, 1, a);
                                }
                            }
                            else
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.matrixxscalar(matrix, Convert.ToInt32(Vector.Text)), 2);
                            }
                        }
                        else
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.matrixxscalar(matrix, Convert.ToInt32(Vector.Text)), 2);
                                wbd.addmatrixbd(matrix);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matrix, 1, a);
                                }
                            }
                            else
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.matrixxscalar(matrix, Convert.ToInt32(Vector.Text)), 2);
                                wbd.addmatrixbd(matrix);
                            }
                        }
                    }
                    else if (Rbutton4.IsChecked == true)
                    {
                        int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                        int checker = wbd.CheckFromBd(matrix);
                        if (checker > 0)
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.movestroks(matrix, Convert.ToInt32(Vector_Copy.Text), Convert.ToInt32(Vector_Copy1.Text)), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matrix, 1, a);
                                }
                            }
                            else
                            {
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.movestroks(matrix, Convert.ToInt32(Vector_Copy.Text), Convert.ToInt32(Vector_Copy1.Text)), 2);
                            }
                        }
                        else
                        {
                            if (CHKBX.IsChecked == true)
                            {
                                wbd.addmatrixbd(matrix);
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.movestroks(matrix, Convert.ToInt32(Vector_Copy.Text), Convert.ToInt32(Vector_Copy1.Text)), 2);
                                if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                {
                                    MessageBox.Show("Нужно задать строку или столбец");
                                }
                                else
                                if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                {
                                    int a = Convert.ToInt32(i_Copy1.Text);
                                    risutupisu(matrix, 0, a);
                                }
                                else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                {
                                    int a = Convert.ToInt32(j_Copy1.Text);
                                    risutupisu(matrix, 1, a);
                                }
                            }
                            else
                            {
                                wbd.addmatrixbd(matrix);
                                PrintMatixTwo(matrix, 1);
                                PrintMatixTwo(OON.movestroks(matrix, Convert.ToInt32(Vector_Copy.Text), Convert.ToInt32(Vector_Copy1.Text)), 2);
                            }
                        }
                    }
                    else if (Rbutton5.IsChecked == true)
                    {
                        int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                        PrintMatixTwo(matrix, 1);
                        PrintMatixTwo(OON.ArrayTrans(matrix), 2);
                    }
                    else if (Rbutton6.IsChecked == true)
                    {
                        if (i.Text == i_Copy.Text && j.Text == j_Copy.Text)
                        {
                            int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                            int[,] matrix2 = IWF.insert(Matrix_Copy.Text, Convert.ToInt32(j_Copy.Text), Convert.ToInt32(i_Copy.Text));
                            int checker = wbd.CheckFromBd(matrix);
                            int checker2 = wbd.CheckFromBd(matrix2);
                            if (checker > 0 &&  checker2 > 0)
                            {
                                if (CHKBX.IsChecked == true)
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 1), 3);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }
                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 1), 3);
                                }
                            }
                            else if (checker > 0 && checker2 == 0)
                            {
                                if (CHKBX.IsChecked == true)
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }
                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    wbd.addmatrixbd(matrix2);
                                }
                            }
                            else if (checker == 0 && checker2 > 0)
                            {
                                if (CHKBX.IsChecked == true)
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    wbd.addmatrixbd(matrix);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }
                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    wbd.addmatrixbd(matrix);
                                }
                            }
                            else
                            {
                                if (CHKBX.IsChecked == true)
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 1), 3);
                                    wbd.addmatrixbd(matrix);
                                    wbd.addmatrixbd(matrix2);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }
                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 1), 3);
                                    wbd.addmatrixbd(matrix);
                                    wbd.addmatrixbd(matrix2);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Складывать можно только матрицы с одинаковым размером");
                        }
                    }
                    else if (Rbutton7.IsChecked == true)
                    {
                        if (i.Text == i_Copy.Text && j.Text == j_Copy.Text)
                        {
                            int[,] matrix = IWF.insert(Matrix.Text, Convert.ToInt32(j.Text), Convert.ToInt32(i.Text));
                            int[,] matrix2 = IWF.insert(Matrix_Copy.Text, Convert.ToInt32(j_Copy.Text), Convert.ToInt32(i_Copy.Text));
                            int checker = wbd.CheckFromBd(matrix);
                            int checker2 = wbd.CheckFromBd(matrix2);
                            if (checker > 0 && checker2 > 0)
                            {
                                if (CHKBX.IsChecked == true)
                                {

                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }
                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                }
                            }
                            else
                            {
                                if (CHKBX.IsChecked == true)
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    wbd.addmatrixbd(matrix);
                                    wbd.addmatrixbd(matrix2);
                                    if (i_Copy1.Text == "" && j_Copy1.Text == "")
                                    {
                                        MessageBox.Show("Нужно задать строку или столбец");
                                    }
                                    else
                                    if (i_Copy1.Text != "" && j_Copy1.Text == "")
                                    {
                                        int a = Convert.ToInt32(i_Copy1.Text);
                                        risutupisu(matrix, 0, a);
                                    }
                                    else if (i_Copy1.Text == "" && j_Copy1.Text != "")
                                    {
                                        int a = Convert.ToInt32(j_Copy1.Text);
                                        risutupisu(matrix, 1, a);
                                    }

                                }
                                else
                                {
                                    PrintMatixTwo(matrix, 1);
                                    PrintMatixTwo(matrix2, 2);
                                    PrintMatixTwo(OON.MatOp(matrix, matrix2, 2), 3);
                                    wbd.addmatrixbd(matrix);
                                    wbd.addmatrixbd(matrix2);

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вычитать можно только матрицы с одинаковым размером");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("" + check.Length + " " + check2);
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void Rbutton1_Checked(object sender, RoutedEventArgs e)
        {
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Vector.Visibility = Visibility.Visible;
            Matrix_Copy.Visibility = Visibility.Hidden;
            i_Copy.Visibility = Visibility.Hidden;
            j_Copy.Visibility = Visibility.Hidden;
            result_Copy.Visibility = Visibility.Hidden;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Visible;
            mat1_Copy2.Visibility = Visibility.Hidden;
            mat1_Copy3.Visibility = Visibility.Hidden;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Результат";
            mat1_Copy6.Visibility = Visibility.Hidden;
        }

        private void Rbutton2_Checked(object sender, RoutedEventArgs e)
        {
            Vector.Visibility = Visibility.Hidden;
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Matrix_Copy.Visibility = Visibility.Hidden;
            i_Copy.Visibility = Visibility.Hidden;
            j_Copy.Visibility = Visibility.Hidden;
            result_Copy.Visibility = Visibility.Hidden;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Hidden;
            mat1_Copy2.Visibility = Visibility.Hidden;
            mat1_Copy3.Visibility = Visibility.Hidden;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Результат";
            mat1_Copy6.Visibility = Visibility.Hidden;
        }

        private void Rbutton3_Checked(object sender, RoutedEventArgs e)
        {
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Vector.Visibility = Visibility.Visible;
            Matrix_Copy.Visibility = Visibility.Hidden;
            i_Copy.Visibility = Visibility.Hidden;
            j_Copy.Visibility = Visibility.Hidden;
            result_Copy.Visibility = Visibility.Hidden;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Hidden;
            mat1_Copy2.Visibility = Visibility.Hidden;
            mat1_Copy3.Visibility = Visibility.Hidden;
            vectoria_Copy.Visibility = Visibility.Visible;
            mat1_Copy5.Content = "Результат";
            mat1_Copy6.Visibility = Visibility.Hidden;
        }

        private void Rbutton4_Checked(object sender, RoutedEventArgs e)
        {
            Vector.Visibility = Visibility.Hidden;
            Vector_Copy.Visibility = Visibility.Visible;
            Vector_Copy1.Visibility = Visibility.Visible;
            Matrix_Copy.Visibility = Visibility.Hidden;
            i_Copy.Visibility = Visibility.Hidden;
            j_Copy.Visibility = Visibility.Hidden;
            result_Copy.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Hidden;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Visible;
            strok2.Visibility = Visibility.Visible;
            mat1_Copy2.Visibility = Visibility.Hidden;
            mat1_Copy3.Visibility = Visibility.Hidden;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Результат";
            mat1_Copy6.Visibility = Visibility.Hidden;
        }

        private void Rbutton5_Checked(object sender, RoutedEventArgs e)
        {
            Vector.Visibility = Visibility.Hidden;
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Matrix_Copy.Visibility = Visibility.Hidden;
            i_Copy.Visibility = Visibility.Hidden;
            j_Copy.Visibility = Visibility.Hidden;
            result_Copy.Visibility = Visibility.Hidden;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Hidden;
            mat1_Copy2.Visibility = Visibility.Hidden;
            mat1_Copy3.Visibility = Visibility.Hidden;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Результат";
            mat1_Copy6.Visibility = Visibility.Hidden;
        }

        private void Rbutton6_Checked(object sender, RoutedEventArgs e)
        {
            Vector.Visibility = Visibility.Hidden;
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Matrix_Copy.Visibility = Visibility.Visible;
            i_Copy.Visibility = Visibility.Visible;
            j_Copy.Visibility = Visibility.Visible;
            result_Copy.Visibility = Visibility.Visible;
            vectoria.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Visible;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat1_Copy2.Visibility = Visibility.Visible;
            mat1_Copy3.Visibility = Visibility.Visible;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Матрица 2";
            mat1_Copy6.Visibility = Visibility.Visible;
        }

        private void Rbutton7_Checked(object sender, RoutedEventArgs e)
        {
            Vector.Visibility = Visibility.Hidden;
            Vector_Copy.Visibility = Visibility.Hidden;
            Vector_Copy1.Visibility = Visibility.Hidden;
            Matrix_Copy.Visibility = Visibility.Visible;
            i_Copy.Visibility = Visibility.Visible;
            j_Copy.Visibility = Visibility.Visible;
            result_Copy.Visibility = Visibility.Visible;
            vectoria.Visibility = Visibility.Hidden;
            strok1.Visibility = Visibility.Hidden;
            strok2.Visibility = Visibility.Hidden;
            mat2.Visibility = Visibility.Visible;
            mat1_Copy2.Visibility = Visibility.Visible;
            mat1_Copy3.Visibility = Visibility.Visible;
            vectoria_Copy.Visibility = Visibility.Hidden;
            mat1_Copy5.Content = "Матрица 2";
            mat1_Copy6.Visibility = Visibility.Visible;
        }
        string[] axisXData;
        public int[] axisYData;
        public void risutupisu(int[,] mat, int str, int tstr)
        {
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.Series.Add(new Series("Salary"));
            chart1.Series["Salary"].ChartArea = "Default";
            chart1.Series["Salary"].ChartType = SeriesChartType.Column;
            if (str == 1)
            {
                axisXData = new string[mat.GetLength(0)];
                axisYData = new int[mat.GetLength(0)];
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    axisXData[i] = mat[i, tstr].ToString();
                }
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    axisYData[i] = mat[i, tstr];
                }
            }
            else if(str == 0)
            {
                axisXData = new string[mat.GetLength(1)];
                axisYData = new int[mat.GetLength(1)];
                for (int i = 0; i < mat.GetLength(1); i++)
                {
                    axisXData[i] = mat[tstr, i].ToString();
                }
                for (int i = 0; i < mat.GetLength(1); i++)
                {
                    axisYData[i] = mat[tstr, i];
                }
            }
            chart1.Series["Salary"].Points.DataBindXY(axisXData, axisYData);
        }

        private void CHKBX_Checked(object sender, RoutedEventArgs e)
        {
            mat1_Copy7.Visibility = Visibility.Visible;
            mat1_Copy8.Visibility = Visibility.Visible;
            i_Copy1.Visibility = Visibility.Visible;
            j_Copy1.Visibility = Visibility.Visible;
        }
    }
}
