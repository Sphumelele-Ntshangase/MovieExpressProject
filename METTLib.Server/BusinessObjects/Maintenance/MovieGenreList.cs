﻿// Generated 03 Jan 2021 10:51 - Singular Systems Object Generator Version 2.2.694
//<auto-generated/>
using System;
using Csla;
using Csla.Serialization;
using Csla.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Singular;
using System.Data;
using System.Data.SqlClient;


namespace MELib.Maintenance
{
  [Serializable]
  public class MovieGenreList
   : MEBusinessListBase<MovieGenreList, MovieGenre>
  {
    #region " Business Methods "

    public MovieGenre GetItem(int MovieGenreID)
    {
      foreach (MovieGenre child in this)
      {
        if (child.MovieGenreID == MovieGenreID)
        {
          return child;
        }
      }
      return null;
    }

    public override string ToString()
    {
      return "Movie Genres";
    }

    #endregion

    #region " Data Access "

    [Serializable]
    public class Criteria
      : CriteriaBase<Criteria>
    {
      public Criteria()
      {
      }

    }

    public static MovieGenreList NewMovieGenreList()
    {
      return new MovieGenreList();
    }

    public MovieGenreList()
    {
      // must have parameter-less constructor
    }

    public static MovieGenreList GetMovieGenreList()
    {
      return DataPortal.Fetch<MovieGenreList>(new Criteria());
    }

    protected void Fetch(SafeDataReader sdr)
    {
      this.RaiseListChangedEvents = false;
      while (sdr.Read())
      {
        this.Add(MovieGenre.GetMovieGenre(sdr));
      }
      this.RaiseListChangedEvents = true;
    }

    protected override void DataPortal_Fetch(Object criteria)
    {
      Criteria crit = (Criteria)criteria;
      using (SqlConnection cn = new SqlConnection(Singular.Settings.ConnectionString))
      {
        cn.Open();
        try
        {
          using (SqlCommand cm = cn.CreateCommand())
          {
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "GetProcs.getMovieGenreList";
            using (SafeDataReader sdr = new SafeDataReader(cm.ExecuteReader()))
            {
              Fetch(sdr);
            }
          }
        }
        finally
        {
          cn.Close();
        }
      }
    }

    #endregion

  }

}