using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraScheduler;
using SchedulingDemo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchedulerCellTemplate
{
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    public class CellCustomizationDemoViewModel {
        protected CellCustomizationDemoViewModel() {
            isInitialization = true;
            Start = TeamData.Start;
            Calendars = new ObservableCollection<TeamCalendar>(TeamData.Calendars);
            Appointments = new ObservableCollection<TeamAppointment>(TeamData.AllAppointments);
            
            TimeRegions = new ObservableCollection<TimeRegion>(TeamData.TimeRegions);
            HighlightLunchHours = true;
            LunchStart = TimeRegions.First().Start;
            LunchEnd = TimeRegions.First().End;
            isInitialization = false;
        }
        bool isInitialization = false;

        public virtual IEnumerable<TeamCalendar> Calendars { get; protected set; }
        public virtual IEnumerable<TeamAppointment> Appointments { get; protected set; }

        public virtual IEnumerable<TimeRegion> TimeRegions { get; protected set; }

        public virtual DateTime Start { get; set; }
        public virtual bool HighlightLunchHours { get; set; }

        [BindableProperty(OnPropertyChangedMethodName = "OnLunchTimeChanged")]
        public virtual DateTime LunchStart { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "OnLunchTimeChanged")]
        public virtual DateTime LunchEnd { get; set; }

        [Command(false)]
        public void OnLunchTimeChanged()
        {
            if (isInitialization)
                return;
            var region = this.TimeRegions.First();
            region.Start = this.LunchStart;
            region.End = this.LunchEnd;
            RecurrenceInfo info = new RecurrenceInfo();
            info.FromXml(region.RecurrenceInfo);
            info.Start = region.Start;
            region.RecurrenceInfo = info.ToXml();
        }

        
    }

     
}
