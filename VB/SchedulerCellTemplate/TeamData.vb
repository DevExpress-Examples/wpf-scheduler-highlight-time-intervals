Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Mvvm
Imports DevExpress.XtraScheduler

Namespace SchedulingDemo

    Public Class TeamCalendar

        Public Property Id As Integer

        Public Property Name As String
    End Class

    Public Class TeamAppointment

        Public Property Id As Integer

        Public Property AppointmentType As Integer

        Public Property AllDay As Boolean

        Public Property Start As DateTime

        Public Property [End] As DateTime

        Public Property Subject As String

        Public Property Description As String

        Public Property Status As Integer

        Public Property Label As Integer

        Public Property Location As String

        Public Property CalendarId As Integer

        Public Property RecurrenceInfo As String

        Public Property ReminderInfo As String
    End Class

    Public Class Employee

        Public Property FirstName As String

        Public Property LastName As String

        Public Property BirthDate As System.DateTime?
    End Class

    Public Module TeamData

        Private _Start As DateTime, _Calendars As IEnumerable(Of SchedulingDemo.TeamCalendar), _AllAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _VacationAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _BirthdayAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _ConferenceAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _MeetingAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _PhoneCallsAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _CarWashAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _CompanyBirthdayAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _TrainingAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _PayBillsAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _DentistAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment), _RestaurantAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)

        Sub New()
            SchedulingDemo.TeamData.Random = New System.Random()
            SchedulingDemo.TeamData.Start = SchedulingDemo.TeamData.GetStart()
            If DevExpress.Mvvm.ViewModelBase.IsInDesignMode Then
                SchedulingDemo.TeamData.Employees = New System.Collections.Generic.List(Of SchedulingDemo.Employee)()
                SchedulingDemo.TeamData.Calendars = SchedulingDemo.TeamData.CreateCalendars().ToList()
                SchedulingDemo.TeamData.VacationAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.CompanyBirthdayAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.BirthdayAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.ConferenceAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.MeetingAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.PhoneCallsAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.CarWashAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.PayBillsAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.DentistAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.RestaurantAppointments = New SchedulingDemo.TeamAppointment() {}
                SchedulingDemo.TeamData.AllAppointments = New SchedulingDemo.TeamAppointment() {}
                Return
            End If

            SchedulingDemo.TeamData.Employees = New System.Collections.Generic.List(Of SchedulingDemo.Employee)()
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John1", .LastName = "Smith1"})
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John2", .LastName = "Smith2"})
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John3", .LastName = "Smith3"})
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John4", .LastName = "Smith4"})
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John5", .LastName = "Smith5"})
            Call SchedulingDemo.TeamData.Employees.Add(New SchedulingDemo.Employee() With {.FirstName = "John6", .LastName = "Smith6"})
            SchedulingDemo.TeamData.Employees(CInt((0))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((4))).AddYears(-30)
            SchedulingDemo.TeamData.Employees(CInt((1))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((1))).AddYears(-27)
            SchedulingDemo.TeamData.Employees(CInt((2))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((14))).AddYears(-32)
            SchedulingDemo.TeamData.Employees(CInt((3))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((-8))).AddYears(-41)
            SchedulingDemo.TeamData.Employees(CInt((4))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((-18))).AddYears(-41)
            SchedulingDemo.TeamData.Employees(CInt((5))).BirthDate = SchedulingDemo.TeamData.Start.AddDays(CDbl((48))).AddYears(-25)
            SchedulingDemo.TeamData.Calendars = SchedulingDemo.TeamData.CreateCalendars().ToList()
            SchedulingDemo.TeamData.VacationAppointments = SchedulingDemo.TeamData.CreateVacationsAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.CompanyBirthdayAppointments = SchedulingDemo.TeamData.CreateCompanyBirthdayAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.BirthdayAppointments = SchedulingDemo.TeamData.CreateBirthdayAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.ConferenceAppointments = SchedulingDemo.TeamData.CreateConferenceAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.MeetingAppointments = SchedulingDemo.TeamData.CreateMeetingAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.PhoneCallsAppointments = SchedulingDemo.TeamData.CreatePhoneCallsAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.CarWashAppointments = SchedulingDemo.TeamData.CreateCarWashAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.TrainingAppointments = SchedulingDemo.TeamData.CreateTrainingAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.PayBillsAppointments = SchedulingDemo.TeamData.CreatePayBillsAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.DentistAppointments = SchedulingDemo.TeamData.CreateDentistAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.RestaurantAppointments = SchedulingDemo.TeamData.CreateRestaurantAppts(SchedulingDemo.TeamData.Start).ToList()
            SchedulingDemo.TeamData.AllAppointments = SchedulingDemo.TeamData.VacationAppointments.Concat(SchedulingDemo.TeamData.BirthdayAppointments).Concat(SchedulingDemo.TeamData.CompanyBirthdayAppointments).Concat(SchedulingDemo.TeamData.ConferenceAppointments).Concat(SchedulingDemo.TeamData.MeetingAppointments).Concat(SchedulingDemo.TeamData.PhoneCallsAppointments).Concat(SchedulingDemo.TeamData.CarWashAppointments).Concat(SchedulingDemo.TeamData.TrainingAppointments).Concat(SchedulingDemo.TeamData.PayBillsAppointments).Concat(SchedulingDemo.TeamData.DentistAppointments).Concat(SchedulingDemo.TeamData.RestaurantAppointments).ToList()
            Dim id As Integer = 0
            For Each appt As SchedulingDemo.TeamAppointment In SchedulingDemo.TeamData.AllAppointments
                appt.Id = System.Math.Min(System.Threading.Interlocked.Increment(id), id - 1)
            Next
        End Sub

        Public Property Start As DateTime
            Get
                Return _Start
            End Get

            Private Set(ByVal value As DateTime)
                _Start = value
            End Set
        End Property

        Public Property Calendars As IEnumerable(Of SchedulingDemo.TeamCalendar)
            Get
                Return _Calendars
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamCalendar))
                _Calendars = value
            End Set
        End Property

        Public ReadOnly Property MyCalendar As TeamCalendar
            Get
                Return SchedulingDemo.TeamData.Calendars.ElementAt(0)
            End Get
        End Property

        Public ReadOnly Property TeamCalendar As TeamCalendar
            Get
                Return SchedulingDemo.TeamData.Calendars.ElementAt(1)
            End Get
        End Property

        Public Property AllAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _AllAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _AllAppointments = value
            End Set
        End Property

        Public Property VacationAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _VacationAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _VacationAppointments = value
            End Set
        End Property

        Public Property BirthdayAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _BirthdayAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _BirthdayAppointments = value
            End Set
        End Property

        Public Property ConferenceAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _ConferenceAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _ConferenceAppointments = value
            End Set
        End Property

        Public Property MeetingAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _MeetingAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _MeetingAppointments = value
            End Set
        End Property

        Public Property PhoneCallsAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _PhoneCallsAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _PhoneCallsAppointments = value
            End Set
        End Property

        Public Property CarWashAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _CarWashAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _CarWashAppointments = value
            End Set
        End Property

        Public Property CompanyBirthdayAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _CompanyBirthdayAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _CompanyBirthdayAppointments = value
            End Set
        End Property

        Public Property TrainingAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _TrainingAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _TrainingAppointments = value
            End Set
        End Property

        Public Property PayBillsAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _PayBillsAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _PayBillsAppointments = value
            End Set
        End Property

        Public Property DentistAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _DentistAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _DentistAppointments = value
            End Set
        End Property

        Public Property RestaurantAppointments As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Get
                Return _RestaurantAppointments
            End Get

            Private Set(ByVal value As IEnumerable(Of SchedulingDemo.TeamAppointment))
                _RestaurantAppointments = value
            End Set
        End Property

        Private ReadOnly Employees As System.Collections.Generic.List(Of SchedulingDemo.Employee)

        Private ReadOnly Random As System.Random

        Private Function GetStart() As DateTime
            Dim today As System.DateTime = System.DateTime.Today
            Dim dayOfWeek As System.DayOfWeek = today.DayOfWeek
            If dayOfWeek = System.DayOfWeek.Monday Then Return today
            If dayOfWeek = System.DayOfWeek.Sunday Then Return today.AddDays(1)
            Return today.AddDays(-(CInt(dayOfWeek) - 1))
        End Function

        Private Function GetRandomEmployee() As Employee
            Return SchedulingDemo.TeamData.Employees(SchedulingDemo.TeamData.Random.[Next](0, SchedulingDemo.TeamData.Employees.Count))
        End Function

        Private Function CreateCalendars() As IEnumerable(Of SchedulingDemo.TeamCalendar)
            Return New SchedulingDemo.TeamCalendar() {New SchedulingDemo.TeamCalendar() With {.Id = 0, .Name = "My Calendar"}, New SchedulingDemo.TeamCalendar() With {.Id = 1, .Name = "Team Calendar"}}
        End Function

        Private Function CreateBirthdayAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Return SchedulingDemo.TeamData.Employees.[Select](New Global.System.Func(Of Global.SchedulingDemo.Employee, Global.SchedulingDemo.TeamAppointment)(AddressOf SchedulingDemo.TeamData.CreateBirthdayAppt))
        End Function

        Private Function CreateBirthdayAppt(ByVal employee As SchedulingDemo.Employee) As TeamAppointment
            If employee.BirthDate Is Nothing Then Return Nothing
            Dim [date] As System.DateTime = employee.BirthDate.Value
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern), .AllDay = True, .Start = [date], .[End] = [date].AddDays(1), .Subject = String.Format("{0}'s Birthday", employee.FirstName), .Status = 0, .Label = 8, .CalendarId = 0}
            appt.RecurrenceInfo = New DevExpress.XtraScheduler.RecurrenceInfo() With {.AllDay = True, .Start = [date], .Month = [date].Month, .DayNumber = [date].Day, .WeekOfMonth = DevExpress.XtraScheduler.WeekOfMonth.None, .Type = DevExpress.XtraScheduler.RecurrenceType.Yearly, .Range = DevExpress.XtraScheduler.RecurrenceRange.NoEndDate}.ToXml()
            Return appt
        End Function

        Private Function CreateConferenceAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim newStart As System.DateTime = start
            Dim thisWeekList As System.Tuple(Of String, System.DateTime)() = {System.Tuple.Create("DevExpress MVVM Framework", newStart.AddDays(CDbl((1))).AddHours(15)), System.Tuple.Create("New Theme Designer", newStart.AddDays(CDbl((2))).AddHours(14)), System.Tuple.Create("GridControl Performance Optimization", newStart.AddDays(CDbl((3))).AddHours(16)), System.Tuple.Create("WinForms and DirectX", newStart.AddDays(CDbl((4))).AddHours(16))}
            newStart = start.AddDays(-7)
            Dim prevWeekList As System.Tuple(Of String, System.DateTime)() = {System.Tuple.Create("LOB applications", newStart.AddDays(CDbl((1))).AddHours(13)), System.Tuple.Create("Module Injection Framework", newStart.AddDays(CDbl((2))).AddHours(16)), System.Tuple.Create("Git tricks", newStart.AddDays(CDbl((3))).AddHours(10)), System.Tuple.Create("Machine learning", newStart.AddDays(CDbl((4))).AddHours(11))}
            newStart = start.AddDays(7)
            Dim nextWeekList As System.Tuple(Of String, System.DateTime)() = {System.Tuple.Create("Azure", newStart.AddDays(CDbl((1))).AddHours(13)), System.Tuple.Create("WCF Services", newStart.AddDays(CDbl((2))).AddHours(16)), System.Tuple.Create("Docking Floating Panels", newStart.AddDays(CDbl((3))).AddHours(10)), System.Tuple.Create("Personal Time Management", newStart.AddDays(CDbl((4))).AddHours(11))}
            newStart = start.AddDays(14)
            Dim nextNextWeekList As System.Tuple(Of String, System.DateTime)() = {System.Tuple.Create("Entity Framework Core", newStart.AddDays(CDbl((1))).AddHours(10)), System.Tuple.Create(".Net Core", newStart.AddDays(CDbl((2))).AddHours(16))}
            Dim list As System.Collections.Generic.IEnumerable(Of System.Tuple(Of String, System.DateTime)) = thisWeekList.Concat(prevWeekList).Concat(nextWeekList).Concat(nextNextWeekList)
            Dim commonList As System.Collections.Generic.List(Of System.Tuple(Of String, System.DateTime)) = New System.Collections.Generic.List(Of System.Tuple(Of String, System.DateTime))()
            Dim interval As DevExpress.Mvvm.DateTimeRange = New DevExpress.Mvvm.DateTimeRange(start.AddDays(-7), start.AddDays(21))
            Dim subjects As System.Collections.Generic.IEnumerable(Of String) = list.[Select](Function(x) x.Item1)
            For i As Integer = 0 To 100 - 1
                newStart = start.AddYears(-1)
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](2 * 365))
                newStart = newStart.AddHours(SchedulingDemo.TeamData.Random.[Next](9, 18))
                If interval.Start <= newStart AndAlso interval.[End] >= newStart Then Continue For
                Dim subj As String = subjects.ElementAt(SchedulingDemo.TeamData.Random.[Next](0, subjects.Count()))
                commonList.Add(System.Tuple.Create(subj, newStart))
            Next

            Return list.Concat(commonList).[Select](Function(x) SchedulingDemo.TeamData.CreateConferenceAppt(x.Item1, x.Item2))
        End Function

        Private Function CreateConferenceAppt(ByVal subject As String, ByVal start As System.DateTime) As TeamAppointment
            Dim emp As SchedulingDemo.Employee = SchedulingDemo.TeamData.GetRandomEmployee()
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = start, .[End] = start.AddHours(1.5), .Subject = String.Format("Conference: {0}", subject), .Description = String.Format("{0} {1} tells us about {2}.", emp.FirstName, emp.LastName, subject), .Status = 2, .Label = 2, .Location = "Conference Room", .CalendarId = 1}
            Return appt
        End Function

        Private Function CreateMeetingAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim res As System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment) = New System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment)() From {SchedulingDemo.TeamData.CreateMeetingRecurrenceAppt("Weekly meeting", start.AddMonths(CInt((-6))).Add(New System.TimeSpan(5, 14, 00, 0))), SchedulingDemo.TeamData.CreateLunchAppt(SchedulingDemo.TeamData.Employees(0), start.AddDays(CDbl((1))).AddHours(13)), SchedulingDemo.TeamData.CreateLunchAppt(SchedulingDemo.TeamData.Employees(1), start.AddDays(CDbl((3))).AddHours(13)), SchedulingDemo.TeamData.CreateLunchAppt(SchedulingDemo.TeamData.Employees(2), start.AddDays(CDbl((-4))).AddHours(13)), SchedulingDemo.TeamData.CreateLunchAppt(SchedulingDemo.TeamData.Employees(3), start.AddDays(CDbl((9))).AddHours(13)), SchedulingDemo.TeamData.CreateLunchAppt(SchedulingDemo.TeamData.Employees(4), start.AddDays(CDbl((12))).AddHours(13))}
            Dim interval As DevExpress.Mvvm.DateTimeRange = New DevExpress.Mvvm.DateTimeRange(start.AddDays(-7), start.AddDays(21))
            Dim days As System.Collections.Generic.List(Of Integer) = New System.Collections.Generic.List(Of Integer)()
            For i As Integer = 0 To 50 - 1
                Dim emp As SchedulingDemo.Employee = SchedulingDemo.TeamData.Employees(SchedulingDemo.TeamData.Random.[Next](0, SchedulingDemo.TeamData.Employees.Count))
                Dim newStart As System.DateTime = start.AddYears(-1)
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](365))
                If interval.Start <= newStart AndAlso interval.[End] >= newStart Then Continue For
                If days.Contains(newStart.DayOfYear) Then Continue For
                If SchedulingDemo.TeamData.VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.[End] >= newStart) Then Continue For
                days.Add(newStart.DayOfYear)
                res.Add(SchedulingDemo.TeamData.CreateLunchAppt(emp, newStart.AddHours(13)))
            Next

            Return res
        End Function

        Private Function CreateMeetingRecurrenceAppt(ByVal subject As String, ByVal start As System.DateTime) As TeamAppointment
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern), .AllDay = False, .Start = start, .[End] = start.AddHours(1), .Subject = subject, .Status = 2, .Label = 2, .CalendarId = 1}
            appt.RecurrenceInfo = New DevExpress.XtraScheduler.RecurrenceInfo() With {.Start = start, .Type = DevExpress.XtraScheduler.RecurrenceType.Weekly, .WeekDays = DevExpress.XtraScheduler.WeekDays.Friday, .Month = 12, .Range = DevExpress.XtraScheduler.RecurrenceRange.NoEndDate}.ToXml()
            Return appt
        End Function

        Private Function CreateLunchAppt(ByVal emp As SchedulingDemo.Employee, ByVal start As System.DateTime) As TeamAppointment
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = start, .[End] = start.AddHours(1), .Subject = String.Format("Lunch with {0}", emp.FirstName), .Status = 3, .Label = 3, .CalendarId = 0}
            Return appt
        End Function

        Private Function CreatePhoneCallsAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim res As System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment) = New System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment)() From {SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(0), start.AddDays(CDbl((0))).AddHours(10)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(1), start.AddDays(CDbl((3))).AddHours(11)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(2), start.AddDays(CDbl((3))).AddHours(CDbl((12))).AddMinutes(40), System.TimeSpan.FromMinutes(15)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(3), start.AddDays(CDbl((-4))).AddHours(14)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(4), start.AddDays(CDbl((9))).AddHours(15)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.Employees(5), start.AddDays(CDbl((12))).AddHours(15)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((0))).AddHours(16)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((2))).AddHours(15.6)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((4))).AddHours(15)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((5))).AddHours(10.5)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((5))).AddHours(16)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((6))).AddHours(9.7)), SchedulingDemo.TeamData.CreatePhoneCallAppt(SchedulingDemo.TeamData.GetRandomEmployee(), start.AddDays(CDbl((6))).AddHours(16.8))}
            Dim interval As DevExpress.Mvvm.DateTimeRange = New DevExpress.Mvvm.DateTimeRange(start.AddDays(-7), start.AddDays(21))
            For i As Integer = 0 To 50 - 1
                Dim emp As SchedulingDemo.Employee = SchedulingDemo.TeamData.Employees(SchedulingDemo.TeamData.Random.[Next](0, SchedulingDemo.TeamData.Employees.Count))
                Dim newStart As System.DateTime = start.AddYears(-1)
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](365))
                If interval.Start <= newStart AndAlso interval.[End] >= newStart Then Continue For
                If SchedulingDemo.TeamData.VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.[End] >= newStart) Then Continue For
                res.Add(SchedulingDemo.TeamData.CreatePhoneCallAppt(emp, newStart.AddHours(SchedulingDemo.TeamData.Random.[Next](9, 18))))
            Next

            Return res
        End Function

        Private Function CreatePhoneCallAppt(ByVal emp As SchedulingDemo.Employee, ByVal start As System.DateTime, ByVal Optional duration As System.TimeSpan? = Nothing) As TeamAppointment
            Dim newStart As System.DateTime = start.AddMinutes(SchedulingDemo.TeamData.Random.[Next](0, 4) * 15)
            Dim newEnd As System.DateTime = If(duration IsNot Nothing, newStart.Add(duration.Value), newStart.AddMinutes(SchedulingDemo.TeamData.Random.[Next](1, 6) * 5))
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = newStart, .[End] = newEnd, .Subject = String.Format("Phone Call with {0}", emp.FirstName), .Status = 2, .Label = 10, .CalendarId = 0}
            Return appt
        End Function

        Private Function CreateVacationsAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Return {New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = True, .Start = start.AddMonths(-6), .[End] = start.AddMonths(CInt((-6))).AddDays(14), .Subject = String.Format("Vacation"), .Status = 0, .Label = 4, .CalendarId = 0}, New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = True, .Start = start.AddMonths(6), .[End] = start.AddMonths(CInt((6))).AddDays(14), .Subject = String.Format("Vacation"), .Status = 0, .Label = 4, .CalendarId = 0}, New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = True, .Start = start.AddDays(4), .[End] = start.AddDays(8), .Subject = String.Format("Vacation"), .Status = 0, .Label = 4, .CalendarId = 0}}
        End Function

        Private Function CreateCarWashAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim res As System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment) = New System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment)() From {SchedulingDemo.TeamData.CreateCarWashAppt(start.AddDays(CDbl((1))).AddHours(17))}
            Dim newStart As System.DateTime = start.AddYears(-1)
            While newStart < start.AddMonths(1)
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](18, 35))
                If SchedulingDemo.TeamData.VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.[End] >= newStart) Then Continue While
                If newStart >= start AndAlso newStart <= start.AddDays(7) Then Continue While
                Call SchedulingDemo.TeamData.CreateCarWashAppt(newStart)
            End While

            Return res
        End Function

        Private Function CreateCarWashAppt(ByVal start As System.DateTime) As TeamAppointment
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = start, .[End] = start.AddHours(1), .Subject = String.Format("Car Wash"), .Status = 3, .Label = 3, .CalendarId = 0}
            Return appt
        End Function

        Private Function CreateCompanyBirthdayAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim newStart As System.DateTime = New System.DateTime(start.Year - 1, start.Month, start.Day)
            newStart = newStart.AddDays(5)
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern), .AllDay = True, .Start = newStart, .[End] = newStart.AddDays(1), .Subject = "Company Birthday Party", .Status = 0, .Label = 8, .CalendarId = 1}
            appt.RecurrenceInfo = New DevExpress.XtraScheduler.RecurrenceInfo() With {.AllDay = True, .Start = newStart, .Type = DevExpress.XtraScheduler.RecurrenceType.Yearly, .Month = newStart.Month, .DayNumber = newStart.Day, .WeekOfMonth = DevExpress.XtraScheduler.WeekOfMonth.None, .Range = DevExpress.XtraScheduler.RecurrenceRange.NoEndDate}.ToXml()
            Return {appt}
        End Function

        Private Function CreateTrainingAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim newStart As System.DateTime = start.AddYears(CInt((-1))).AddHours(8.5)
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern), .AllDay = False, .Start = newStart, .[End] = newStart.AddHours(1.5), .Subject = "Sport Training", .Status = 1, .Label = 3, .CalendarId = 0}
            appt.RecurrenceInfo = New DevExpress.XtraScheduler.RecurrenceInfo() With {.AllDay = False, .Start = newStart, .Type = DevExpress.XtraScheduler.RecurrenceType.Weekly, .WeekDays = DevExpress.XtraScheduler.WeekDays.Monday Or DevExpress.XtraScheduler.WeekDays.Wednesday Or DevExpress.XtraScheduler.WeekDays.Friday, .Range = DevExpress.XtraScheduler.RecurrenceRange.NoEndDate}.ToXml()
            Return {appt}
        End Function

        Private Function CreatePayBillsAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim newStart As System.DateTime = start.AddDays(CDbl((2))).AddYears(-1)
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern), .AllDay = True, .Start = newStart, .[End] = newStart.AddDays(1), .Subject = "Pay Bills", .Status = 0, .Label = 3, .CalendarId = 0}
            appt.RecurrenceInfo = New DevExpress.XtraScheduler.RecurrenceInfo() With {.AllDay = True, .Start = newStart, .Type = DevExpress.XtraScheduler.RecurrenceType.Monthly, .DayNumber = newStart.Day, .WeekOfMonth = DevExpress.XtraScheduler.WeekOfMonth.None, .Range = DevExpress.XtraScheduler.RecurrenceRange.NoEndDate}.ToXml()
            Return {appt}
        End Function

        Private Function CreateDentistAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim res As System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment) = New System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment)() From {SchedulingDemo.TeamData.CreateDentistAppt(start.AddDays(CDbl((4))).AddHours(17.5))}
            Dim newStart As System.DateTime = start.AddYears(-2)
            While newStart < start
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](365 \ 3, 365 \ 2))
                Call SchedulingDemo.TeamData.CreateDentistAppt(newStart)
            End While

            Return res
        End Function

        Private Function CreateDentistAppt(ByVal start As System.DateTime) As TeamAppointment
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = start, .[End] = start.AddHours(2), .Subject = String.Format("Dentist"), .Status = 3, .Label = 3, .CalendarId = 0}
            Return appt
        End Function

        Private Function CreateRestaurantAppts(ByVal start As System.DateTime) As IEnumerable(Of SchedulingDemo.TeamAppointment)
            Dim res As System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment) = New System.Collections.Generic.List(Of SchedulingDemo.TeamAppointment)() From {SchedulingDemo.TeamData.CreateDinnerAppt(start.AddDays(CDbl((2))).AddHours(19)), SchedulingDemo.TeamData.CreateDinnerAppt(start.AddDays(CDbl((14))).AddHours(19)), SchedulingDemo.TeamData.CreateDinnerAppt(start.AddDays(CDbl((18))).AddHours(21))}
            Dim newStart As System.DateTime = start.AddYears(-2)
            While newStart < start
                newStart = newStart.AddDays(SchedulingDemo.TeamData.Random.[Next](14, 42))
                res.Add(SchedulingDemo.TeamData.CreateDinnerAppt(newStart.AddHours(SchedulingDemo.TeamData.Random.[Next](18, 22))))
            End While

            Return res
        End Function

        Private Function CreateDinnerAppt(ByVal start As System.DateTime, ByVal Optional duration As System.TimeSpan? = Nothing) As TeamAppointment
            Dim newStart As System.DateTime = start.AddMinutes(SchedulingDemo.TeamData.Random.[Next](0, 4) * 15)
            Dim newEnd As System.DateTime = If(duration IsNot Nothing, newStart.Add(duration.Value), newStart.AddMinutes(SchedulingDemo.TeamData.Random.[Next](4, 8) * 20))
            Dim appt = New SchedulingDemo.TeamAppointment() With {.AppointmentType = CInt(DevExpress.XtraScheduler.AppointmentType.Normal), .AllDay = False, .Start = newStart, .[End] = newEnd, .Subject = String.Format("Dinner"), .Status = 0, .Label = 5, .CalendarId = 0}
            Return appt
        End Function
    End Module
End Namespace
