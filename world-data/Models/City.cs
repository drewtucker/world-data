using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using WorldDataApp;

namespace WorldDataApp.Models
{
  public class City
  {
    private string _name;
    private int _population;
    private string _code;

    public City(string name, int population, string code)
    {
      _name = name;
      _population = population;
      _code = code;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public string GetCode()
    {
      return _code;
    }

    public void SetCode(string newCode)
    {
      _code = newCode;
    }

    public static List<City> GetAllCities()
    {
      List<City> allCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string cityName = rdr.GetString(1);
        int cityPopulation = rdr.GetInt32(4);
        string cityCode = rdr.GetString(2);
        City newCity = new City(cityName, cityPopulation, cityCode);
        allCities.Add(newCity);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
