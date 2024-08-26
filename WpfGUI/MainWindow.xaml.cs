using System;
using System.ComponentModel;
using System.Data;
using System.Reflection.Emit;
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

namespace WpfGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<DTO.StationModel>? _destinations { get; set; }
        public List<DTO.SeatModel> _seats { get; set; }
        public int _selectedRouteId;
        public MainWindow()
        {
            InitializeComponent();

            Models.DestinationVM destination = new();
            // passing 1 because assumed starting point is always atlanta in this case
            _destinations = destination.LoadDestinationsData(1); 
            DataContext = this;
        }

        private void ComboBox_GetDestinations(object sender, SelectionChangedEventArgs e)
        {
            Models.DestinationVM destination = new();
            spDestination.Visibility = Visibility.Visible;
        }

        private void ComboBox_GetSeatSelections(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((DTO.StationModel)cboDestination.SelectedItem);
            int selectedId = selectedItem.route_id;
            _selectedRouteId = selectedId; // need public id to be used later when assigning seat

            // get route details
            Models.DestinationVM destination = new();
            lblRouteDetails.Content = destination.GetRouteDetails(selectedId);

            // dispay seats
            splabel.Visibility = Visibility.Visible;
            spSeats.Visibility = Visibility.Visible;
            // get seats
            spSeats.Children.Clear();
            Models.SeatsVM seat = new();
            _seats = seat.LoadSeatsData(selectedId);
            foreach (var s in _seats)
            {
                RadioButton rb = new RadioButton() { Content = s.seat_number, };
                if (s.is_available == 0)
                {
                    rb.IsEnabled = false;
                }
                
                spSeats.Children.Add(rb);
                rb.Checked += new RoutedEventHandler(rb_Checked);
            }

        }
        void rb_Unchecked(object sender, RoutedEventArgs e)
        {   
            MessageBox.Show((sender as RadioButton).Content.ToString() + " checked.");
        }

        void rb_Checked(object sender, RoutedEventArgs e)
        {
            string seatNo = (sender as RadioButton).Content.ToString()!;
        }
        private void clearChoice_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton rb in spSeats.Children)
            {
                if (rb.IsChecked == true)
                {
                    rb.IsChecked = false;
                    break;
                }
            }
        }
        private void assignChoice_Click(object sender, RoutedEventArgs e)
        {
            string selectedSeat = "";
            foreach (RadioButton rb in spSeats.Children) 
            {
                if (rb.IsChecked == true) 
                { 
                    selectedSeat = rb.Content.ToString()!;
                    rb.IsChecked = false;
                    rb.IsEnabled = false;
                    break; 
                } 
            }
            string selection = _selectedRouteId.ToString() + "  " + selectedSeat;
            if (!string.IsNullOrEmpty(selectedSeat))
            {
                Models.SeatsVM seat = new();
                var res = seat.AssignSeat(_selectedRouteId, selectedSeat);
                if (res != null)
                {
                    if (res.success)
                    {
                        MessageBox.Show($"Seat '{selectedSeat}' is assigned successfully.");
                    }
                }
            }
            else
            {
                MessageBox.Show($"Please select a seat before clicking Assign button.", "Warning");
            }
        }
    }
    
}