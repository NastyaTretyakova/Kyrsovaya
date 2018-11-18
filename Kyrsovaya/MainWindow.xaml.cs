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
            //this.catalog.Add(new Films() { Name = "", Genre = new List<string>(){"" }, Year = , ImagePath = "Res\\MissionImpossibleFallout.jpg", Description = ""});
            this.catalog.Add(new Films() { Name = "Мег: Монстр глубины", Genre = new List<string>() { "ужасы", "ужасы" }, Year = 2019, ImagePath = "Res\\TheMeg.jpg", Description = "Глубоководный батискаф, осуществляющий наблюдение в рамках международной программы по изучению подводной жизни, был атакован огромным существом, которое все считали давно вымершим. Неисправный аппарат теперь лежит на дне глубочайшей впадины Тихого океана… с оказавшимся в ловушке экипажем. Их время на исходе. Китайский океанограф-новатор, несмотря на протесты его дочери Суинь, зовет спасателя-подводника Джонаса Тейлора, чтобы тот помог спасти команду и океан от невиданной угрозы — доисторической 23-метровой акулы, мегалодона. Никто и подумать не мог, что много лет назад Тейлор уже сталкивался с этим чудовищным созданием." });
            this.catalog.Add(new Films() { Name = "Миссия невыполнима: Последствия", Genre = new List<string>() { "боевик", "ужасы" }, Year = 2018, ImagePath = "Res\\MissionImpossibleFallout.jpg", Description = "Итан Хант и его команда, а также недавно примкнувшие к ним союзники, вынуждены действовать наперегонки со временем, когда новая миссия идет не по плану." });
            this.catalog.Add(new Films() { Name = "Побег из Шоушенка", Genre = new List<string>(){ "драма" }, Year = 1994, ImagePath = "Res\\TheShawshankRedemption.jpg", Description = "Бухгалтер Энди Дюфрейн обвинен в убийстве собственной жены и ее любовника. Оказавшись в тюрьме под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны решетки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий живым умом и доброй душой, находит подход как к заключенным, так и к охранникам, добиваясь их особого к себе расположения." });
            this.catalog.Add(new Films() { Name = "Форрест Гамп", Genre = new List<string>() { "драма", "мелодрама" }, Year = 1994, ImagePath = "Res\\ForrestGump.jpg", Description = "От лица главного героя Форреста Гампа, слабоумного безобидного человека с благородным и открытым сердцем, рассказывается история его необыкновенной жизни.Фантастическим образом превращается он в известного футболиста, героя войны, преуспевающего бизнесмена.Он становится миллиардером, но остается таким же бесхитростным, глупым и добрым.Форреста ждет постоянный успех во всем, а он любит девочку, с которой дружил в детстве, но взаимность приходит слишком поздно." });
            this.catalog.Add(new Films() { Name = "Зеленая миля", Genre = new List<string>(){ "фэнтези", "драма", "криминал", "детектив" }, Year = 1999, ImagePath = "Res\\TheGreenMile.jpg", Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока."});
             this.catalog.Add(new Films() { Name = "Список Шиндлера", Genre = new List<string>(){ "драма", "биография", "история" }, Year =1993 , ImagePath = "Res\\Schindler'sList.jpg", Description = "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев." });

            List <string> temp = new List<string>();
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
