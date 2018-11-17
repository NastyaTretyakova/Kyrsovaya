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

namespace Kyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Films> catalog = new List<Films>();
        private List<string> genres = new List<string>();
        private List<int> years = new List<int>();

        public List<Films> Catalog { get => catalog; set => catalog = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public List<int> Years { get => years; set => years = value; }

        public MainWindow()
        {
            
            this.catalog.Add(new Films() { Name = "Мег: Монстр глубины", Genre = new List<string>() { "ужасы", "ужасы3" }, Year = 2019, ImagePath = "Res\\TheMeg.jpg", Description = "Глубоководный батискаф, осуществляющий наблюдение в рамках международной программы по изучению подводной жизни, был атакован огромным существом, которое все считали давно вымершим. Неисправный аппарат теперь лежит на дне глубочайшей впадины Тихого океана… с оказавшимся в ловушке экипажем. Их время на исходе. Китайский океанограф-новатор, несмотря на протесты его дочери Суинь, зовет спасателя-подводника Джонаса Тейлора, чтобы тот помог спасти команду и океан от невиданной угрозы — доисторической 23-метровой акулы, мегалодона. Никто и подумать не мог, что много лет назад Тейлор уже сталкивался с этим чудовищным созданием." });
            this.catalog.Add(new Films() { Name = "Миссия невыполнима: Последствия", Genre = new List<string>() { "боевик", "ужасы3" }, Year = 2018, ImagePath = "Res\\MissionImpossibleFallout.jpg", Description = "Итан Хант и его команда, а также недавно примкнувшие к ним союзники, вынуждены действовать наперегонки со временем, когда новая миссия идет не по плану." });
            List<string> temp = new List<string>();
            this.catalog.ForEach(f => temp.AddRange(f.Genre.ToList()));
            //.ToList());   
            this.genres.AddRange( temp.Distinct());
            this.years.AddRange(this.catalog.Select(c => c.Year).Distinct().ToList());
            InitializeComponent();
            DataContext = this;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void StatistikaOpenWindow(object sender, RoutedEventArgs e)
        {
            Window statwin = new Statistika();
            statwin.Owner = this;
            statwin.ShowDialog();
        }


    }
}
