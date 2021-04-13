using Microsoft.VisualStudio.TestTools.UnitTesting;
using test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        //-------------------客户----------------------
        static Customer JackMa = new Customer("Jack Ma");
        static Customer LeiJun = new Customer("Lei Jun");
        //-------------------客户----------------------

        //-------------------商品----------------------
        static Product hdnoodle = new Product("hd noodles", 5);
        static Product dumpling = new Product("dumpling", 8);
        static Product baozi = new Product("bao zi", 2);
        static Product hamburger = new Product("hamburger", 10);
        static Product xiaomi = new Product("xiao mi", 3000);
        //-------------------商品----------------------
        static  Order o1 = new Order(JackMa);
        static OrderDetails o_1 = new OrderDetails(baozi, 100);
        static OrderDetails o_2 = new OrderDetails(hamburger, 50);


        [TestMethod()]
        public void AddOrderTest()
        {
            
            OrderService.AddOrder(o1);
            Assert.IsTrue(OrderService.blanket_order.Contains(o1));
        }


        [TestMethod()]
        public void AddOrderitemTest()
        {
            OrderService.AddOrderitem(o1, o_1);
            Assert.IsTrue(o1.orderitem.Contains(o_1));

        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService.DeleteOrder(o1);
            Assert.IsTrue(!OrderService.blanket_order.Contains(o1));
        }

        [TestMethod()]
        public void DeleteOrderitemTest()
        {
            OrderService.AddOrder(o1);
            OrderService.DeleteOrderitem(o1, o_1);
            Assert.IsTrue(!o1.orderitem.Contains(o_1));
        }

        [TestMethod()]
        public void ChangeOrderitmeTest()
        {
            OrderService.AddOrderitem(o1, o_1);
            OrderService.ChangeOrderitme(o1, o_1, o_2);
            Assert.IsTrue(o1.orderitem.Contains(o_2));
        }

        [TestMethod()]
        public void GetOrderbyidTest()
        {

            foreach (var item in OrderService.GetOrderbyid(1))
            {
                Assert.AreEqual(item, o1);
            }

        }

        [TestMethod()]
        public void GetOrderTest()
        {
            List<Order> od = new List<Order>();
            od.Add(o1);
            foreach(var item in od)
            {
Console.WriteLine(item);
            }
            Assert.IsTrue(od.All(OrderService.GetOrder(hamburger).Contains) && od.Count == OrderService.GetOrder(hamburger).Count);
        }
    

        [TestMethod()]
        public void GetOrderTest1()
        {
            List<Order> od = new List<Order>();
            od.Add(o1);
            Assert.IsTrue(od.All(OrderService.GetOrder("Jack Ma").Contains) && od.Count == OrderService.GetOrder("Jack Ma").Count);

        }

        [TestMethod()]
        public void GetOrderTest2()
        {
            List<Order> od = new List<Order>();
            od.Add(o1);
            Assert.IsTrue(od.All(OrderService.GetOrder(500).Contains) && od.Count == OrderService.GetOrder(500).Count);
        }

        [TestMethod()]
        public void export_and_importTest()
        {

            OrderService.export();
            //Assert.IsTrue(OrderService.import("order.xml").All(OrderService.blanket_order.Contains) && OrderService.import("order.xml").Count == OrderService.blanket_order.Count);
            List<Order> od = OrderService.import("rder.xml");//文件名错误；
            Assert.IsTrue(OrderService.iserror);
            OrderService.export();//文件已存在的情况；
            Assert.IsTrue(OrderService.iserror);

        }
    }
    }