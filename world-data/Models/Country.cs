using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using WorldDataApp;

namespace WorldDataApp.Models
{
  public class Country
  {
    private string _name;
    private string _code;
    private int _population;

    public Country(string name, string code, int population)
    {
      _name = name;
      _code = code;
      _population = population;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetCode()
    {
      return _code;
    }

    public void SetCode(string newCode)
    {
      _code = newCode;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryName = rdr.GetString(1);
        string countryCode = rdr.GetString(0);
        int countryPopulation = rdr.GetInt32(6);
        Country newCountry = new Country(countryName, countryCode, countryPopulation);
        allCountries.Add(newCountry);

      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> SortByPopulation()
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country ORDER BY population DESC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryName = rdr.GetString(1);
        string countryCode = rdr.GetString(0);
        int countryPopulation = rdr.GetInt32(6);
        Country newCountry = new Country(countryName, countryCode, countryPopulation);
        allCountries.Add(newCountry);

      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> SortByAmerica()
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE code = 'USA';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryName = rdr.GetString(1);
        string countryCode = rdr.GetString(0);
        int countryPopulation = rdr.GetInt32(6);
        Country newCountry = new Country(countryName, countryCode, countryPopulation);
        allCountries.Add(newCountry);

      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
  }
}
