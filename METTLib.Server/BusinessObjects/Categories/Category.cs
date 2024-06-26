﻿// Generated 18 Jan 2021 13:22 - Singular Systems Object Generator Version 2.2.694
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

namespace MELib.Categories
{
  [Serializable]
  public class Category
   : MEBusinessBase<Category>
  {
    #region " Properties and Methods "

    #region " Properties "

    public static PropertyInfo<int> CategoryIDProperty = RegisterProperty<int>(c => c.CategoryID, "ID", 0);
    /// <summary>
    /// Gets the ID value
    /// </summary>
    [Display(AutoGenerateField = false), Key]
    public int CategoryID
    {
      get { return GetProperty(CategoryIDProperty); }
    }

    public static PropertyInfo<String> CategoryNameProperty = RegisterProperty<String>(c => c.CategoryName, "Category Name", "");
    /// <summary>
    /// Gets and sets the Category Name value
    /// </summary>
    [Display(Name = "Category Name", Description = ""),
    StringLength(250, ErrorMessage = "Category Name cannot be more than 250 characters")]
    public String CategoryName
    {
      get { return GetProperty(CategoryNameProperty); }
      set { SetProperty(CategoryNameProperty, value); }
    }

    public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Is Active", true);
    /// <summary>
    /// Gets and sets the Is Active value
    /// </summary>
    [Display(Name = "Is Active", Description = "Indicator showing if the Movie is Active"),
    Required(ErrorMessage = "Is Active required")]
    public Boolean IsActiveInd
    {
      get { return GetProperty(IsActiveIndProperty); }
      set { SetProperty(IsActiveIndProperty, value); }
    }

    public static PropertyInfo<DateTime?> DeletedDateProperty = RegisterProperty<DateTime?>(c => c.DeletedDate, "Deleted Date");
    /// <summary>
    /// Gets and sets the Deleted Date value
    /// </summary>
    [Display(Name = "Deleted Date", Description = "When this record was deleted")]
    public DateTime? DeletedDate
    {
      get
      {
        return GetProperty(DeletedDateProperty);
      }
      set
      {
        SetProperty(DeletedDateProperty, value);
      }
    }

    public static PropertyInfo<int> DeletedByProperty = RegisterProperty<int>(c => c.DeletedBy, "Deleted By", 0);
    /// <summary>
    /// Gets and sets the Deleted By value
    /// </summary>
    [Display(Name = "Deleted By", Description = "User that deleted the record")]
    public int DeletedBy
    {
      get { return GetProperty(DeletedByProperty); }
      set { SetProperty(DeletedByProperty, value); }
    }

    public static PropertyInfo<SmartDate> CreatedDateProperty = RegisterProperty<SmartDate>(c => c.CreatedDate, "Created Date", new SmartDate(DateTime.Now));
    /// <summary>
    /// Gets the Created Date value
    /// </summary>
    [Display(AutoGenerateField = false)]
    public SmartDate CreatedDate
    {
      get { return GetProperty(CreatedDateProperty); }
    }

    public static PropertyInfo<int> CreatedByProperty = RegisterProperty<int>(c => c.CreatedBy, "Created By", 0);
    /// <summary>
    /// Gets the Created By value
    /// </summary>
    [Display(AutoGenerateField = false)]
    public int CreatedBy
    {
      get { return GetProperty(CreatedByProperty); }
    }

    public static PropertyInfo<SmartDate> ModifiedDateProperty = RegisterProperty<SmartDate>(c => c.ModifiedDate, "Modified Date", new SmartDate(DateTime.Now));
    /// <summary>
    /// Gets the Modified Date value
    /// </summary>
    [Display(AutoGenerateField = false)]
    public SmartDate ModifiedDate
    {
      get { return GetProperty(ModifiedDateProperty); }
    }

    public static PropertyInfo<int> ModifiedByProperty = RegisterProperty<int>(c => c.ModifiedBy, "Modified By", 0);
    /// <summary>
    /// Gets the Modified By value
    /// </summary>
    [Display(AutoGenerateField = false)]
    public int ModifiedBy
    {
      get { return GetProperty(ModifiedByProperty); }
    }

    #endregion

    #region " Child Lists "

    public static PropertyInfo<SubCategoryList> SubCategoryListProperty = RegisterProperty<SubCategoryList>(c => c.SubCategoryList, "Sub Category List");

    public SubCategoryList SubCategoryList
    {
      get
      {
        if (GetProperty(SubCategoryListProperty) == null)
        {
          LoadProperty(SubCategoryListProperty, Categories.SubCategoryList.NewSubCategoryList());
        }
        return GetProperty(SubCategoryListProperty);
      }
    }

    #endregion

    #region " Methods "

    protected override object GetIdValue()
    {
      return GetProperty(CategoryIDProperty);
    }

    public override string ToString()
    {
      if (this.CategoryName.Length == 0)
      {
        if (this.IsNew)
        {
          return String.Format("New {0}", "Category");
        }
        else
        {
          return String.Format("Blank {0}", "Category");
        }
      }
      else
      {
        return this.CategoryName;
      }
    }

    protected override String[] TableReferencesToIgnore
    {
      get
      {
        return new String[] { "SubCategories" };
      }
    }

    #endregion

    #endregion

    #region " Validation Rules "

    protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
    }

    #endregion

    #region " Data Access & Factory Methods "

    protected override void OnCreate()
    {
      // This is called when a new object is created
      // Set any variables here, not in the constructor or NewCategory() method.
    }

    public static Category NewCategory()
    {
      return DataPortal.CreateChild<Category>();
    }

    public Category()
    {
      MarkAsChild();
    }

    internal static Category GetCategory(SafeDataReader dr)
    {
      var c = new Category();
      c.Fetch(dr);
      return c;
    }

    protected void Fetch(SafeDataReader sdr)
    {
      using (BypassPropertyChecks)
      {
        int i = 0;
        LoadProperty(CategoryIDProperty, sdr.GetInt32(i++));
        LoadProperty(CategoryNameProperty, sdr.GetString(i++));
        LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
        LoadProperty(DeletedDateProperty, sdr.GetValue(i++));
        LoadProperty(DeletedByProperty, sdr.GetInt32(i++));
        LoadProperty(CreatedDateProperty, sdr.GetSmartDate(i++));
        LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
        LoadProperty(ModifiedDateProperty, sdr.GetSmartDate(i++));
        LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
      }

      MarkAsChild();
      MarkOld();
      BusinessRules.CheckRules();
    }

    protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
    {
      LoadProperty(ModifiedByProperty, Settings.CurrentUser.UserID);

      AddPrimaryKeyParam(cm, CategoryIDProperty);

      cm.Parameters.AddWithValue("@CategoryName", GetProperty(CategoryNameProperty));
      cm.Parameters.AddWithValue("@IsActiveInd", GetProperty(IsActiveIndProperty));
      cm.Parameters.AddWithValue("@DeletedDate", Singular.Misc.NothingDBNull(DeletedDate));
      cm.Parameters.AddWithValue("@DeletedBy", GetProperty(DeletedByProperty));
      cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));

      return (scm) =>
      {
  // Post Save
  if (this.IsNew)
        {
          LoadProperty(CategoryIDProperty, scm.Parameters["@CategoryID"].Value);
        }
      };
    }

    protected override void SaveChildren()
    {
      UpdateChild(GetProperty(SubCategoryListProperty));
    }

    protected override void SetupDeleteCommand(SqlCommand cm)
    {
      cm.Parameters.AddWithValue("@CategoryID", GetProperty(CategoryIDProperty));
    }

    #endregion

  }

}