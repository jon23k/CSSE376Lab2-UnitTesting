using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        private readonly DateTime testStartDate = DateTime.Now;
        private readonly DateTime testEndDate = new DateTime(2015, 5, 1, 8, 30, 52);
        private readonly int testMiles = 300;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(testStartDate, testEndDate, testMiles);
            Assert.IsNotNull(target);
        }
        
        [Test()]
        public void TestThatFlightDatesAreDifferent()
        {
            Assert.AreNotEqual(testStartDate, testEndDate);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForAOneDayTravelTime()
        {
            DateTime startDate = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime endDate = new DateTime(2008, 5, 2, 8, 30, 52);
            var target = new Flight(startDate, endDate, 200);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForForATwoDayTravelTime()
        {
            DateTime startDate = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime endDate = new DateTime(2008, 5, 3, 8, 30, 52);
            var target = new Flight(startDate, endDate, 200);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForAOneWeekTravelTime()
        {
            DateTime startDate = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime endDate = new DateTime(2008, 5, 8, 8, 30, 52);
            var target = new Flight(startDate, endDate, 200);
            Assert.AreEqual(340, target.getBasePrice());
        }        [Test()]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = new DateTime(2008, 5, 1, 8, 30, 52);
            new Flight(startDate, endDate, 200);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatMilesThrowsOnBadLength()
        {
            new Flight(testStartDate, testEndDate, -5);
        } 
	}
}
