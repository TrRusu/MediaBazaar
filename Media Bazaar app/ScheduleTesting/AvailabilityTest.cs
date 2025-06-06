using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Media_Bazaar_app.Classes;
using System.Collections.Generic;

namespace ScheduleTesting
{
    [TestClass]
    public class AvailabilityTest
    {
        [TestMethod]
        public void NewAvailabilityTest1()
        {
            Availability a = new Availability("John Doe", "Morning", 1, 1);

            Assert.AreEqual("John Doe", a.Name);
            Assert.AreEqual("Morning", a.Shift);
            Assert.AreEqual(1, a.Week);
            Assert.AreEqual(1, a.Day);
        }
        [TestMethod]
        public void CreateInitialListOfAvailabilitiesForDayTest()
        {
            List<Availability> a = new List<Availability>();
            Availability test = new Availability("John Doe", "Morning", 1, 1);
            a.Add(test);

            CollectionAssert.AreEquivalent(new List<Availability> {test}, a);
        }
        [TestMethod]
        public void RemoveEmployeesWhoHaveVacationTest()
        {
            List<Availability> test = new List<Availability>();
            Vacation v = new Vacation(1, "John Doe", 1, 1);
            Availability a = new Availability("John Doe", "Morning", 1, 1);
            test.Add(a);           
            Assert.AreEqual(v.Name, a.Name);
            Assert.AreEqual(v.Day, a.Day);
            test.Remove(a);
        }
        [TestMethod]
        public void RemoveEmployeesWhoHadEveningShiftYesterdayTest()
        {
            List<Availability> test = new List<Availability>();
            Shift s = new Shift(1, "John Doe", 1, 1, "Evening", "Entertainment", "Sales Agent", "Part-Time 0.1 fte (4h)");
            Availability a = new Availability("John Doe", "Morning", 1, 2);
            test.Add(a);
            Assert.AreEqual(s.Name, a.Name);
            Assert.AreEqual(s.Week, a.Week);
            Assert.AreEqual(s.ShiftType, "Evening");
            Assert.AreEqual(s.Day, 1);
            test.Remove(a);
        }
        [TestMethod]
        public void RemoveEmployeesWhoHasMorningShiftTomorrowTest()
        {
            List<Availability> test = new List<Availability>();
            Shift s = new Shift(1, "John Doe", 2, 1, "Morning", "Entertainment", "Sales Agent", "Part-Time 0.1 fte (4h)");
            Availability a = new Availability("John Doe", "Evening", 1, 1);
            test.Add(a);
            Assert.AreEqual(s.Name, a.Name);
            Assert.AreEqual(s.Week, a.Week);
            Assert.AreEqual(s.ShiftType, "Morning");
            Assert.AreEqual(s.Day, 2);
            test.Remove(a);
        }
        [TestMethod]
        public void RemoveEmployeesWhoHaveReachedLimitTest()
        {
            List<Availability> test = new List<Availability>();
            Shift s1 = new Shift(1, "John Doe", 2, 1, "Morning", "Entertainment", "Sales Agent", "Part-Time 0.1 fte (4h)");
            Shift s2 = new Shift(1, "John Doe", 3, 1, "Morning", "Entertainment", "Sales Agent", "Part-Time 0.1 fte (4h)");
            Availability a = new Availability("John Doe", "Evening", 1, 1);
            test.Add(a);
            Assert.AreEqual(s1.Name, a.Name);
            Assert.AreEqual(s2.Name, a.Name);
            Assert.AreEqual(s1.Week, a.Week);
            Assert.AreEqual(s2.Week, a.Week);
            Assert.AreEqual(s1.ContractType, "Part-Time 0.1 fte (4h)");
            Assert.AreEqual(s2.ContractType, "Part-Time 0.1 fte (4h)");
            test.Remove(a);
        }
    }
}
