using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ПрРПМ._20
{
    public class Film
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public override string ToString() => Title;
    }

    public partial class MainWindow : Window
    {
        private List<Film> allFilms = new List<Film>();

        public MainWindow()
        {
            InitializeComponent();
            allFilms.Add(new Film { Title = "Терминатор", Genre = "Боевик", Description = "Робот из будущего приходит в прошлое." });
            allFilms.Add(new Film { Title = "Форсаж", Genre = "Боевик", Description = "Гонки, машины и семья." });
            allFilms.Add(new Film { Title = "Один дома", Genre = "Комедия", Description = "Мальчик защищает дом от грабителей." });
            allFilms.Add(new Film { Title = "Мальчишник в Вегасе", Genre = "Комедия", Description = "Друзья теряют жениха." });
            allFilms.Add(new Film { Title = "Титаник", Genre = "Драма", Description = "История любви на тонущем корабле." });
            allFilms.Add(new Film { Title = "Зеленая миля", Genre = "Драма", Description = "Охранник тюрьмы и его необычный заключенный." });

            GenreCombo.Items.Add("Боевик");
            GenreCombo.Items.Add("Комедия");
            GenreCombo.Items.Add("Драма");
        }

        // Бебебе
        private void GenreCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilmList.Items.Clear();
            DescriptionText.Text = "";

            string selectedGenre = GenreCombo.SelectedItem as string;

            if (selectedGenre != null)
            {
                foreach (Film film in allFilms)
                {
                    if (film.Genre == selectedGenre)
                    {
                        FilmList.Items.Add(film);
                    }
                }
            }
        }

        private void ShowDescription_Click(object sender, RoutedEventArgs e)
        {

            if (FilmList.SelectedItem is Film selectedFilm)
            {
                DescriptionText.Text = $"Описание фильма «{selectedFilm.Title}»:\n{selectedFilm.Description}";
            }
            else
            {
                MessageBox.Show("Сначала выберите фильм из списка!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}