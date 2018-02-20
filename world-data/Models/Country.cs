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
    private int _independenceYear;
    private float _lifeExpectancy;
    private string _formOfGov;

    public Country(string name, string code, int population, int independenceYear, float lifeExpectancy, string formOfGov)
    {
      _name = name;
      _code = code;
      _population = population;
      _independenceYear = independenceYear;
      _lifeExpectancy = lifeExpectancy;
      _formOfGov = formOfGov;
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

    public int GetIndependenceYear()
    {
      return _independenceYear;
    }

    public void SetIndependenceYear(int newIndependenceYear)
    {
      _independenceYear = newIndependenceYear;
    }

    public float GetLifeExpectancy()
    {
      return _lifeExpectancy;
    }

    public void SetLifeExpentancy(float newLifeExpectancy)
    {
      _lifeExpectancy = newLifeExpectancy;
    }

    public string GetFormOfGov()
    {
      return _formOfGov;
    }

    public void SetFormOfGov(string newFormOfGov)
    {
      _formOfGov = newFormOfGov;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM country;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
        int countryIndependenceYear = 0;
        if(!rdr.IsDBNull(5))
        {
          countryIndependenceYear = rdr.GetInt32(5);
        }
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(7))
        {
          countryLifeExpectancy = rdr.GetFloat(7);
        }
        string countryFormOfGov = rdr.GetString(11);
        Country newCountry = new Country(countryName, countryCode, countryPopulation, countryIndependenceYear, countryLifeExpectancy, countryFormOfGov);
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
        int countryIndependenceYear = 0;
        if(!rdr.IsDBNull(5))
        {
          countryIndependenceYear = rdr.GetInt32(5);
        }
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(7))
        {
          countryLifeExpectancy = rdr.GetFloat(7);
        }
        string countryFormOfGov = rdr.GetString(11);
        Country newCountry = new Country(countryName, countryCode, countryPopulation, countryIndependenceYear, countryLifeExpectancy, countryFormOfGov);
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
        int countryIndependenceYear = 0;
        if(!rdr.IsDBNull(5))
        {
          countryIndependenceYear = rdr.GetInt32(5);
        }
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(7))
        {
          countryLifeExpectancy = rdr.GetFloat(7);
        }
        string countryFormOfGov = rdr.GetString(11);
        Country newCountry = new Country(countryName, countryCode, countryPopulation, countryIndependenceYear, countryLifeExpectancy, countryFormOfGov);
        allCountries.Add(newCountry);

      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public void Save()
          {
            MySqlConnection conn = DB.Connection();
           conn.Open();

           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO `country` (`name`) VALUES (@countryName);";

           MySqlParameter name = new MySqlParameter();
           name.ParameterName = "@countryName";
           name.Value = this._name;
           cmd.Parameters.Add(name);

           cmd.ExecuteNonQuery();


            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
          }
  }
}
