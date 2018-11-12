using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mvc5AjaxApp.Domain.Entities;
using Mvc5AjaxApp.WebUI.Infrastructure;
using Mvc5AjaxApp.WebUI.Infrastructure.Generator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc5AjaxApp.Tests
{
    [TestClass]
    public class DigitGeneratorTests
    {
        private HashSet<Digit> GetHashSetData()
        {
            return new HashSet<Digit>(new DigitComparer()) {
                new Digit() { Number = "1" },
                new Digit() { Number = "2" },
                new Digit() { Number = "3" },
                new Digit() { Number = "4" },
            };
        }

        [TestMethod]
        public void Can_Generate_Digits()
        {
            //Arrange
            DigitGenerator digitGenerator = new DigitGenerator(new DigitCreator(), new HashSet<Digit>());

            //Act
            var result = digitGenerator.GenerateDigits(null, 4).ToList();

            //Assert
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(16, result[0].Number.Length);
            Assert.AreEqual(16, result[1].Number.Length);
            Assert.AreEqual(16, result[2].Number.Length);
            Assert.AreEqual(16, result[3].Number.Length);
        }

        [TestMethod]
        public void Can_Recieve_Existing_Digits()
        {
            //Arrange
            HashSet<Digit> hashSetWithData = GetHashSetData();

            //Act
            DigitGenerator target = new DigitGenerator(new DigitCreator(), null);
            var result = target.GenerateDigits(hashSetWithData, 4).ToList();

            //Assert
            Assert.AreEqual(8, result.Count());
            Assert.AreEqual("1", result[0].Number);
            Assert.AreEqual("2", result[1].Number);
            Assert.AreEqual("3", result[2].Number);
            Assert.AreEqual("4", result[3].Number);
            Assert.AreEqual(16, result[4].Number.Length);
            Assert.AreEqual(16, result[5].Number.Length);
            Assert.AreEqual(16, result[6].Number.Length);
            Assert.AreEqual(16, result[7].Number.Length);

        }

        [TestMethod]
        public void Can_Skip_Non_Unique_Digit()
        {
            //Arrange
            HashSet<Digit> hashSet = GetHashSetData();
            var mockDigitCreator = new Mock<IDigitCreator>();
            var number = 1;
            mockDigitCreator.Setup(dc => dc.CreateDigit()).
                Returns(() => new Digit() { Number = number.ToString() })
                .Callback(() => new Digit() { Number = (number++).ToString() });

            //Act
            DigitGenerator target = new DigitGenerator(mockDigitCreator.Object, hashSet);
            var result = target.GenerateDigits(GetHashSetData(), 2).ToList();

            //Assert
            Assert.AreEqual(6, result.Count());
            Assert.IsTrue(result.Where(item => item.Number == "1").Count() == 1);
        }
    }
}
