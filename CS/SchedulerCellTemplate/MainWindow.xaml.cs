using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.VisualData;
using SchedulingDemo;
using System.Diagnostics;
using System.ComponentModel;
using DevExpress.Xpf.Scheduling.Visual;
using DevExpress.Xpf.Core.Native;
using DevExpress.Mvvm.UI;

namespace SchedulerCellTemplate {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    public class CellCustomizationDemoViewModel {
        protected CellCustomizationDemoViewModel() {
            Start = TeamData.Start;
            Calendars = new ObservableCollection<TeamCalendar>(TeamData.Calendars);
            Appointments = new ObservableCollection<TeamAppointment>(TeamData.AllAppointments);
            HighlightLunchHours = true;
            LunchStart = new TimeSpan(13, 15, 0);
            LunchEnd = new TimeSpan(14, 45, 0);
        }
        public virtual IEnumerable<TeamCalendar> Calendars { get; protected set; }
        public virtual IEnumerable<TeamAppointment> Appointments { get; protected set; }
        public virtual DateTime Start { get; set; }
        public virtual bool HighlightLunchHours { get; set; }

        public virtual TimeSpan LunchStart { get; set; }
        public virtual TimeSpan LunchEnd { get; set; }

        public TimeSpanRange GetLunchTime(DateTime dateTime, TeamCalendar resource) {
            if (resource == Calendars.ElementAt(0))
            {
                if (dateTime.TimeOfDay > LunchEnd )
                    return new TimeSpanRange(TimeSpan.FromHours(20), TimeSpan.FromHours(23));
                return new TimeSpanRange(LunchStart, LunchEnd);
            }
            return new TimeSpanRange(new TimeSpan(13, 0, 0), new TimeSpan(14, 0, 0));
        }
    }
    public class TimeSpanToDateTimeConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            TimeSpan v = (TimeSpan)value;
            return new DateTime(v.Ticks);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            DateTime v = (DateTime)value;
            return new TimeSpan(v.Ticks);
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }

    public class CellControlDecorator : FrameworkElement {
        public static readonly DependencyProperty LunchBrushProperty =
            DependencyProperty.Register("LunchBrush", typeof(Brush), typeof(CellControlDecorator), new PropertyMetadata(null, (d,e) => ((CellControlDecorator)d).OnLunchBrushChanged()));
        public Brush LunchBrush { get { return (Brush)GetValue(LunchBrushProperty); } set { SetValue(LunchBrushProperty, value); } }
        
        public CellControlDecorator() {
            DataContextChanged += OnDataContextChanged;
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        SchedulerControl Scheduler { get; set; }
        CellViewModel ViewModel { get; set; }
        object UnderlyingViewModel { get; set; }
        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
            var oldValue = ViewModel;
            ViewModel = e.NewValue as CellViewModel;
            OnViewModelChanged(oldValue, ViewModel);
            InvalidateVisual();
        }
        void OnLunchBrushChanged() {
            if (LunchBrush != null)
                LunchBrush.Freeze();
        }
        void OnLoaded(object sender, RoutedEventArgs e) {
            SchedulerControl oldValue = Scheduler;
            Scheduler = SchedulerControl.GetScheduler(this);
            OnSchedulerChanged(oldValue, Scheduler);
        }
        void OnUnloaded(object sender, RoutedEventArgs e) {
            SchedulerControl oldValue = Scheduler;
            Scheduler = null;
            OnSchedulerChanged(oldValue, Scheduler);
        }
        void OnSchedulerChanged(SchedulerControl oldValue, SchedulerControl newValue) {
            if(oldValue != null)
                oldValue.DataContextChanged -= OnSchedulerDataContextChanged;
            if(newValue != null)
                newValue.DataContextChanged += OnSchedulerDataContextChanged;
            UpdateUnderlyingViewModel();
        }
        void OnSchedulerDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
            UpdateUnderlyingViewModel();
        }
        void UpdateUnderlyingViewModel() {
            var oldValue = UnderlyingViewModel;
            if (Scheduler == null)
                UnderlyingViewModel = null;
            else UnderlyingViewModel = Scheduler.DataContext;
            OnUnderlyingViewModelChanged(oldValue, UnderlyingViewModel);
        }
        void OnUnderlyingViewModelChanged(object oldValue, object newValue) {
            if(oldValue is INotifyPropertyChanged)
                ((INotifyPropertyChanged)oldValue).PropertyChanged -= OnUnderlyingViewModelPropertyChanged;
            if (newValue is INotifyPropertyChanged)
                ((INotifyPropertyChanged)newValue).PropertyChanged += OnUnderlyingViewModelPropertyChanged;
            InvalidateVisual();
        }
        void OnUnderlyingViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            InvalidateVisual();
        }
        void OnViewModelChanged(CellViewModel oldValue, CellViewModel newValue) {
            if(oldValue != null)
                oldValue.PropertyChanged -= OnViewModelPropertyChanged;
            if (newValue != null)
                newValue.PropertyChanged += OnViewModelPropertyChanged;
        }
        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            InvalidateVisual();
        }
        TimeSpanRange GetLunchTime() {
            if (ViewModel == null || Scheduler == null) return TimeSpanRange.Zero;
            return ((CellCustomizationDemoViewModel)UnderlyingViewModel).GetLunchTime(ViewModel.Interval.Start, (TeamCalendar)ViewModel.Resource.SourceObject);
        }
   
        protected override void OnRender(DrawingContext drawingContext) {
            base.OnRender(drawingContext);
            if (ViewModel == null || Scheduler == null) return;
            if (ViewModel.IsSelected) return;
            DateTimeRange range = ViewModel.Interval;
            TimeSpanRange lunchTime = GetLunchTime();
            TimeSpan rangeDuration = range.End - range.Start;
            TimeSpan lunchStart = lunchTime.Start;
            TimeSpan lunchEnd = lunchTime.End;

            double relativeStart = 0;
            double relativeEnd = 0;
            
            if (range.Start.TimeOfDay < lunchEnd) {
                if (range.Start.TimeOfDay >= lunchStart) {
                    relativeStart = 0;
                } else if (range.End.TimeOfDay >= lunchStart) {
                    relativeStart = (lunchStart - range.Start.TimeOfDay).TotalMilliseconds / (double)rangeDuration.TotalMilliseconds;
                }
            }

            if (range.Start.TimeOfDay < lunchEnd && range.End.TimeOfDay > lunchStart) {
                if (range.End.TimeOfDay <= lunchEnd) {
                    relativeEnd = 1;
                } else if (range.Start.TimeOfDay >= lunchStart) {
                    relativeEnd = (lunchEnd - range.Start.TimeOfDay).TotalMilliseconds / (double)rangeDuration.TotalMilliseconds;
                }
            }

            if (relativeStart == 0 && relativeEnd == 0 || relativeEnd < relativeStart)
                return;

            if (relativeStart == 0 && relativeEnd == 1) {
                Rect rect = new Rect(RenderSize);
                drawingContext.DrawRectangle(LunchBrush, null, rect);
                
                return;
            }

            double y1 = RenderSize.Height * relativeStart;
            double y2 = RenderSize.Height * relativeEnd;
            

            Rect rectangle = new Rect(new Point(0, y1), new Size(RenderSize.Width, y2 - y1));
            drawingContext.DrawRectangle(LunchBrush, null, rectangle);
         
        }

     
    }
}
