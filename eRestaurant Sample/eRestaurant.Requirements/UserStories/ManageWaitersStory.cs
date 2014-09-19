using eRestaurant.BLL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace eRestaurant.Requirements.UserStories
{
    [Story(AsA="Restaurant Manager",
           IWant="To manage my waiters",
           SoThat="I have enough staff to wait on tables")]
    public class ManageWaitersStory
    {
        [Fact]
        [AutoRollback]
        public void AddWaiterScenario()
        {
            Waiter newGuy = new Waiter() 
            {
                FirstName = "Fred",
                LastName = "Flintstone",
                Address = "123 Bedrock",
                Phone = "780.555.1212",
                HireDate = DateTime.Today.AddDays(-3)
            };
            int waiterId = -1;
            this.Given(_ => GivenWaiterInformation(newGuy))
                .When(_ => WhenIAddTheWaiter(newGuy, out waiterId))
                .Then(_ => ThenTheWaiterExists(waiterId))
                .And(_ => TheWaiterDetailsMatch(waiterId, newGuy))
                .BDDfy();
        }

        private void TheWaiterDetailsMatch(int waiterId, Waiter newGuy)
        {
            var sut = new RestaurantAdminController();
            // TODO: Compare the actual waiter info with the expected
        }

        private void ThenTheWaiterExists(int waiterId)
        {
            var sut = new RestaurantAdminController();
            var actual = sut.GetWaiter(waiterId);
            Assert.NotNull(actual);
        }

        private void WhenIAddTheWaiter(Waiter newGuy, out int waiterId)
        {
            // sut ==> "system under test"
            var sut = new RestaurantAdminController();
            waiterId = sut.AddWaiter(newGuy);
        }

        private void GivenWaiterInformation(Waiter newGuy)
        {
            Assert.False(string.IsNullOrEmpty(newGuy.FirstName));
            Assert.False(string.IsNullOrEmpty(newGuy.LastName));
            Assert.False(string.IsNullOrEmpty(newGuy.Address));
            Assert.False(string.IsNullOrEmpty(newGuy.Phone));
        }
    }
}
