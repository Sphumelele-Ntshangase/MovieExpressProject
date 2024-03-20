﻿// Generated 26 Mar 2019 16:02 - Singular Systems Object Generator Version 2.2.694
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
	public class ROQuestionnaireYear
	 : METTReadOnlyBase<ROQuestionnaireYear>
	{
		#region " Properties and Methods "

		#region " Properties "

		public static PropertyInfo<int> QuestionnaireYearIDProperty = RegisterProperty<int>(c => c.QuestionnaireYearID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		[Display(AutoGenerateField = false), Key]
		public int QuestionnaireYearID
		{
			get { return GetProperty(QuestionnaireYearIDProperty); }
		}

		public static PropertyInfo<int> QuestionnaireYearProperty = RegisterProperty<int>(c => c.QuestionnaireYear, "Questionnaire Year", 0);
		/// <summary>
		/// Gets the Questionnaire Year value
		/// </summary>
		[Display(Name = "Questionnaire Year", Description = "")]
		public int QuestionnaireYear
		{
			get { return GetProperty(QuestionnaireYearProperty); }
		}

		public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Is Active", true);
		/// <summary>
		/// Gets the Is Active value
		/// </summary>
		[Display(Name = "Is Active", Description = "Field to indicate if the country record is active or not")]
		public Boolean IsActiveInd
		{
			get { return GetProperty(IsActiveIndProperty); }
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

		public static PropertyInfo<SmartDate> CreatedDateTimeProperty = RegisterProperty<SmartDate>(c => c.CreatedDateTime, "Created Date Time", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Created Date Time value
		/// </summary>
		[Display(AutoGenerateField = false)]
		public SmartDate CreatedDateTime
		{
			get { return GetProperty(CreatedDateTimeProperty); }
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

		public static PropertyInfo<SmartDate> ModifiedDateTimeProperty = RegisterProperty<SmartDate>(c => c.ModifiedDateTime, "Modified Date Time", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Modified Date Time value
		/// </summary>
		[Display(AutoGenerateField = false)]
		public SmartDate ModifiedDateTime
		{
			get { return GetProperty(ModifiedDateTimeProperty); }
		}

		#endregion

		#region " Methods "

		protected override object GetIdValue()
		{
			return GetProperty(QuestionnaireYearIDProperty);
		}

		public override string ToString()
		{
			return this.CreatedDateTime.ToString();
		}

		#endregion

		#endregion

		#region " Data Access & Factory Methods "

		internal static ROQuestionnaireYear GetROQuestionnaireYear(SafeDataReader dr)
		{
			var r = new ROQuestionnaireYear();
			r.Fetch(dr);
			return r;
		}

		protected void Fetch(SafeDataReader sdr)
		{
			int i = 0;
			LoadProperty(QuestionnaireYearIDProperty, sdr.GetInt32(i++));
			LoadProperty(QuestionnaireYearProperty, sdr.GetInt32(i++));
			LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
			LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
			LoadProperty(CreatedDateTimeProperty, sdr.GetSmartDate(i++));
			LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
			LoadProperty(ModifiedDateTimeProperty, sdr.GetSmartDate(i++));
		}

		#endregion

	}

}