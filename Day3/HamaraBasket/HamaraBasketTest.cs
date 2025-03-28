namespace hamaraBasket.Tests
{
    [TestFixture]
    public class HamaraBasketTest
    {
        private DomainFactory domain = new DomainFactory();

        [Test]
        public void RegularItem_QualityDecreasesByOne()
        {
            var item = domain.PrepareOneListItem("Regular Item", 10, 10);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(9, item[0].Quality);
        }

        [Test]
        public void RegularItem_Expired_QualityDecreasesByTwo()
        {
            var item = domain.PrepareOneListItem("Regular Item", 10, 0);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(8, item[0].Quality);
        }

        [Test]
        public void RegularItem_QualityIsNeverNegative()
        {
            var item = domain.PrepareOneListItem("Regular Item", 0, 1);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(0, item[0].Quality);
        }

        [Test]
        public void RegularItem_Expired_QualityIsNeverNegative()
        {
            var item = domain.PrepareOneListItem("Regular Item", 2, 0);
            domain.UpdateQualityRule(item);
            Assert.AreEqual(0, item[0].Quality);
        }

        [Test]
        public void RegularItem_QualityDoesNotExceedFifty()
        {
            var item = domain.PrepareOneListItem("Regular Item", 54, 8);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(50, item[0].Quality);
        }

        [Test]
        public void IndianWine_QualityIncreasesByOne()
        {
            var item = domain.PrepareOneListItem("Indian Wine", 10, 10);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(11, item[0].Quality);
        }

        [Test]
        public void IndianWine_Expired_QualityNeverExceedsFifty()
        {
            var item = domain.PrepareOneListItem("Indian Wine", 50, 0);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(50, item[0].Quality);
        }

        [Test]
        public void IndianWine_Expired_QualityIncreasesByOne()
        {
            var item = domain.PrepareOneListItem("Indian Wine", 10, 0);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(11, item[0].Quality);
        }

        [Test]
        public void ForestHoney_QualityRemainsSame()
        {
            var item = domain.PrepareOneListItem("Forest Honey", 10, 10);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(10, item[0].Quality);
        }

        [Test]
        public void ForestHoney_QualityRemainsSame_AfterExpiration()
        {
            var item = domain.PrepareOneListItem("Forest Honey", 10, 0);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(10, item[0].Quality);
        }

        [Test]
        public void MovieTickets_WhenSellInIsAboveTenDays_QualityIncreasesByOne()
        {
            var item = domain.PrepareOneListItem("Movie Tickets", 10, 11);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(11, item[0].Quality);
        }

        [Test]
        public void MovieTickets_WhenSellInIsTenOrLess_QualityIncreasesByTwo()
        {
            var item = domain.PrepareOneListItem("Movie Tickets", 10, 10);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(12, item[0].Quality);
        }

        [Test]
        public void MovieTickets_WhenSellInIsFiveOrLess_QualityIncreasesByThree()
        {
            var item = domain.PrepareOneListItem("Movie Tickets", 10, 5);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(13, item[0].Quality);
        }

        [Test]
        public void MovieTickets_QualityNeverExceedsFifty()
        {
            var item = domain.PrepareOneListItem("Movie Tickets", 50, 10);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(50, item[0].Quality);
        }

        [Test]
        public void MovieTickets_Expired_QualityIsZero()
        {
            var item = domain.PrepareOneListItem("Movie Tickets", 10, 0);
            domain.UpdateQualityRule(item);

            Assert.AreEqual(0, item[0].Quality);
        }
    }
}
