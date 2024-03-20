﻿// Generated 12 Jul 2018 07:23 - Singular Systems Object Generator Version 2.2.693
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


namespace METTLib.RO
{
	[Serializable]
	public class ROJobdescription
	 : METTReadOnlyBase<ROJobdescription>
	{
		#region " Properties and Methods "

		#region " Properties "

		public static PropertyInfo<int> JobDescriptionIDProperty = RegisterProperty<int>(c => c.JobDescriptionID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		[Display(AutoGenerateField = false), Key, DisplayName("ID")]
		public int JobDescriptionID
		{
			get { return GetProperty(JobDescriptionIDProperty); }
		}

		public static PropertyInfo<String> JobDescriptionNameProperty = RegisterProperty<String>(c => c.JobDescriptionName, "Jobdescriptionname", "");
		/// <summary>
		/// Gets the Jobdescriptionname value
		/// </summary>
		[Display(Name = "Jobdescriptionname", Description = ""), DisplayName("Jobdescriptionname")]
		public String JobDescriptionName
		{
			get { return GetProperty(JobDescriptionNameProperty); }
		}

		public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Isactiveind", true);
		/// <summary>
		/// Gets the Isactiveind value
		/// </summary>
		[Display(Name = "Isactiveind", Description = "Indicates whether question is currently active"), DisplayName("Isactiveind")]
		public Boolean IsActiveInd
		{
			get { return GetProperty(IsActiveIndProperty); }
		}

		public static PropertyInfo<int> CreatedByProperty = RegisterProperty<int>(c => c.CreatedBy, "Createdby", 0);
		/// <summary>
		/// Gets the Createdby value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Createdby")]
		public int? CreatedBy
		{
			get { return GetProperty(CreatedByProperty); }
		}

		public static PropertyInfo<SmartDate> CreatedDateTimeProperty = RegisterProperty<SmartDate>(c => c.CreatedDateTime, "Createddatetime", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Createddatetime value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Createddatetime")]
		public SmartDate CreatedDateTime
		{
			get { return GetProperty(CreatedDateTimeProperty); }
		}

		public static PropertyInfo<int> ModifiedByProperty = RegisterProperty<int>(c => c.ModifiedBy, "Modifiedby", 0);
		/// <summary>
		/// Gets the Modifiedby value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Modifiedby")]
		public int? ModifiedBy
		{
			get { return GetProperty(ModifiedByProperty); }
		}

		public static PropertyInfo<SmartDate> ModifiedDateTimeProperty = RegisterProperty<SmartDate>(c => c.ModifiedDateTime, "Modifieddatetime", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Modifieddatetime value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Modifieddatetime")]
		public SmartDate ModifiedDateTime
		{
			get { return GetProperty(ModifiedDateTimeProperty); }
		}

		#endregion

		#region " Methods "

		protected override object GetIdValue()
		{
			return GetProperty(JobDescriptionIDProperty);
		}

		public override string ToString()
		{
			return this.JobDescriptionName;
		}

		#endregion

		#endregion

		#region " Data Access & Factory Methods "

		internal static ROJobdescription GetROJobdescription(SafeDataReader dr)
		{
			var r = new ROJobdescription();
			r.Fetch(dr);
			return r;
		}

		protected void Fetch(SafeDataReader sdr)
		{
			int i = 0;
			LoadProperty(JobDescriptionIDProperty, sdr.GetInt32(i++));
			LoadProperty(JobDescriptionNameProperty, sdr.GetString(i++));
			LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
			LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
			LoadProperty(CreatedDateTimeProperty, sdr.GetSmartDate(i++));
			LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
			LoadProperty(ModifiedDateTimeProperty, sdr.GetSmartDate(i++));
		}

		#endregion

	}

}