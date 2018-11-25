using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        //string topList = string.Empty;

        public string TopList { get; set; } = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Films> catalogSourse = new List<Films>();
        private List<string> genres = new List<string>();
        private List<int> years = new List<int>();
        private string searchText = string.Empty;
        public ObservableCollection<Films> Catalog { get; set; } = new ObservableCollection<Films>();

        public ObservableCollection<string> Genres { get; set; } = new ObservableCollection<string>();
        public string SelectedGenres { get; set; } = string.Empty;
        public ObservableCollection<int> Years { get; set; } = new ObservableCollection<int>();
        public string SelectedYears { get; set; } = string.Empty;
        public string SearchText {
            get {
                return searchText;
            } set
            { searchText = value;
                RaisePropertyChanged(() => SearchText);
            }
        }

        public MainWindow()
        {
            //this.catalog.Add(new Films() { Name = "", Genre = new List<string>(){"" }, Year = , ImagePath = "Res\\MissionImpossibleFallout.jpg", Description = ""});
            this.catalogSourse.Add(new Films() { Name = "Мег: Монстр глубины", Genre = new List<string>() { "ужасы", "ужасы" }, Year = 2019, ImagePath = "Res\\TheMeg.jpg", Description = "Глубоководный батискаф, осуществляющий наблюдение в рамках международной программы по изучению подводной жизни, был атакован огромным существом, которое все считали давно вымершим. Неисправный аппарат теперь лежит на дне глубочайшей впадины Тихого океана… с оказавшимся в ловушке экипажем. Их время на исходе. Китайский океанограф-новатор, несмотря на протесты его дочери Суинь, зовет спасателя-подводника Джонаса Тейлора, чтобы тот помог спасти команду и океан от невиданной угрозы — доисторической 23-метровой акулы, мегалодона. Никто и подумать не мог, что много лет назад Тейлор уже сталкивался с этим чудовищным созданием." });
            this.catalogSourse.Add(new Films() { Name = "Миссия невыполнима: Последствия", Genre = new List<string>() { "боевик", "ужасы" }, Year = 2018, ImagePath = "Res\\MissionImpossibleFallout.jpg", Description = "Итан Хант и его команда, а также недавно примкнувшие к ним союзники, вынуждены действовать наперегонки со временем, когда новая миссия идет не по плану." });
            this.catalogSourse.Add(new Films() { Name = "Побег из Шоушенка", Genre = new List<string>(){ "драма" }, Year = 1994, ImagePath = "Res\\TheShawshankRedemption.jpg", Description = "Бухгалтер Энди Дюфрейн обвинен в убийстве собственной жены и ее любовника. Оказавшись в тюрьме под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны решетки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий живым умом и доброй душой, находит подход как к заключенным, так и к охранникам, добиваясь их особого к себе расположения." });
            this.catalogSourse.Add(new Films() { Name = "Форрест Гамп", Genre = new List<string>() { "драма", "мелодрама" }, Year = 1994, ImagePath = "Res\\ForrestGump.jpg", Description = "От лица главного героя Форреста Гампа, слабоумного безобидного человека с благородным и открытым сердцем, рассказывается история его необыкновенной жизни.Фантастическим образом превращается он в известного футболиста, героя войны, преуспевающего бизнесмена.Он становится миллиардером, но остается таким же бесхитростным, глупым и добрым.Форреста ждет постоянный успех во всем, а он любит девочку, с которой дружил в детстве, но взаимность приходит слишком поздно." });
            this.catalogSourse.Add(new Films() { Name = "Зеленая миля", Genre = new List<string>(){ "фэнтези", "драма", "криминал", "детектив" }, Year = 1999, ImagePath = "Res\\TheGreenMile.jpg", Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока."});
             this.catalogSourse.Add(new Films() { Name = "Список Шиндлера", Genre = new List<string>(){ "драма", "биография", "история" }, Year = 1993 , ImagePath = "Res\\Schindler'sList.jpg", Description = "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев." });

            // string result = string.Join(", ", catalog.Select(f => f.Year));  //КАК ВАРИАНТ
            //catalog = catalog.OrderBy(f => f.Year).ToList();
            // string orderedResult = string.Join(", ", catalog.Select(f => f.Year));
            
            List <string> temp = new List<string>();
            this.catalogSourse.ForEach(f => temp.AddRange(f.Genre.ToList()));
            //.ToList());   
            this.genres.AddRange( temp.Distinct());
            this.years.AddRange(this.catalogSourse.Select(c => c.Year).Distinct().ToList());
            this.years.Sort();

            years.ForEach(c => Years.Add(c));
            genres.ForEach(c => Genres.Add(c));

            InitializeComponent();
            DataContext = this;
            this.UpadateSearch();
        }

        public void UpadateSearch()
        {
            //this.Catalog.Add(Catalog.First());
            this.Catalog.Clear();
            var ff = catalogSourse.First();
            var t = string.IsNullOrWhiteSpace(searchText) | ff.Name.Contains(searchText);
            this.catalogSourse.Where(f =>

            string.IsNullOrWhiteSpace(searchText) | 
            f.Name.Contains(searchText) |
            f.Description.ToLower().Contains(searchText.ToLower())
            && (SelectedGenres.Equals(string.Empty) | f.Genre.Select(c=>c.ToLower()).Contains(SelectedGenres.ToLower()))
            && (SelectedYears.Equals(string.Empty) | f.Year.ToString().Equals(SelectedYears))

            ).ToList().ForEach(c => Catalog.Add(c));
        }

        private void StatistikaOpenWindow(object sender, RoutedEventArgs e)
        {
            Window statwin = new Statistika();
            statwin.Owner = this;
            string List = "fdsfdfsdf";
            //this.TopList.Clear();
            //var ttt = 
            //const char V = ")"+ "\r\n";
            StringBuilder _Text = new StringBuilder();
            (catalogSourse.Select(c => new { Name = c.Name, ViewCount = c.ViewCount, Year = c.Year}).OrderByDescending(b=> b.ViewCount).Select(v=> v.Name+"("+ v.Year + ") [просмотров - " + v.ViewCount+"]")).ToList().ForEach(c=> _Text.AppendLine(c));


            this.TopList = _Text.ToString();
            statwin.DataContext = this;
            //statwin.top
            statwin.ShowDialog();
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanged(propertyName);
        }

        private string ExtractPropertyName<T>(Expression<Func<T>> propertyExpresssion)
        {
            if (propertyExpresssion == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpresssion.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
            }

            if (!property.DeclaringType.IsAssignableFrom(this.GetType()))
            {
                throw new ArgumentException("The referenced property belongs to a different type.", "propertyExpression");
            }

            var getMethod = property.GetGetMethod(true);
            if (getMethod == null)
            {
                // this shouldn't happen - the expression would reject the property before reaching this far
                throw new ArgumentException("The referenced property does not have a get method.", "propertyExpression");
            }

            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
            }

            return memberExpression.Member.Name;
        }

        private void SeachButton_Click(object sender, RoutedEventArgs e)
        {
            this.UpadateSearch();
            this.SelectedYears = string.Empty;
            this.SelectedGenres = string.Empty;
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedYears = string.Empty;
            this.SelectedGenres = string.Empty;
            this.UpadateSearch();
        }

        private void YearsSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Content.ToString();
            this.SelectedYears = name;
            this.SelectedGenres = string.Empty;
            this.SearchText = string.Empty;
            this.UpadateSearch();
        }

        private void GenresSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Content as string;
            this.SelectedGenres = name;
            this.SelectedYears = string.Empty;
            this.SearchText = string.Empty;
            this.UpadateSearch();
        }
        private void UpdateSerach(object sender, System.Windows.Data.DataTransferEventArgs e)
    {
        this.UpadateSearch();
    }

        private void OpenFilm(object sender, MouseButtonEventArgs e)
        {
            string name = (sender as Label).Content as string;
            Films selectedFilms = this.catalogSourse.Where(c => c.Name.Equals(name)).FirstOrDefault();
            selectedFilms.ViewCount++;
            Window FilmWindow = new ContentWindow();

            FilmWindow.Owner = this;
            FilmWindow.DataContext = selectedFilms;
            FilmWindow.ShowDialog();
        }
    }

    }
