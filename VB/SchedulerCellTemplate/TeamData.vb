Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Mvvm
Imports DevExpress.XtraScheduler

Namespace SchedulingDemo
    Public Class TeamCalendar
        Public Property Id() As Integer
        Public Property Name() As String
    End Class
    Public Class TeamAppointment
        Public Property Id() As Integer
        Public Property AppointmentType() As Integer
        Public Property AllDay() As Boolean
        Public Property Start() As Date
        Public Property [End]() As Date

        Public Property Subject() As String
        Public Property Description() As String
        Public Property Status() As Integer
        Public Property Label() As Integer
        Public Property Location() As String
        Public Property CalendarId() As Integer

        Public Property RecurrenceInfo() As String
        Public Property ReminderInfo() As String
    End Class

    Public Class Employee
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property BirthDate() As Date?
    End Class

    Public NotInheritable Class TeamData

        Private Sub New()
        End Sub

        Shared Sub New()
            Random = New Random()
            Start = GetStart()

            If ViewModelBase.IsInDesignMode Then
                Employees = New List(Of Employee)()
                Calendars = CreateCalendars().ToList()
                VacationAppointments = New TeamAppointment() { }
                CompanyBirthdayAppointments = New TeamAppointment() { }
                BirthdayAppointments = New TeamAppointment() { }
                ConferenceAppointments = New TeamAppointment() { }
                MeetingAppointments = New TeamAppointment() { }
                PhoneCallsAppointments = New TeamAppointment() { }
                CarWashAppointments = New TeamAppointment() { }
                PayBillsAppointments = New TeamAppointment() { }
                DentistAppointments = New TeamAppointment() { }
                RestaurantAppointments = New TeamAppointment() { }
                AllAppointments = New TeamAppointment() { }
                Return
            End If

            Employees = New List(Of Employee)()
            Employees.Add(New Employee() With { _
                .FirstName = "John1", _
                .LastName ="Smith1" _
            })
            Employees.Add(New Employee() With { _
                .FirstName = "John2", _
                .LastName = "Smith2" _
            })
            Employees.Add(New Employee() With { _
                .FirstName = "John3", _
                .LastName = "Smith3" _
            })
            Employees.Add(New Employee() With { _
                .FirstName = "John4", _
                .LastName = "Smith4" _
            })
            Employees.Add(New Employee() With { _
                .FirstName = "John5", _
                .LastName = "Smith5" _
            })
            Employees.Add(New Employee() With { _
                .FirstName = "John6", _
                .LastName = "Smith6" _
            })
            Employees(0).BirthDate = Start.AddDays(4).AddYears(-30)
            Employees(1).BirthDate = Start.AddDays(1).AddYears(-27)
            Employees(2).BirthDate = Start.AddDays(14).AddYears(-32)
            Employees(3).BirthDate = Start.AddDays(-8).AddYears(-41)
            Employees(4).BirthDate = Start.AddDays(-18).AddYears(-41)
            Employees(5).BirthDate = Start.AddDays(48).AddYears(-25)

            Calendars = CreateCalendars().ToList()
            VacationAppointments = CreateVacationsAppts(Start).ToList()
            CompanyBirthdayAppointments = CreateCompanyBirthdayAppts(Start).ToList()
            BirthdayAppointments = CreateBirthdayAppts(Start).ToList()
            ConferenceAppointments = CreateConferenceAppts(Start).ToList()
            MeetingAppointments = CreateMeetingAppts(Start).ToList()
            PhoneCallsAppointments = CreatePhoneCallsAppts(Start).ToList()
            CarWashAppointments = CreateCarWashAppts(Start).ToList()
            TrainingAppointments = CreateTrainingAppts(Start).ToList()
            PayBillsAppointments = CreatePayBillsAppts(Start).ToList()
            DentistAppointments = CreateDentistAppts(Start).ToList()
            RestaurantAppointments = CreateRestaurantAppts(Start).ToList()
            AllAppointments = VacationAppointments.Concat(BirthdayAppointments).Concat(CompanyBirthdayAppointments).Concat(ConferenceAppointments).Concat(MeetingAppointments).Concat(PhoneCallsAppointments).Concat(CarWashAppointments).Concat(TrainingAppointments).Concat(PayBillsAppointments).Concat(DentistAppointments).Concat(RestaurantAppointments).ToList()
            Dim id As Integer = 0
            For Each appt As TeamAppointment In AllAppointments
                appt.Id = id
                id += 1
            Next appt
        End Sub
        Private Shared privateStart As Date
        Public Shared Property Start() As Date
            Get
                Return privateStart
            End Get
            Private Set(ByVal value As Date)
                privateStart = value
            End Set
        End Property
        Private Shared privateCalendars As IEnumerable(Of TeamCalendar)
        Public Shared Property Calendars() As IEnumerable(Of TeamCalendar)
            Get
                Return privateCalendars
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamCalendar))
                privateCalendars = value
            End Set
        End Property
        Public Shared ReadOnly Property MyCalendar() As TeamCalendar
            Get
                Return Calendars.ElementAt(0)
            End Get
        End Property
        Public Shared ReadOnly Property TeamCalendar() As TeamCalendar
            Get
                Return Calendars.ElementAt(1)
            End Get
        End Property
        Private Shared privateAllAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property AllAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateAllAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateAllAppointments = value
            End Set
        End Property
        Private Shared privateVacationAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property VacationAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateVacationAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateVacationAppointments = value
            End Set
        End Property
        Private Shared privateBirthdayAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property BirthdayAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateBirthdayAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateBirthdayAppointments = value
            End Set
        End Property
        Private Shared privateConferenceAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property ConferenceAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateConferenceAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateConferenceAppointments = value
            End Set
        End Property
        Private Shared privateMeetingAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property MeetingAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateMeetingAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateMeetingAppointments = value
            End Set
        End Property
        Private Shared privatePhoneCallsAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property PhoneCallsAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privatePhoneCallsAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privatePhoneCallsAppointments = value
            End Set
        End Property
        Private Shared privateCarWashAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property CarWashAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateCarWashAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateCarWashAppointments = value
            End Set
        End Property
        Private Shared privateCompanyBirthdayAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property CompanyBirthdayAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateCompanyBirthdayAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateCompanyBirthdayAppointments = value
            End Set
        End Property
        Private Shared privateTrainingAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property TrainingAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateTrainingAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateTrainingAppointments = value
            End Set
        End Property
        Private Shared privatePayBillsAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property PayBillsAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privatePayBillsAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privatePayBillsAppointments = value
            End Set
        End Property
        Private Shared privateDentistAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property DentistAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateDentistAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateDentistAppointments = value
            End Set
        End Property
        Private Shared privateRestaurantAppointments As IEnumerable(Of TeamAppointment)
        Public Shared Property RestaurantAppointments() As IEnumerable(Of TeamAppointment)
            Get
                Return privateRestaurantAppointments
            End Get
            Private Set(ByVal value As IEnumerable(Of TeamAppointment))
                privateRestaurantAppointments = value
            End Set
        End Property

        Private Shared ReadOnly Employees As List(Of Employee)
        Private Shared ReadOnly Random As Random

        Private Shared Function GetStart() As Date
            Dim today As Date = Date.Today
            Dim dayOfWeek As DayOfWeek = today.DayOfWeek
            If dayOfWeek = System.DayOfWeek.Monday Then
                Return today
            End If
            If dayOfWeek = System.DayOfWeek.Sunday Then
                Return today.AddDays(1)
            End If
            Return today.AddDays(-(CInt(dayOfWeek) - 1))
        End Function
        Private Shared Function GetRandomEmployee() As Employee
            Return Employees(Random.Next(0, Employees.Count))
        End Function

        Private Shared Function CreateCalendars() As IEnumerable(Of TeamCalendar)
            Return New TeamCalendar() { _
                New TeamCalendar() With { _
                    .Id = 0, _
                    .Name = "My Calendar" _
                }, _
                New TeamCalendar() With { _
                    .Id = 1, _
                    .Name = "Team Calendar" _
                } _
            }
        End Function

        Private Shared Function CreateBirthdayAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Return Employees.Select(AddressOf CreateBirthdayAppt)
        End Function
        Private Shared Function CreateBirthdayAppt(ByVal employee As Employee) As TeamAppointment
            If employee.BirthDate Is Nothing Then
                Return Nothing
            End If
            Dim [date] As Date = employee.BirthDate.Value
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Pattern)), _
                .AllDay = True, _
                .Start = [date], _
                .End = [date].AddDays(1), _
                .Subject = String.Format("{0}'s Birthday", employee.FirstName), _
                .Status = 0, _
                .Label = 8, _
                .CalendarId = 0 _
            }
            appt.RecurrenceInfo = New RecurrenceInfo() With { _
                .AllDay = True, _
                .Start = [date], _
                .Month = [date].Month, _
                .DayNumber = [date].Day, _
                .WeekOfMonth = WeekOfMonth.None, _
                .Type = RecurrenceType.Yearly, _
                .Range = RecurrenceRange.NoEndDate _
            }.ToXml()
            Return appt
        End Function

        Private Shared Function CreateConferenceAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim newStart As Date = start
            Dim thisWeekList() As Tuple(Of String, Date) = { Tuple.Create("DevExpress MVVM Framework", newStart.AddDays(1).AddHours(15)), Tuple.Create("New Theme Designer", newStart.AddDays(2).AddHours(14)), Tuple.Create("GridControl Performance Optimization", newStart.AddDays(3).AddHours(16)), Tuple.Create("WinForms and DirectX", newStart.AddDays(4).AddHours(16))}

            newStart = start.AddDays(-7)
            Dim prevWeekList() As Tuple(Of String, Date) = { Tuple.Create("LOB applications", newStart.AddDays(1).AddHours(13)), Tuple.Create("Module Injection Framework", newStart.AddDays(2).AddHours(16)), Tuple.Create("Git tricks", newStart.AddDays(3).AddHours(10)), Tuple.Create("Machine learning", newStart.AddDays(4).AddHours(11))}

            newStart = start.AddDays(7)
            Dim nextWeekList() As Tuple(Of String, Date) = { Tuple.Create("Azure", newStart.AddDays(1).AddHours(13)), Tuple.Create("WCF Services", newStart.AddDays(2).AddHours(16)), Tuple.Create("Docking Floating Panels", newStart.AddDays(3).AddHours(10)), Tuple.Create("Personal Time Management", newStart.AddDays(4).AddHours(11))}

            newStart = start.AddDays(14)
            Dim nextNextWeekList() As Tuple(Of String, Date) = { Tuple.Create("Entity Framework Core", newStart.AddDays(1).AddHours(10)), Tuple.Create(".Net Core", newStart.AddDays(2).AddHours(16))}

            Dim list As IEnumerable(Of Tuple(Of String, Date)) = thisWeekList.Concat(prevWeekList).Concat(nextWeekList).Concat(nextNextWeekList)

            Dim commonList As New List(Of Tuple(Of String, Date))()
            Dim interval As New DateTimeRange(start.AddDays(-7), start.AddDays(21))
            Dim subjects As IEnumerable(Of String) = list.Select(Function(x) x.Item1)
            For i As Integer = 0 To 99
                newStart = start.AddYears(-1)
                newStart = newStart.AddDays(Random.Next(2 * 365))
                newStart = newStart.AddHours(Random.Next(9, 18))
                If interval.Start <= newStart AndAlso interval.End >= newStart Then
                    Continue For
                End If
                Dim subj As String = subjects.ElementAt(Random.Next(0, subjects.Count()))
                commonList.Add(Tuple.Create(subj, newStart))
            Next i
            Return list.Concat(commonList).Select(Function(x) CreateConferenceAppt(x.Item1, x.Item2))

        End Function
        Private Shared Function CreateConferenceAppt(ByVal subject As String, ByVal start As Date) As TeamAppointment
            Dim emp As Employee = GetRandomEmployee()
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = start, _
                .End = start.AddHours(1.5), _
                .Subject = String.Format("Conference: {0}", subject), _
                .Description = String.Format("{0} {1} tells us about {2}.", emp.FirstName, emp.LastName, subject), _
                .Status = 2, _
                .Label = 2, _
                .Location = "Conference Room", _
                .CalendarId = 1 _
            }
            Return appt
        End Function

        Private Shared Function CreateMeetingAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim res As New List(Of TeamAppointment)() From {CreateMeetingRecurrenceAppt("Weekly meeting", start.AddMonths(-6).Add(New TimeSpan(5, 14, 00, 0))), CreateLunchAppt(Employees(0), start.AddDays(1).AddHours(13)), CreateLunchAppt(Employees(1), start.AddDays(3).AddHours(13)), CreateLunchAppt(Employees(2), start.AddDays(-4).AddHours(13)), CreateLunchAppt(Employees(3), start.AddDays(9).AddHours(13)), CreateLunchAppt(Employees(4), start.AddDays(12).AddHours(13))}
            Dim interval As New DateTimeRange(start.AddDays(-7), start.AddDays(21))
            Dim days As New List(Of Integer)()
            For i As Integer = 0 To 49
                Dim emp As Employee = Employees(Random.Next(0, Employees.Count))
                Dim newStart As Date = start.AddYears(-1)
                newStart = newStart.AddDays(Random.Next(365))
                If interval.Start <= newStart AndAlso interval.End >= newStart Then
                    Continue For
                End If
                If days.Contains(newStart.DayOfYear) Then
                    Continue For
                End If
                If VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.End >= newStart) Then
                    Continue For
                End If
                days.Add(newStart.DayOfYear)
                res.Add(CreateLunchAppt(emp, newStart.AddHours(13)))
            Next i
            Return res
        End Function
        Private Shared Function CreateMeetingRecurrenceAppt(ByVal subject As String, ByVal start As Date) As TeamAppointment
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Pattern)), _
                .AllDay = False, _
                .Start = start, _
                .End = start.AddHours(1), _
                .Subject = subject, _
                .Status = 2, _
                .Label = 2, _
                .CalendarId = 1 _
            }
            appt.RecurrenceInfo = New RecurrenceInfo() With { _
                .Start = start, _
                .Type = RecurrenceType.Weekly, _
                .WeekDays = WeekDays.Friday, _
                .Month = 12, _
                .Range = RecurrenceRange.NoEndDate _
            }.ToXml()
            Return appt
        End Function
        Private Shared Function CreateLunchAppt(ByVal emp As Employee, ByVal start As Date) As TeamAppointment
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = start, _
                .End = start.AddHours(1), _
                .Subject = String.Format("Lunch with {0}", emp.FirstName), _
                .Status = 3, _
                .Label = 3, _
                .CalendarId = 0 _
            }
            Return appt
        End Function

        Private Shared Function CreatePhoneCallsAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim res As New List(Of TeamAppointment)() From {CreatePhoneCallAppt(Employees(0), start.AddDays(0).AddHours(10)), CreatePhoneCallAppt(Employees(1), start.AddDays(3).AddHours(11)), CreatePhoneCallAppt(Employees(2), start.AddDays(3).AddHours(12).AddMinutes(40), TimeSpan.FromMinutes(15)), CreatePhoneCallAppt(Employees(3), start.AddDays(-4).AddHours(14)), CreatePhoneCallAppt(Employees(4), start.AddDays(9).AddHours(15)), CreatePhoneCallAppt(Employees(5), start.AddDays(12).AddHours(15)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(0).AddHours(16)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(2).AddHours(15.6)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(4).AddHours(15)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(5).AddHours(10.5)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(5).AddHours(16)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(6).AddHours(9.7)), CreatePhoneCallAppt(GetRandomEmployee(), start.AddDays(6).AddHours(16.8))}
            Dim interval As New DateTimeRange(start.AddDays(-7), start.AddDays(21))
            For i As Integer = 0 To 49
                Dim emp As Employee = Employees(Random.Next(0, Employees.Count))
                Dim newStart As Date = start.AddYears(-1)
                newStart = newStart.AddDays(Random.Next(365))
                If interval.Start <= newStart AndAlso interval.End >= newStart Then
                    Continue For
                End If
                If VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.End >= newStart) Then
                    Continue For
                End If
                res.Add(CreatePhoneCallAppt(emp, newStart.AddHours(Random.Next(9, 18))))
            Next i
            Return res
        End Function
        Private Shared Function CreatePhoneCallAppt(ByVal emp As Employee, ByVal start As Date, Optional ByVal duration? As TimeSpan = Nothing) As TeamAppointment
            Dim newStart As Date = start.AddMinutes(Random.Next(0, 4) * 15)
            Dim newEnd As Date = If(duration IsNot Nothing, newStart.Add(duration.Value), newStart.AddMinutes(Random.Next(1, 6) * 5))
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = newStart, _
                .End = newEnd, _
                .Subject = String.Format("Phone Call with {0}", emp.FirstName), _
                .Status = 2, _
                .Label = 10, _
                .CalendarId = 0 _
            }
            Return appt
        End Function

        Private Shared Function CreateVacationsAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Return { _
                New TeamAppointment() With { _
                    .AppointmentType = CInt((AppointmentType.Normal)), _
                    .AllDay = True, _
                    .Start = start.AddMonths(-6), _
                    .End = start.AddMonths(-6).AddDays(14), _
                    .Subject = String.Format("Vacation"), _
                    .Status = 0, _
                    .Label = 4, _
                    .CalendarId = 0 _
                }, _
                New TeamAppointment() With { _
                    .AppointmentType = CInt((AppointmentType.Normal)), _
                    .AllDay = True, _
                    .Start = start.AddMonths(6), _
                    .End = start.AddMonths(6).AddDays(14), _
                    .Subject = String.Format("Vacation"), _
                    .Status = 0, _
                    .Label = 4, _
                    .CalendarId = 0 _
                }, _
                New TeamAppointment() With { _
                    .AppointmentType = CInt((AppointmentType.Normal)), _
                    .AllDay = True, _
                    .Start = start.AddDays(4), _
                    .End = start.AddDays(8), _
                    .Subject = String.Format("Vacation"), _
                    .Status = 0, _
                    .Label = 4, _
                    .CalendarId = 0 _
                } _
            }
        End Function

        Private Shared Function CreateCarWashAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim res As New List(Of TeamAppointment)() From {CreateCarWashAppt(start.AddDays(1).AddHours(17))}
            Dim newStart As Date = start.AddYears(-1)
            Do While newStart < start.AddMonths(1)
                newStart = newStart.AddDays(Random.Next(18, 35))
                If VacationAppointments.Any(Function(x) x.Start <= newStart AndAlso x.End >= newStart) Then
                    Continue Do
                End If
                If newStart >= start AndAlso newStart <= start.AddDays(7) Then
                    Continue Do
                End If
                CreateCarWashAppt(newStart)
            Loop
            Return res
        End Function
        Private Shared Function CreateCarWashAppt(ByVal start As Date) As TeamAppointment
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = start, _
                .End = start.AddHours(1), _
                .Subject = String.Format("Car Wash"), _
                .Status = 3, _
                .Label = 3, _
                .CalendarId = 0 _
            }
            Return appt
        End Function

        Private Shared Function CreateCompanyBirthdayAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim newStart As New Date(start.Year - 1, start.Month, start.Day)
            newStart = newStart.AddDays(5)
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Pattern)), _
                .AllDay = True, _
                .Start = newStart, _
                .End = newStart.AddDays(1), _
                .Subject = "Company Birthday Party", _
                .Status = 0, _
                .Label = 8, _
                .CalendarId = 1 _
            }
            appt.RecurrenceInfo = New RecurrenceInfo() With { _
                .AllDay = True, _
                .Start = newStart, _
                .Type = RecurrenceType.Yearly, _
                .Month = newStart.Month, _
                .DayNumber = newStart.Day, _
                .WeekOfMonth = WeekOfMonth.None, _
                .Range = RecurrenceRange.NoEndDate _
            }.ToXml()

            Return { appt }
        End Function

        Private Shared Function CreateTrainingAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim newStart As Date = start.AddYears(-1).AddHours(8.5)
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Pattern)), _
                .AllDay = False, _
                .Start = newStart, _
                .End = newStart.AddHours(1.5), _
                .Subject = "Sport Training", _
                .Status = 1, _
                .Label = 3, _
                .CalendarId = 0 _
            }
            appt.RecurrenceInfo = New RecurrenceInfo() With { _
                .AllDay = False, _
                .Start = newStart, _
                .Type = RecurrenceType.Weekly, _
                .WeekDays = WeekDays.Monday Or WeekDays.Wednesday Or WeekDays.Friday, _
                .Range = RecurrenceRange.NoEndDate _
            }.ToXml()
            Return { appt }
        End Function

        Private Shared Function CreatePayBillsAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim newStart As Date = start.AddDays(2).AddYears(-1)
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Pattern)), _
                .AllDay = True, _
                .Start = newStart, _
                .End = newStart.AddDays(1), _
                .Subject = "Pay Bills", _
                .Status = 0, _
                .Label = 3, _
                .CalendarId = 0 _
            }
            appt.RecurrenceInfo = New RecurrenceInfo() With { _
                .AllDay = True, _
                .Start = newStart, _
                .Type = RecurrenceType.Monthly, _
                .DayNumber = newStart.Day, _
                .WeekOfMonth = WeekOfMonth.None, _
                .Range = RecurrenceRange.NoEndDate _
            }.ToXml()
            Return { appt }
        End Function

        Private Shared Function CreateDentistAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim res As New List(Of TeamAppointment)() From {CreateDentistAppt(start.AddDays(4).AddHours(17.5))}
            Dim newStart As Date = start.AddYears(-2)
            Do While newStart < start
                newStart = newStart.AddDays(Random.Next(365\3, 365\2))
                CreateDentistAppt(newStart)
            Loop
            Return res
        End Function
        Private Shared Function CreateDentistAppt(ByVal start As Date) As TeamAppointment
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = start, _
                .End = start.AddHours(2), _
                .Subject = String.Format("Dentist"), _
                .Status = 3, _
                .Label = 3, _
                .CalendarId = 0 _
            }
            Return appt
        End Function

        Private Shared Function CreateRestaurantAppts(ByVal start As Date) As IEnumerable(Of TeamAppointment)
            Dim res As New List(Of TeamAppointment)() From {CreateDinnerAppt(start.AddDays(2).AddHours(19)), CreateDinnerAppt(start.AddDays(14).AddHours(19)), CreateDinnerAppt(start.AddDays(18).AddHours(21))}
            Dim newStart As Date = start.AddYears(-2)
            Do While newStart < start
                newStart = newStart.AddDays(Random.Next(14, 42))
                res.Add(CreateDinnerAppt(newStart.AddHours(Random.Next(18, 22))))
            Loop
            Return res
        End Function
        Private Shared Function CreateDinnerAppt(ByVal start As Date, Optional ByVal duration? As TimeSpan = Nothing) As TeamAppointment
            Dim newStart As Date = start.AddMinutes(Random.Next(0, 4) * 15)
            Dim newEnd As Date = If(duration IsNot Nothing, newStart.Add(duration.Value), newStart.AddMinutes(Random.Next(4, 8) * 20))
            Dim appt = New TeamAppointment() With { _
                .AppointmentType = CInt((AppointmentType.Normal)), _
                .AllDay = False, _
                .Start = newStart, _
                .End = newEnd, _
                .Subject = String.Format("Dinner"), _
                .Status = 0, _
                .Label = 5, _
                .CalendarId = 0 _
            }
            Return appt
        End Function
    End Class
End Namespace
