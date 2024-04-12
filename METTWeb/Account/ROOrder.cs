﻿// Generated 09 Apr 2024 14:57 - Singular Systems Object Generator Version 3.0.000
//<auto-generated/>
using System;
using Csla;
using Csla.Serialization;
using Csla.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Singular;
using Singular.DataAnnotations;
using System.Data;
using System.Data.SqlClient;


namespace MEWeb.Movies
{
  [Serializable]
  public class ROOrder
  : SingularReadOnlyBase<ROOrder>
  {
    #region " Properties and Methods "

    #region " Properties "

    public static PropertyInfo<int> OrderIDProperty = RegisterProperty<int>(c => c.OrderID, "ID", 0);
    /// <summary>
    /// Gets the ID value
    /// </summary>
    [Display(AutoGenerateField = false), Key]
    public int OrderID
    {
      get { return GetProperty(OrderIDProperty); }
    }

    public static PropertyInfo<int> UserIDProperty = RegisterProperty<int>(c => c.UserID, "User", 0);
    /// <summary>
    /// Gets the User value
    /// </summary>
    [Display(Name = "User", Description = "")]
    public int UserID
    {
      get { return GetProperty(UserIDProperty); }
    }

    public static PropertyInfo<int> UserMovieIDProperty = RegisterProperty<int>(c => c.UserMovieID, "User Movie", 0);
    /// <summary>
    /// Gets the User Movie value
    /// </summary>
    [Display(Name = "User Movie", Description = "")]
    public int UserMovieID
    {
      get { return GetProperty(UserMovieIDProperty); }
    }

    public static PropertyInfo<string> MovieTitleProperty = RegisterProperty<string>(c => c.MovieTitle, "Movie Title", "");
    /// <summary>
    /// Gets the Movie Title value
    /// </summary>
    [Display(Name = "Movie Title", Description = "")]
    public string MovieTitle
    {
      get { return GetProperty(MovieTitleProperty); }
    }

    public static PropertyInfo<decimal> PriceProperty = RegisterProperty<decimal>(c => c.Price, "Price", (decimal)0);
    /// <summary>
    /// Gets the Price value
    /// </summary>
    [Display(Name = "Price", Description = "")]
    public decimal Price
    {
      get { return GetProperty(PriceProperty); }
    }

    public static PropertyInfo<DateTime> OrderDateProperty = RegisterProperty<DateTime>(c => c.OrderDate, "Order Date");
    /// <summary>
    /// Gets the Order Date value
    /// </summary>
    [Display(Name = "Order Date", Description = "")]
    public DateTime OrderDate
    {
      get
      {
        return GetProperty(OrderDateProperty);
      }
    }

    #endregion

    #region " Methods "

    protected override object GetIdValue()
    {
      return GetProperty(OrderIDProperty);
    }

    public override string ToString()
    {
      return this.MovieTitle;
    }

    #endregion

    #endregion

    #region " Data Access & Factory Methods "

    internal static ROOrder GetROOrder(SafeDataReader dr)
    {
      var r = new ROOrder();
      r.Fetch(dr);
      return r;
    }

    protected void Fetch(SafeDataReader sdr)
    {
      int i = 0;
      LoadProperty(OrderIDProperty, sdr.GetInt32(i++));
      LoadProperty(UserIDProperty, sdr.GetInt32(i++));
      LoadProperty(UserMovieIDProperty, sdr.GetInt32(i++));
      LoadProperty(MovieTitleProperty, sdr.GetString(i++));
      LoadProperty(PriceProperty, sdr.GetDecimal(i++));
      LoadProperty(OrderDateProperty, sdr.GetValue(i++));
    }

    #endregion

  }

}