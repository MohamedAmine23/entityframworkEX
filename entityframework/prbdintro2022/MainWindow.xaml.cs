
using System.Windows;
using System.Windows.Controls;


namespace Intro {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MakeList();
        }

        private readonly ListePers _listePers = new();
        private void Clear() {
            listBox.Items.Clear();
            txtBoxNom.Clear();
            txtBoxPrenom.Clear();
        }
        private void MakeList() {
            Clear();
            foreach (var p in _listePers)
                listBox.Items.Add(p);
            listBox.SelectedIndex = 1;
        }
        private bool _modeAjout = false;
        private void btcNew_Click(object sender, RoutedEventArgs e) {
            txtBoxPrenom.Clear();
            txtBoxNom.Clear();
            txtBoxNom.Focus();
            rbND.IsChecked = true;
            _modeAjout = true; 
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var p = (Personne)listBox.SelectedItem;
            if (p == null) return;
            txtBoxNom.Text = p.Nom;
            txtBoxPrenom.Text = p.Prenom;
            switch (p.Genre) {
                case Genre.H:
                    rbH.IsChecked = true;
                    break;
                case Genre.F:
                    rbF.IsChecked = true;
                    break;
                case Genre.ND:
                    rbND.IsChecked = true;
                    break;
            }
        }

        private void btcValider_Click(object sender, RoutedEventArgs e) {
            if (_modeAjout) {
                _listePers.AddElem(
                    new Personne(txtBoxPrenom.Text,txtBoxNom.Text, ChoixGenre())
                );
                _modeAjout = false;
            } else {
                var p = (Personne)listBox.SelectedItem;
                if (p == null) return;
                p.Nom = txtBoxNom.Text;
                p.Prenom = txtBoxPrenom.Text;
                p.Genre = ChoixGenre();
            }
            MakeList();
        }
        private Genre ChoixGenre() {
            if (rbH.IsChecked.Value)
                return Genre.H;
            else if (rbF.IsChecked.Value)
                return Genre.F;
            else
                return Genre.ND;
        }

        private void btcSuppr_Click(object sender, RoutedEventArgs e) {
            var p = (Personne)listBox.SelectedItem;
            if (p == null) return;
            _listePers.RemoveElem(p);
            MakeList();
        }

        private void comboTri_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var choixTri = (ComboBoxItem)comboTri.SelectedValue;
            if (choixTri == null) return;
            switch ((string)choixTri.Content) {
                case "Nom":
                    _listePers.SortBy((p1, p2) => p1.Nom.CompareTo(p2.Nom));
                    break;
                case "Prénom":
                    _listePers.SortBy((p1, p2) => p1.Prenom.CompareTo(p2.Prenom));
                    break;
                default:

                    break;
            }
            MakeList();
        }
    }
}
