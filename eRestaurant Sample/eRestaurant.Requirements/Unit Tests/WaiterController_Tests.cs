using eRestaurant.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace eRestaurant.Requirements.Unit_Tests
{
    public class WaiterController_Tests
    {
        [Fact]
        public void Should_Have_Active_Bills_For_Testing()
        {
            var actives = GetActiveBills();
            Assert.True(actives.Count > 0);
        }

        private static List<Entities.DTOs.ListDataItem> GetActiveBills()
        {
            WaiterController sut = new WaiterController();
            var actives = sut.ListActiveBills();
            return actives;
        }
        [Fact]
        [AutoRollback]
        public void Should_Split_Bill()
        {
            // Arrange
            WaiterController sut = new WaiterController();
            var aBill = GetActiveBills().First();
            var actualBill = sut.GetBill(aBill.KeyValue);
            int midPoint = actualBill.Items.Count / 2;
            //List<

            // Act
            //sut.SplitBill(aBill.KeyValue, originals, newItems);

            // Assert
        }
    }
}
