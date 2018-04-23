Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI.Native
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.Xpf.Scheduling.VisualData
Imports SchedulingDemo
Imports System.Diagnostics
Imports System.ComponentModel
Imports DevExpress.Xpf.Scheduling.Visual
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Mvvm.UI

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
            HighlightLunchHours = True
            LunchStart = New TimeSpan(13, 15, 0)
            LunchEnd = New TimeSpan(14, 45, 0)
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

        Public Overridable Property LunchStart() As TimeSpan
        Public Overridable Property LunchEnd() As TimeSpan

        Public Function GetLunchTime(ByVal dateTime As Date, ByVal resource As TeamCalendar) As TimeSpanRange
            If resource Is Calendars.ElementAt(0) Then
                If dateTime.TimeOfDay > LunchEnd Then
                    Return New TimeSpanRange(TimeSpan.FromHours(20), TimeSpan.FromHours(23))
                End If
                Return New TimeSpanRange(LunchStart, LunchEnd)
            End If
            Return New TimeSpanRange(New TimeSpan(13, 0, 0), New TimeSpan(14, 0, 0))
        End Function
    End Class
    Public Class TimeSpanToDateTimeConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim v As TimeSpan = DirectCast(value, TimeSpan)
            Return New Date(v.Ticks)
        End Function
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Dim v As Date = DirectCast(value, Date)
            Return New TimeSpan(v.Ticks)
        End Function

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class

    Public Class CellControlDecorator
        Inherits FrameworkElement

        Public Shared ReadOnly LunchBrushProperty As DependencyProperty = DependencyProperty.Register("LunchBrush", GetType(Brush), GetType(CellControlDecorator), New PropertyMetadata(Nothing, Sub(d,e) CType(d, CellControlDecorator).OnLunchBrushChanged()))
        Public Property LunchBrush() As Brush
            Get
                Return DirectCast(GetValue(LunchBrushProperty), Brush)
            End Get
            Set(ByVal value As Brush)
                SetValue(LunchBrushProperty, value)
            End Set
        End Property

        Public Sub New()
            AddHandler DataContextChanged, AddressOf OnDataContextChanged
            AddHandler Loaded, AddressOf OnLoaded
            AddHandler Unloaded, AddressOf OnUnloaded
        End Sub
        Private Property Scheduler() As SchedulerControl
        Private Property ViewModel() As CellViewModel
        Private Property UnderlyingViewModel() As Object
        Private Sub OnDataContextChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
            Dim oldValue = ViewModel
            ViewModel = TryCast(e.NewValue, CellViewModel)
            OnViewModelChanged(oldValue, ViewModel)
            InvalidateVisual()
        End Sub
        Private Sub OnLunchBrushChanged()
            If LunchBrush IsNot Nothing Then
                LunchBrush.Freeze()
            End If
        End Sub
        Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim oldValue As SchedulerControl = Scheduler
            Scheduler = SchedulerControl.GetScheduler(Me)
            OnSchedulerChanged(oldValue, Scheduler)
        End Sub
        Private Sub OnUnloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim oldValue As SchedulerControl = Scheduler
            Scheduler = Nothing
            OnSchedulerChanged(oldValue, Scheduler)
        End Sub
        Private Sub OnSchedulerChanged(ByVal oldValue As SchedulerControl, ByVal newValue As SchedulerControl)
            If oldValue IsNot Nothing Then
                RemoveHandler oldValue.DataContextChanged, AddressOf OnSchedulerDataContextChanged
            End If
            If newValue IsNot Nothing Then
                AddHandler newValue.DataContextChanged, AddressOf OnSchedulerDataContextChanged
            End If
            UpdateUnderlyingViewModel()
        End Sub
        Private Sub OnSchedulerDataContextChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
            UpdateUnderlyingViewModel()
        End Sub
        Private Sub UpdateUnderlyingViewModel()
            Dim oldValue = UnderlyingViewModel
            If Scheduler Is Nothing Then
                UnderlyingViewModel = Nothing
            Else
                UnderlyingViewModel = Scheduler.DataContext
            End If
            OnUnderlyingViewModelChanged(oldValue, UnderlyingViewModel)
        End Sub
        Private Sub OnUnderlyingViewModelChanged(ByVal oldValue As Object, ByVal newValue As Object)
            If TypeOf oldValue Is INotifyPropertyChanged Then
                RemoveHandler DirectCast(oldValue, INotifyPropertyChanged).PropertyChanged, AddressOf OnUnderlyingViewModelPropertyChanged
            End If
            If TypeOf newValue Is INotifyPropertyChanged Then
                AddHandler DirectCast(newValue, INotifyPropertyChanged).PropertyChanged, AddressOf OnUnderlyingViewModelPropertyChanged
            End If
            InvalidateVisual()
        End Sub
        Private Sub OnUnderlyingViewModelPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            InvalidateVisual()
        End Sub
        Private Sub OnViewModelChanged(ByVal oldValue As CellViewModel, ByVal newValue As CellViewModel)
            If oldValue IsNot Nothing Then
                RemoveHandler oldValue.PropertyChanged, AddressOf OnViewModelPropertyChanged
            End If
            If newValue IsNot Nothing Then
                AddHandler newValue.PropertyChanged, AddressOf OnViewModelPropertyChanged
            End If
        End Sub
        Private Sub OnViewModelPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            InvalidateVisual()
        End Sub
        Private Function GetLunchTime() As TimeSpanRange
            If ViewModel Is Nothing OrElse Scheduler Is Nothing Then
                Return TimeSpanRange.Zero
            End If
            Return (DirectCast(UnderlyingViewModel, CellCustomizationDemoViewModel)).GetLunchTime(ViewModel.Interval.Start, CType(ViewModel.Resource.SourceObject, TeamCalendar))
        End Function

        Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
            MyBase.OnRender(drawingContext)
            If ViewModel Is Nothing OrElse Scheduler Is Nothing Then
                Return
            End If
            If ViewModel.IsSelected Then
                Return
            End If
            Dim range As DateTimeRange = ViewModel.Interval
            Dim lunchTime As TimeSpanRange = GetLunchTime()
            Dim rangeDuration As TimeSpan = range.End - range.Start
            Dim lunchStart As TimeSpan = lunchTime.Start
            Dim lunchEnd As TimeSpan = lunchTime.End

            Dim relativeStart As Double = 0
            Dim relativeEnd As Double = 0

            If range.Start.TimeOfDay < lunchEnd Then
                If range.Start.TimeOfDay >= lunchStart Then
                    relativeStart = 0
                ElseIf range.End.TimeOfDay >= lunchStart Then
                    relativeStart = (lunchStart - range.Start.TimeOfDay).TotalMilliseconds / CDbl(rangeDuration.TotalMilliseconds)
                End If
            End If

            If range.Start.TimeOfDay < lunchEnd AndAlso range.End.TimeOfDay > lunchStart Then
                If range.End.TimeOfDay <= lunchEnd Then
                    relativeEnd = 1
                ElseIf range.Start.TimeOfDay >= lunchStart Then
                    relativeEnd = (lunchEnd - range.Start.TimeOfDay).TotalMilliseconds / CDbl(rangeDuration.TotalMilliseconds)
                End If
            End If

            If relativeStart = 0 AndAlso relativeEnd = 0 OrElse relativeEnd < relativeStart Then
                Return
            End If

            If relativeStart = 0 AndAlso relativeEnd = 1 Then
                Dim rect As New Rect(RenderSize)
                drawingContext.DrawRectangle(LunchBrush, Nothing, rect)

                Return
            End If

            Dim y1 As Double = RenderSize.Height * relativeStart
            Dim y2 As Double = RenderSize.Height * relativeEnd


            Dim rectangle As New Rect(New Point(0, y1), New Size(RenderSize.Width, y2 - y1))
            drawingContext.DrawRectangle(LunchBrush, Nothing, rectangle)

        End Sub


    End Class
End Namespace
