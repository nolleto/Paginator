using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestPageIndex()
        {
            var persons = Person.Get().AsQueryable();
            var page0 = persons.Page(x => x.Name);
            var page1 = persons.Page(x => x.Name, 2);

            Assert.AreEqual(page0.Index, 1);
            Assert.AreEqual(page0.Items.Length, 10);
            Assert.AreEqual(page0.Items[0].Name, "Alisha");
            Assert.AreEqual(page1.Index, 2);
            Assert.AreEqual(page1.Items[0].Name, "Jesenia");
        }

        [TestMethod]
        public void TestPageLength()
        {
            var persons = Person.Get().AsQueryable();
            Func<int, int> funcPassingOnMethod = (length) =>
            {
                return persons.Page(x => x.Name, 0, length).Length;
            };
            Func<int, int> funcSetGlobal = (length) =>
            {
                Paginator.Defaults.PageLength = length;
                return persons.Page(x => x.Name, 0).Length;
            };
            

            for (int i = 0; i < persons.Count(); i++)
            {
                Assert.AreEqual(funcPassingOnMethod(i), i);
            }

            for (int i = 0; i < persons.Count(); i++)
            {
                Assert.AreEqual(funcSetGlobal(i), i);
            }
        }

        [TestMethod]
        public void TestOrderBy()
        {
            var persons = Person.Get().AsQueryable();
            var page = persons.Page(x => x.Name);

            Assert.AreEqual(page.Items[0].Name, "Alisha");
            Assert.AreEqual(page.Items[1].Name, "Bruce");
            Assert.AreEqual(page.Items[2].Name, "Carleen");
            Assert.AreEqual(page.Items[3].Name, "Christeen");
            Assert.AreEqual(page.Items[4].Name, "Danial");
            Assert.AreEqual(page.Items[5].Name, "Dung");
            Assert.AreEqual(page.Items[6].Name, "Ellen");
            Assert.AreEqual(page.Items[7].Name, "Gertie");
            Assert.AreEqual(page.Items[8].Name, "Jeannine");
            Assert.AreEqual(page.Items[9].Name, "Jerrell");
        }

        [TestMethod]
        public void TestCount()
        {
            var persons = Person.Get().AsQueryable();
            var page = persons.Page(x => x.Name);
            
            Assert.AreEqual(page.Count, 20);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public static Person[] Get()
        {
            return new Person[]
            {
                new Person { Name = "Marvis", Age = 11 },
                new Person { Name = "Jerrell", Age = 41 },
                new Person { Name = "Ellen", Age = 55 },
                new Person { Name = "Jesenia", Age = 82 },
                new Person { Name = "Sophia", Age = 8 },
                new Person { Name = "Pa", Age = 25 },
                new Person { Name = "Christeen", Age = 42 },
                new Person { Name = "Alisha", Age = 32 },
                new Person { Name = "Quintin", Age = 82 },
                new Person { Name = "Danial", Age = 22 },
                new Person { Name = "Jeannine", Age = 35 },
                new Person { Name = "Viviana", Age = 34 },
                new Person { Name = "Porsche", Age = 21 },
                new Person { Name = "Jesusa", Age = 18 },
                new Person { Name = "Gertie", Age = 64 },
                new Person { Name = "Dung", Age = 17 },
                new Person { Name = "Carleen", Age = 49 },
                new Person { Name = "Latesha", Age = 16 },
                new Person { Name = "Bruce", Age = 29 },
                new Person { Name = "Phebe", Age = 32 },
            };
        }
    }
}
