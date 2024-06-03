using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System;

namespace IT3B_Kostky
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            int[] diceValues = new int[6];
            for (int i = 0; i < 6; i++)
            {
                diceValues[i] = random.Next(1, 7);
            }

            lblDice1.Content = diceValues[0].ToString();
            lblDice2.Content = diceValues[1].ToString();
            lblDice3.Content = diceValues[2].ToString();
            lblDice4.Content = diceValues[3].ToString();
            lblDice5.Content = diceValues[4].ToString();
            lblDice6.Content = diceValues[5].ToString();

            SaveDiceHistory(diceValues);
        }

        private void SaveDiceHistory(int[] diceValues)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dice_history.txt");
            string diceRoll = string.Join(", ", diceValues);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(diceRoll);
            }
        }
    }
}