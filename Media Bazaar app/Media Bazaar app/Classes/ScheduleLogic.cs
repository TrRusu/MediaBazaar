using Media_Bazaar_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app.Classes
{
    class ScheduleLogic
    {
        private User userControl;
        private Department departmentControl = new Department();
        private Shift shiftControl;
        private Vacation vacationControl;
        private Availability availabilityControl;
        private List<Availability> localAvailabilities;

        public ScheduleLogic()
        {
        
        }

        public ScheduleLogic(string type)
        {
            if(type == "Administration")
            {
                userControl = new User();
                vacationControl = new Vacation();
                shiftControl = new Shift();
                userControl.GetAllUsersFromDatabase();
                departmentControl.GetDeparmentsFromDatabase();
                vacationControl.GetApprovedVacationsFromDatabase();
            }
            else
            {
                shiftControl = new Shift();
                shiftControl.GetAllShiftsFromDatabase();
                departmentControl.GetDeparmentsFromDatabase();
            }
        }

        public ScheduleLogic(string department, int week)
        {       
            vacationControl = new Vacation();
            availabilityControl = new Availability();
            shiftControl = new Shift();
            userControl = new User();
            vacationControl.GetApprovedVacationsForAutomatedSchedule(week);
            shiftControl.GetShiftsForAutomatedSchedule(department);
            userControl.GetUsersForAutomatedSchedule(department);
            availabilityControl.GetAvailabilitesFromDatabaseByWeek(week);
        }

        public bool DidNotHaveEveningShiftYesterday(string selected, int week, int day)
        {
            foreach (Shift entry in shiftControl.ReturnAllShiftsLocalList())
            {
                if (day == 1)
                {
                    int lastDay = 7;
                    int lastWeek = week - 1;

                    if (selected == entry.Name)
                    {
                        if (entry.Week == lastWeek)
                        {
                            if (entry.Day == lastDay)
                            {
                                if (entry.ShiftType == "Evening")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selected == entry.Name)
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == day - 1)
                            {
                                if (entry.ShiftType == "Evening")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool IsEmployeeInOvertime(string selected, int week)
        {
            foreach (Shift shift in shiftControl.ReturnAllShiftsLocalList())
            {
                if (shift.Week == week)
                {
                    if (shift.Name == selected)
                    {
                        if (shift.ContractType == "Full-Time 1.0 fte (40h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 36)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Full-Time 0.9 fte (36h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 32)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.8 fte (32h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 28)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.7 fte (28h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 24)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.6 fte (24h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 20)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.5 fte (20h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 16)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.4 fte (16h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 12)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.3 fte (12h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 8)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.2 fte (8h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 4)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.1 fte (4h)")
                        {
                            if (CalculateTotalHoursWorkedThisWeek(selected, week) > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool DoesNotHaveMorningShiftTomorrow(string selected, int week, int day)
        {
            foreach (Shift entry in shiftControl.ReturnAllShiftsLocalList())
            {
                if (day == 1)
                {
                    int newDay = 2;
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == newDay)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if (day == 7)
                {
                    int nextDay = 1;
                    int nextWeek = week + 1;
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == nextWeek)
                        {
                            if (entry.Day == nextDay)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == day + 1)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool DoesNotHaveVacation(string selected, int week, int day)
        {
            foreach(Vacation vacation in vacationControl.GetVacationLocalListByWeek(week))
            {
                if(vacation.Name == selected && vacation.Day == day)
                {
                    return false;
                }          
            }

            return true;
        }

        public int CalculateTotalHoursWorkedThisWeek(string name, int week)
        {
            int day = 0;
            int totalHours;

            foreach (Shift shift in shiftControl.ReturnAllShiftsLocalList())
            {
                if (shift.Name == name && shift.Week == week)
                {
                    day++;
                }
            }

            totalHours = day * 4;
            return totalHours;
        }

        public bool DoesNotHaveCurrentShift(int week, int day, string name, string shift)
        {
            foreach (Shift s in shiftControl.ReturnAllShiftsLocalList())
            {
                if(s.Week == week)
                {
                    if(s.Day == day)
                    {
                        if(s.Name == name)
                        {
                            if(s.ShiftType == shift)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void RemoveShift(int week, string name, string department, string shift, int day)
        {
            shiftControl.RemoveShiftFromDatabase(week, name, department, shift, day);
        }

        public List<Shift> ReturnLocalShiftListByDepartment(string department)
        {
            return shiftControl.FilterShiftLocalListByDepartment(department);
        }

        public List<Shift> ReturnShiftsByType(int weekNumber, int weekDay, string department, string shiftType)
        {
            List<Shift> shiftsByType = new List<Shift>();

            foreach (Shift shift in ReturnLocalShiftListByDepartment(department))
            {
                if (shift.Week == weekNumber && shift.Day == weekDay && shift.ShiftType == shiftType)
                {
                    shiftsByType.Add(shift);
                }
            }
            return shiftsByType;
        }

        public List<User> ReturnLocalUserList()
        {
            return userControl.ReturnUsersLocalList();
        }

        public List<User> ReturnLocalUserListByDepartment(string department)
        {
            return userControl.FilterLocalUsersListByDepartment(department);
        }

        public List<Department> ReturnLocalDepartmentList()
        {
            return departmentControl.ReturnDepartmentLocalList();
        }

        public List<string> FetchEmployeeOverview(string name, int weekNumber, int day)
        {
            List<string> userOverview = new List<string>();

            foreach (User user in userControl.ReturnUsersLocalList())
            {
                string fullName = user.FirstName + " " + user.LastName;
                if (name == fullName)
                {
                    userOverview.Add("Contract: " + user.ContractType);
                    userOverview.Add("Position: " + user.Position);
                }
            }
            userOverview.Add("Hours worked this week: " + CalculateTotalHoursWorkedThisWeek(name, weekNumber));
            if (DoesNotHaveVacation(name, weekNumber, day) == true)
            {
                userOverview.Add("Has vacation today: No");
            }
            else
            {
                userOverview.Add("Has vacation today: Yes");
            }

            return userOverview;
        }

        public bool ManualScheduleMorningShiftAssignment(int weekNumber, string name, string department, string shift, int weekDay)
        {
            if(DoesNotHaveVacation(name,weekNumber, weekDay) == false)
            {
                MessageBox.Show("Employee has vacation today");
                return false;
            }
            else if (DidNotHaveEveningShiftYesterday(name, weekNumber, weekDay) == false)
            {
                MessageBox.Show("Employee had evening shift yesterday");
                return false;
            }
            else
            {
                if (IsEmployeeInOvertime(name, weekNumber))
                {
                    DialogResult dialogResult = MessageBox.Show("Employee will be working overtime. Continue?", "WARNING", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                }
            }
            return true;
        }

        public bool ManualScheduleAfternoonShiftAssignment(int weekNumber, string name, string department, string shift, int weekDay)
        {
            if (DoesNotHaveVacation(name, weekNumber, weekDay) == false)
            {
                MessageBox.Show("Employee has vacation today");
                return false;
            }
            else
            {
                if (IsEmployeeInOvertime(name, weekNumber))
                {
                    DialogResult dialogResult = MessageBox.Show("Employee will be working overtime. Continue?", "WARNING", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                }
            }
            return true;
        }

        public bool ManualScheduleEveningShiftAssignment(int weekNumber, string name, string department, string shift, int weekDay)
        {
            if (DoesNotHaveVacation(name, weekNumber, weekDay) == false)
            {
                MessageBox.Show("Employee has vacation today");
                return false;
            }
            else if (DoesNotHaveMorningShiftTomorrow(name, weekNumber, weekDay) == false)
            {
                MessageBox.Show("Employee has morning shift tomorrow");
                return false;
            }
            else
            {
                if (IsEmployeeInOvertime(name, weekNumber))
                {
                    DialogResult dialogResult = MessageBox.Show("Employee will be working overtime. Continue?", "WARNING", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    shiftControl.RegisterShiftInDatabase(weekNumber, name, department, shift, weekDay, userControl.GetUserPosition(name), userControl.GetUserContract(name));
                }
            }
            return true;
        }

        public void CreateInitialListOfAvailabilitiesForDay(int day)
        {
            localAvailabilities = availabilityControl.FilterAvailabilitesByDay(day);
        }

        public void RemoveEmployeesWhoHaveVacation()
        {
            for (int i = 0; i < localAvailabilities.Count; i++)
            {
                if (DoesNotHaveVacation(localAvailabilities[i].Name, localAvailabilities[i].Week, localAvailabilities[i].Day) == false)
                {
                    localAvailabilities.Remove(localAvailabilities[i]);
                }
            }
        }

        public void RemoveEmployeesWhoHaveReachedLimit()
        {
            for (int i = 0; i < localAvailabilities.Count; i++)
            {
                if (IsEmployeeInOvertime(localAvailabilities[i].Name, localAvailabilities[i].Week) == true)
                {
                    localAvailabilities.Remove(localAvailabilities[i]);
                }
            }
        }

        public void RemoveEmployeesWhoHaveMorningShiftTomorrow()
        {
            for (int i = 0; i < localAvailabilities.Count; i++)
            {
                if (localAvailabilities[i].Shift == "Evening")
                {
                    if (DoesNotHaveMorningShiftTomorrow(localAvailabilities[i].Name, localAvailabilities[i].Week, localAvailabilities[i].Day) == false)
                    {
                        localAvailabilities.Remove(localAvailabilities[i]);
                    }
                }
            }
        }

        public void RemoveEmployeesWhoHadEveningShiftYesterday()
        {
            for (int i = 0; i < localAvailabilities.Count; i++)
            {
                if (localAvailabilities[i].Shift == "Morning")
                {
                    if (DidNotHaveEveningShiftYesterday(localAvailabilities[i].Name, localAvailabilities[i].Week, localAvailabilities[i].Day) == false)
                    {
                        localAvailabilities.Remove(localAvailabilities[i]);
                    }
                }
            }
        }

        public void AutomatedScheduleMorningShiftAssignment(int cashiers, int salesAgents, int depotworkers, int securityGuards)
        {
            foreach (Availability availability in localAvailabilities)
            {
                if (availability.Shift == "Morning")
                {
                    if (userControl.GetUserPosition(availability.Name) == "Cashier")
                    {
                        for (int i = 0; i < cashiers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift) == true)
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    if (DidNotHaveEveningShiftYesterday(name, week, day) == true)
                                    {
                                        if (DoesNotHaveMorningShiftTomorrow(name, week, day) == true)
                                        {
                                            string department = userControl.GetUserDepartment(availability.Name);
                                            string position = userControl.GetUserPosition(availability.Name);
                                            string contract = userControl.GetUserContract(availability.Name);

                                            shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                            availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Sales Agent")
                    {
                        for (int i = 0; i < salesAgents; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    if (DidNotHaveEveningShiftYesterday(name, week, day) == true)
                                    {

                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }


                    if (userControl.GetUserPosition(availability.Name) == "Depot Worker")
                    {
                        for (int i = 0; i < depotworkers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    if (DidNotHaveEveningShiftYesterday(name, week, day) == true)
                                    {

                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }


                    if (userControl.GetUserPosition(availability.Name) == "Security Guard")
                    {
                        for (int i = 0; i < securityGuards; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    if (DidNotHaveEveningShiftYesterday(name, week, day) == true)
                                    {
                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AutomatedScheduleAfternoonShiftAssignment(int cashiers, int salesAgents, int depotworkers, int securityGuards)
        {
            foreach (Availability availability in localAvailabilities)
            {
                if (availability.Shift == "Afternoon")
                {
                    if (userControl.GetUserPosition(availability.Name) == "Cashier")
                    {
                        for (int i = 0; i < cashiers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    string department = userControl.GetUserDepartment(availability.Name);
                                    string position = userControl.GetUserPosition(availability.Name);
                                    string contract = userControl.GetUserContract(availability.Name);

                                    shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                  day, position, contract);
                                    availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Sales Agent")
                    {
                        for (int i = 0; i < salesAgents; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    string department = userControl.GetUserDepartment(availability.Name);
                                    string position = userControl.GetUserPosition(availability.Name);
                                    string contract = userControl.GetUserContract(availability.Name);

                                    shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                  day, position, contract);
                                    availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Depot Worker")
                    {
                        for (int i = 0; i < depotworkers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    string department = userControl.GetUserDepartment(availability.Name);
                                    string position = userControl.GetUserPosition(availability.Name);
                                    string contract = userControl.GetUserContract(availability.Name);

                                    shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                    availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Security Guard")
                    {
                        for (int i = 0; i < securityGuards; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    string department = userControl.GetUserDepartment(availability.Name);
                                    string position = userControl.GetUserPosition(availability.Name);
                                    string contract = userControl.GetUserContract(availability.Name);

                                    shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                    availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AutomatedScheduleEveningShiftAssignment(int cashiers, int salesAgents, int depotworkers, int securityGuards)
        {
            foreach (Availability availability in localAvailabilities)
            {
                if (availability.Shift == "Evening")
                {
                    if (userControl.GetUserPosition(availability.Name) == "Cashier")
                    {
                        for (int i = 0; i < cashiers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {

                                    if (DoesNotHaveMorningShiftTomorrow(name, week, day) == true)
                                    {
                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(availability.Week, availability.Name, department, availability.Shift,
                                                                             availability.Day, position, contract);
                                    }
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Sales Agent")
                    {
                        for (int i = 0; i < salesAgents; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {

                                    if (DoesNotHaveMorningShiftTomorrow(name, week, day) == true)
                                    {
                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Depot Worker")
                    {
                        for (int i = 0; i < depotworkers; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {

                                    if (DoesNotHaveMorningShiftTomorrow(name, week, day) == true)
                                    {
                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                 day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }

                    if (userControl.GetUserPosition(availability.Name) == "Security Guard")
                    {
                        for (int i = 0; i < securityGuards; i++)
                        {
                            int week = availability.Week;
                            int day = availability.Day;
                            string name = availability.Name;
                            string shift = availability.Shift;

                            if (DoesNotHaveCurrentShift(week, day, name, shift))
                            {
                                if (IsEmployeeInOvertime(name, week) == false)
                                {
                                    if (DoesNotHaveMorningShiftTomorrow(name, week, day) == true)
                                    {
                                        string department = userControl.GetUserDepartment(availability.Name);
                                        string position = userControl.GetUserPosition(availability.Name);
                                        string contract = userControl.GetUserContract(availability.Name);

                                        shiftControl.RegisterShiftInDatabase(week, name, department, shift,
                                                                                  day, position, contract);
                                        availabilityControl.RemoveAvailabilityFromDatabase(name, shift, week, day);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}

