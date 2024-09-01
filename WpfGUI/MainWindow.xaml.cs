using System.Windows;
using System.Windows.Controls;
using DAL;

namespace WpfGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<DTO.StationModel>? _destinations { get; set; }
        public List<DTO.SeatModel>? _seats { get; set; }
        public int _selectedRouteId;
        private readonly IStationRepository _station;
        private readonly IRouteRepository _route;
        private readonly ISeatRepository _seat;

        public MainWindow(IStationRepository station, IRouteRepository route, ISeatRepository seat)
        {
            InitializeComponent();

            // initialize dependency injection
            _station = station;
            _route = route;
            _seat = seat;

            //Models.DestinationVM destination = new();
            // getting the initial destinations
            // passing 1 because assumed starting point is always atlanta in this case
            _destinations = _station.GetDestinationStations(1); 
            DataContext = this;
            
        }

        private void ComboBox_GetDestinations(object sender, SelectionChangedEventArgs e)
        {
            //Models.DestinationVM destination = new();
            spDestination.Visibility = Visibility.Visible;
        }

        private void ComboBox_GetSeatSelections(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((DTO.StationModel)cboDestination.SelectedItem);
            int selectedId = selectedItem.route_id;
            _selectedRouteId = selectedId; // need public id to be used later when assigning seat

            // get route details
            //Models.DestinationVM destination = new();
            lblRouteDetails.Content = _route.getRouteDetails(selectedId);

            // dispay seats first column
            splabel.Visibility = Visibility.Visible;
            spSeats.Visibility = Visibility.Visible;
            spSeats.Children.Clear();
            // display seats second column
            spSeats2.Visibility = Visibility.Visible;
            spSeats2.Children.Clear();

            // get seats
            Models.SeatsVM seat = new(_seat);
            _seats = seat.LoadSeatsData(selectedId);
            // populate first column
            foreach (var s in _seats)
            {
                // populate 1st column
                if (s.seat_number.Contains("1"))
                {
                    RadioButton rb = new RadioButton() { Content = s.seat_number, };
                    if (s.is_available == 0)
                    {
                        rb.IsEnabled = false;
                    }
                    rb.FlowDirection = FlowDirection.RightToLeft;
                    spSeats.Children.Add(rb);
                    rb.Checked += new RoutedEventHandler(rb_Checked);
                }
                // populate 2nd column
                if (s.seat_number.Contains("2"))
                {
                    RadioButton rb = new RadioButton() { Content = s.seat_number, };
                    if (s.is_available == 0)
                    {
                        rb.IsEnabled = false;
                    }
                    spSeats2.Children.Add(rb);
                    rb.Checked += new RoutedEventHandler(rb_Checked);
                }
            }
        }

        // not using this method for now
        //void rb_Unchecked(object sender, RoutedEventArgs e)
        //{   
        //    MessageBox.Show((sender as RadioButton).Content.ToString() + " checked.");
        //}

        void rb_Checked(object sender, RoutedEventArgs e)
        {
            string seatNo = ((RadioButton?)sender!).Content.ToString()!;

            //clear first column
            foreach (RadioButton rb in spSeats.Children)
            {
                if (rb.IsChecked == true)
                {
                    if ((string)rb.Content != seatNo)
                    {
                        rb.IsChecked = false;
                        break;
                    }
                }
            }
            // clear second column
            foreach (RadioButton rb in spSeats2.Children)
            {
                if (rb.IsChecked == true)
                {
                    if ((string)rb.Content != seatNo)
                    {
                        rb.IsChecked = false;
                        break;
                    }
                }
            }
        }
        private void clearChoice_Click(object sender, RoutedEventArgs e)
        {
            //clear first column
            foreach (RadioButton rb in spSeats.Children)
            {
                if (rb.IsChecked == true)
                {
                    rb.IsChecked = false;
                    break;
                }
            }
            // clear second column
            foreach (RadioButton rb in spSeats2.Children)
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
            // column 1
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
            // column 2
            if (selectedSeat == "")
            {
                foreach (RadioButton rb in spSeats2.Children)
                {
                    if (rb.IsChecked == true)
                    {
                        selectedSeat = rb.Content.ToString()!;
                        rb.IsChecked = false;
                        rb.IsEnabled = false;
                        break;
                    }
                }
            }
            string selection = _selectedRouteId.ToString() + "  " + selectedSeat;
            if (!string.IsNullOrEmpty(selectedSeat))
            {
                Models.SeatsVM seat = new(_seat);
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