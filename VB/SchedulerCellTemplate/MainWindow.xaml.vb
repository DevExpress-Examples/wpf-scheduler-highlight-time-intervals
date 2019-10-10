Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.XtraScheduler
Imports SchedulingDemo

Namespace SchedulerCellTemplate
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
    Public Class CellCustomizationDemoViewModel
        Protected Sub New()
            Start = TeamData.Start
            Calendars = New ObservableCollection(Of TeamCalendar)(TeamData.Calendars)
            Appointments = New ObservableCollection(Of TeamAppointment)(TeamData.AllAppointments)
            TimeRegions = New ObservableCollection(Of TimeRegion)(TeamData.TimeRegions)
            HighlightLunchHours = True
            isInitialization = True

            LunchStart = TimeRegions.First().Start
            LunchEnd = TimeRegions.First().End

            isInitialization = False

        End Sub
        Private privateCalendars As IEnumerable(Of TeamCalendar)
        Public Overridable Property Calendars() As IEnumerable(Of TeamCalendar)
            Get
                Return privateCalendars
            End Get
            Protected Set(ByVal value As IEnumerable(Of TeamCalendar))
                privateCalendars = value
            End Set
        End Property

        Public Overridable Property TimeRegions As IEnumerable(Of TimeRegion)

        Private privateAppointments As IEnumerable(Of TeamAppointment)
        Public Overridable Property Appointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateAppointments
            End Get
            Protected Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateAppointments = value
            End Set
        End Property
        Public Overridable Property Start() As Date
        Public Overridable Property HighlightLunchHours() As Boolean

        Dim isInitialization As Boolean = False

        <BindableProperty(OnPropertyChangedMethodName:="OnLunchTimeChanged")>
        Public Overridable Property LunchStart As DateTime
        <BindableProperty(OnPropertyChangedMethodName:="OnLunchTimeChanged")>
        Public Overridable Property LunchEnd As DateTime

        <Command(False)>
        Public Sub OnLunchTimeChanged()
            If isInitialization Then Return
            Dim region = Me.TimeRegions.First()
            region.Start = Me.LunchStart
            region.[End] = Me.LunchEnd
            Dim info As RecurrenceInfo = New RecurrenceInfo()
            info.FromXml(region.RecurrenceInfo)
            info.Start = info.Start.Date.AddTicks(region.Start.TimeOfDay.Ticks)
            region.RecurrenceInfo = info.ToXml()
        End Sub
    End Class

End Namespace
