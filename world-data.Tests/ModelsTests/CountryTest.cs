using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldDataApp.Models;

namespace WorldDataApp.Tests
{

  [TestClass]
  public class CountryTests : IDisposable
  {
    public void Dispose()
    {
      Country.DeleteAll();
    }
    public CountryTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Country.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CountryList()
    {
      //Arrange
      Country testCountry1 = new Country("Spain", "SPN", 20000);
      Country testCountry2 = new Country("Spain", "SPN", 20000);

      //Act
      testCountry1.Save();
      testCountry2.Save();
      List<Country> result = new List<Country>{testCountry1};
      List<Country> testList = new List<Country>{testCountry2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
