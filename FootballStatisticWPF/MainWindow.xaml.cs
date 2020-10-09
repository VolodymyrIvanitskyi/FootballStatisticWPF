using System;
using System.Collections.Generic;
using System.IO;
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
using FootballStatisticWPF.Models;
using FootballStatisticWPF.Statistics;
using FootballStatisticWPF.Statistics.Realization;
using Newtonsoft.Json;

namespace FootballStatisticWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Statistic statistic1 = new Statistic();
        Statistic statistic2 = new Statistic();
        Statistic statistic3 = new Statistic();
        public void Init()
        {
            statistic1.League = JsonConvert.DeserializeObject<League>(File.ReadAllText("en.1.json"));
            statistic2.League = JsonConvert.DeserializeObject<League>(File.ReadAllText("en.2.json"));
            statistic3.League = JsonConvert.DeserializeObject<League>(File.ReadAllText("en.3.json"));

            statistic1.Config();
            statistic2.Config();
            statistic3.Config();
        }
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            GoalsPerDay goalsPerDay = statistic1.MaxGoalsPerDay();
            TextBlock1.Text += $"Найбільше голів за день: {goalsPerDay.CountOfGoals }, дата {goalsPerDay.Date.ToShortDateString()}";
        }

        
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text += GetResult(statistic1);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text += GetResult(statistic2);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text += GetResult(statistic3);
        }

        private string GetResult(Statistic statistic)
        {
            string result="";
            FootballTeam maxGoals = statistic.MaxGoals();
            result += "Найкраща атакуюча команда: \n";
            result += $"{maxGoals.Name}, кількість забитих м'ячів {maxGoals.GoalsScored}, кількість пропущених {maxGoals.MissedBalls} \n";

            FootballTeam minMissedBall = statistic.MinMissBalls();
            result += "Найкраща захисна команда:\n";
            result += $"{minMissedBall.Name}, кількість забитих м'ячів {minMissedBall.GoalsScored}, кількість пропущених {minMissedBall.MissedBalls}\n";

            FootballTeam bestScoredMissed = statistic.BestScoredMissed();
            result += "Найкраща команда за кількістю забіти-пропущені \n";
            result += $"{bestScoredMissed.Name}, кількість забитих м'ячів {bestScoredMissed.GoalsScored}, кількість пропущених {bestScoredMissed.MissedBalls}\n";

            return result;
        }
    }
}
