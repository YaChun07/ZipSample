using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZipSample.test
{
    [TestClass]
    public class TitanTests
    {
        [TestMethod]
        public void order_to_dto()
        {
            var order = new Order()
            {
                OrderId = 1,
                Amount = 100,
                CreateDate = new DateTime(2018, 11, 17)
            };
            var actual = order.Project(order1 => new OrderDto()
            {
                Id = order1.OrderId,
                TotalAmount = order1.Amount,
                Date = order1.CreateDate.ToString("yyyyMMdd")
            });

            var expected = new OrderDto()
            {
                Id = 1,
                TotalAmount = 100,
                Date = "20181117"
            };
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.TotalAmount, actual.TotalAmount);
            Assert.AreEqual(expected.Date, actual.Date);
        }
    }

    public static class Extensions
    {
        public static TResult Project<TSource,TResult>(this TSource order, Func<TSource, TResult> selector)
        {
            return selector(order);
        }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Date { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}