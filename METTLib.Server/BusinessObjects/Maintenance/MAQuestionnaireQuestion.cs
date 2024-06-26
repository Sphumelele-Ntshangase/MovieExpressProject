﻿// Generated 02 Oct 2018 11:29 - Singular Systems Object Generator Version 2.2.694
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
using Singular.Web;


namespace METTLib.Maintenance
{
	[Serializable]
	public class MAQuestionnaireQuestion
	 : METTBusinessBase<MAQuestionnaireQuestion>
	{
		#region " Properties and Methods "

		#region " Properties "

		public static PropertyInfo<int> QuestionnaireQuestionIDProperty = RegisterProperty<int>(c => c.QuestionnaireQuestionID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		[Display(AutoGenerateField = false), Key]
		public int QuestionnaireQuestionID
		{
			get { return GetProperty(QuestionnaireQuestionIDProperty); }
		}




		public static PropertyInfo<int> QuestionnaireQuestionTypeIDProperty = RegisterProperty<int>(c => c.QuestionnaireQuestionTypeID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		//[Display(AutoGenerateField = false)]
		public int QuestionnaireQuestionTypeID
		{
			get { return GetProperty(QuestionnaireQuestionTypeIDProperty); }
			set { SetProperty(QuestionnaireQuestionTypeIDProperty, value); }
		}




		public static PropertyInfo<int> QuestionnaireIDProperty = RegisterProperty<int>(c => c.QuestionnaireID, "Questionnaire ID", 0);
		/// <summary>
		/// Gets and sets the Indicator Detail value
		/// </summary>
		[Display(Name = "Questionnaire ID", Description = ""),
		Required(ErrorMessage = "Questionnaire ID")]
		public int QuestionnaireID
		{
			get { return GetProperty(QuestionnaireIDProperty); }
			set { SetProperty(QuestionnaireIDProperty, value); }
		}



		public static PropertyInfo<int> QuestionnaireGroupIDProperty = RegisterProperty<int>(c => c.QuestionnaireGroupID, "Questionnaire Group", 0);
		/// <summary>
		/// Gets and sets the Questionnaire Group value
		/// </summary>
		[Display(Name = "Questionnaire Group", Description = ""),
		Required(ErrorMessage = "Questionnaire Group required")]
		public int QuestionnaireGroupID
		{
			get { return GetProperty(QuestionnaireGroupIDProperty); }
			set { SetProperty(QuestionnaireGroupIDProperty, value); }
		}

		public static PropertyInfo<int> IndicatorDetailIDProperty = RegisterProperty<int>(c => c.IndicatorDetailID, "Indicator Detail", 0);
		/// <summary>
		/// Gets and sets the Indicator Detail value
		/// </summary>
		[Display(Name = "Indicator Detail", Description = ""),
		Required(ErrorMessage = "Indicator Detail required")]
		public int IndicatorDetailID
		{
			get { return GetProperty(IndicatorDetailIDProperty); }
			set { SetProperty(IndicatorDetailIDProperty, value); }
		}

		public static PropertyInfo<String> IndicatorDetailNameProperty = RegisterProperty<String>(c => c.IndicatorDetailName, "Indicator Detail Name", "");
		/// <summary>
		/// Gets and sets the Indicator Detail Name value
		/// </summary>
		[Display(Name = "Indicator Detail Name", Description = ""),
		StringLength(250, ErrorMessage = "Indicator Detail Name cannot be more than 250 characters")]
		public String IndicatorDetailName
		{
			get { return GetProperty(IndicatorDetailNameProperty); }
			set { SetProperty(IndicatorDetailNameProperty, value); }
		}

		public static PropertyInfo<int> QuestionIDProperty = RegisterProperty<int>(c => c.QuestionID, "Question", 0);
		/// <summary>
		/// Gets and sets the Question value
		/// </summary>
		[Display(Name = "Question", Description = ""),
		Required(ErrorMessage = "Question required")]
		public int QuestionID
		{
			get { return GetProperty(QuestionIDProperty); }
			set { SetProperty(QuestionIDProperty, value); }
		}

		public static PropertyInfo<String> QuestionProperty = RegisterProperty<String>(c => c.Question, "Question", "");
		/// <summary>
		/// Gets and sets the Question value
		/// </summary>
		[Display(Name = "Question", Description = ""),
		StringLength(250, ErrorMessage = "Question cannot be more than 250 characters")]
		public String Question
		{
			get { return GetProperty(QuestionProperty); }
			set { SetProperty(QuestionProperty, value); }
		}

		public static PropertyInfo<String> QuestionTooltipProperty = RegisterProperty<String>(c => c.QuestionTooltip, "Question Tooltip", "");
		/// <summary>
		/// Gets and sets the Question value
		/// </summary>
		[Display(Name = "QuestionTooltip", Description = ""),
		StringLength(2000, ErrorMessage = "Question tooltip cannot be more than 2000 characters")]
		public String QuestionTooltip
		{
			get { return GetProperty(QuestionTooltipProperty); }
			set { SetProperty(QuestionTooltipProperty, value); }
		}

		public static PropertyInfo<String> EvidenceTooltipProperty = RegisterProperty<String>(c => c.EvidenceTooltip, "Evidence Tooltip", "");
		/// <summary>
		/// Gets and sets the Evidence Tooltip value
		/// </summary>
		[Display(Name = "EvidenceTooltip", Description = ""),
		StringLength(2000, ErrorMessage = "Evidence tooltip cannot be more than 2000 characters")]
		public String EvidenceTooltip
		{
			get { return GetProperty(EvidenceTooltipProperty); }
			set { SetProperty(EvidenceTooltipProperty, value); }
		}


		public static PropertyInfo<int> SortOrderProperty = RegisterProperty<int>(c => c.SortOrder, "Sort Order", 0);
		/// <summary>
		/// Gets and sets the Indicator Detail value
		/// </summary>
		[Display(Name = "Sort Order", Description = ""),
		Required(ErrorMessage = "Sort Order")]
		public int SortOrder
		{
			get { return GetProperty(SortOrderProperty); }
			set { SetProperty(SortOrderProperty, value); }
		}

		public static PropertyInfo<int> ModifiedByProperty = RegisterProperty<int>(c => c.ModifiedBy, "Modified By", 0);
		/// <summary>
		/// Gets the Modified By value
		/// </summary>
		[Display(AutoGenerateField = false)]
		public int? ModifiedBy
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

		public static PropertyInfo<String> OriginalQuestionProperty = RegisterProperty<String>(c => c.OriginalQuestion, "OriginalQuestion", "");
		/// <summary>
		/// Gets and sets the Original Question value
		/// </summary>
		[Display(AutoGenerateField = false)]
		public String OriginalQuestion
		{
			get { return GetProperty(OriginalQuestionProperty); }
		}

		#endregion

		#region " Child Lists "

		public static PropertyInfo<MAQuestionnaireQuestionTypeList> MAQuestionnaireQuestionTypeListProperty = RegisterProperty<MAQuestionnaireQuestionTypeList>(c => c.MAQuestionnaireQuestionTypeList, "MA Questionnaire Question Type List");

		public MAQuestionnaireQuestionTypeList MAQuestionnaireQuestionTypeList
		{
			get
			{
				if (GetProperty(MAQuestionnaireQuestionTypeListProperty) == null)
				{
					LoadProperty(MAQuestionnaireQuestionTypeListProperty, Maintenance.MAQuestionnaireQuestionTypeList.NewMAQuestionnaireQuestionTypeList());
				}
				return GetProperty(MAQuestionnaireQuestionTypeListProperty);
			}
		}

		#endregion

		// ViewModel.QuestionnaireQuestionManagementSphereList.Set(result.Data.Item2);
		// ViewModel.QuestionnaireQuestionLegalDesignationsList.Set(result.Data.Item3);
		#region " Child Lists "
		public static PropertyInfo<QuestionnaireQuestionManagementSphereList> QuestionnaireQuestionManagementSphereListProperty = RegisterProperty<QuestionnaireQuestionManagementSphereList>(c => c.QuestionnaireQuestionManagementSphereList, "Management Spheres Child List");

		public QuestionnaireQuestionManagementSphereList QuestionnaireQuestionManagementSphereList
		{
			get
			{
				if (GetProperty(QuestionnaireQuestionManagementSphereListProperty) == null)
				{
					LoadProperty(QuestionnaireQuestionManagementSphereListProperty, QuestionnaireQuestionManagementSphereList.NewQuestionnaireQuestionManagementSphereList());
				}
				return GetProperty(QuestionnaireQuestionManagementSphereListProperty);
			}
		}

		public static PropertyInfo<QuestionnaireQuestionLegalDesignationList> QuestionnaireQuestionLegalDesignationListProperty = RegisterProperty<QuestionnaireQuestionLegalDesignationList>(c => c.QuestionnaireQuestionLegalDesignationList, "Legal Designation Child List");

		public QuestionnaireQuestionLegalDesignationList QuestionnaireQuestionLegalDesignationList
		{
			get
			{
				if (GetProperty(QuestionnaireQuestionLegalDesignationListProperty) == null)
				{
					LoadProperty(QuestionnaireQuestionLegalDesignationListProperty, QuestionnaireQuestionLegalDesignationList.NewQuestionnaireQuestionLegalDesignationList());
				}
				return GetProperty(QuestionnaireQuestionLegalDesignationListProperty);
			}
		}


		#endregion

		#region " Methods "

		protected override object GetIdValue()
		{
			return GetProperty(QuestionnaireQuestionIDProperty);
		}

		public override string ToString()
		{
			if (this.IndicatorDetailName.Length == 0)
			{
				if (this.IsNew)
				{
					return String.Format("New {0}", "Questionnaire Question");
				}
				else
				{
					return String.Format("Blank {0}", "Questionnaire Question");
				}
			}
			else
			{
				return this.IndicatorDetailName;
			}
		}

		protected override String[] TableReferencesToIgnore
		{
			get
			{
				return new String[] { "QuestionnaireQuestionTypes" };
			}
		}


		[WebCallable]
		public Result SaveQuestionnaireQuestion(METTLib.Maintenance.MAQuestionnaireQuestionList MAQuestionnaireQuestionList)
		{
			Result sr = new Result();

			
			if (MAQuestionnaireQuestionList.IsValid)
			{
				//Singular.SaveHelper SavedMAQuestionnaireQuestionHelper = MAQuestionnaireQuestion.TrySave(typeof(METTLib.Maintenance.MAQuestionnaireQuestionList));
				Singular.SaveHelper SavedMAQuestionnaireQuestionHelper = MAQuestionnaireQuestionList.TrySave();
				METTLib.Maintenance.MAQuestionnaireQuestionList SavedMAQuestionnaireQuestion = (METTLib.Maintenance.MAQuestionnaireQuestionList)SavedMAQuestionnaireQuestionHelper.SavedObject;

				//var SaveResult = MAQuestionnaireQuestion.TrySave();
				if (SavedMAQuestionnaireQuestionHelper.Success)
				{
					sr.Data = SavedMAQuestionnaireQuestion;
					sr.Success = true;
				}
				else
				{
					sr.ErrorText = SavedMAQuestionnaireQuestionHelper.ErrorText;
					sr.Success = false;
					return sr;
				}
				return sr;
			}
			else
			{
				sr.ErrorText = MAQuestionnaireQuestionList.GetErrorsAsHTMLString();
				return sr;
			}
		}


		//[WebCallable]
		//public Result SaveQuestionnaireQuestion(METTLib.Maintenance.MAQuestionnaireQuestionList MAQuestionnaireQuestionList)
		//{
		//	Result sr = new Result();


		//	var Questionnaires = METTLib.Maintenance.MAQuestionnaireQuestionList.GetMAQuestionnaireQuestionList();
		//	if (MAQuestionnaireQuestionList.IsValid)
		//	{
		//		var SaveResult = MAQuestionnaireQuestionList.TrySave();
		//		if (SaveResult.Success)
		//		{
		//			sr.Data = SaveResult.SavedObject;
		//			sr.Success = true;
		//		}
		//		else
		//		{
		//			sr.ErrorText = SaveResult.ErrorText;
		//			sr.Success = false;
		//			return sr;
		//		}
		//		return sr;
		//	}
		//	else
		//	{
		//		sr.ErrorText = MAQuestionnaireQuestionList.GetErrorsAsHTMLString();
		//		return sr;
		//	}
		//}

		[WebCallable]
		public Result DeleteQuestionnaireQuestionAnswerOption(int QuestionnaireQuestionAnswerOptionID)
		{
			Result sr = new Result();
			try
			{
				MAQuestionnaireQuestionList MAQuestionnaireQuestions = MAQuestionnaireQuestionList.GetMAQuestionnaireQuestionList();
				//Pass QuestionnaireQuestionAnswerOptionID in get
				if (MAQuestionnaireQuestions != null && MAQuestionnaireQuestions.Count > 0)
				{
					//QuestionnaireAnswerSets.ToList().ForEach(c => { c.DeletedInd = true; });
					//QuestionnaireAnswerSets.Save();
					sr.Success = true;
				}
				else
				{
					sr.Success = false;
				}
				sr.Success = true;
			}
			catch (Exception e)
			{
				sr.Data = e.Message;
				sr.Success = false;
			}
			return sr;
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
			// Set any variables here, not in the constructor or NewMAQuestionnaireQuestion() method.
		}

		public static MAQuestionnaireQuestion NewMAQuestionnaireQuestion()
		{
			return DataPortal.CreateChild<MAQuestionnaireQuestion>();
		}

		public MAQuestionnaireQuestion()
		{
			MarkAsChild();
		}

		internal static MAQuestionnaireQuestion GetMAQuestionnaireQuestion(SafeDataReader dr)
		{
			var m = new MAQuestionnaireQuestion();
			m.Fetch(dr);
			return m;
		}

		protected void Fetch(SafeDataReader sdr)
		{
			using (BypassPropertyChecks)
			{
				int i = 0;

				LoadProperty(QuestionnaireIDProperty, sdr.GetInt32(i++));
				LoadProperty(QuestionnaireQuestionTypeIDProperty, sdr.GetInt32(i++));
				LoadProperty(QuestionnaireQuestionIDProperty, sdr.GetInt32(i++));
				LoadProperty(QuestionnaireGroupIDProperty, sdr.GetInt32(i++));
				LoadProperty(IndicatorDetailIDProperty, sdr.GetInt32(i++));
				LoadProperty(IndicatorDetailNameProperty, sdr.GetString(i++));
				LoadProperty(QuestionIDProperty, sdr.GetInt32(i++));
				LoadProperty(QuestionProperty, sdr.GetString(i++));
				LoadProperty(QuestionTooltipProperty, sdr.GetString(i++));
				LoadProperty(EvidenceTooltipProperty, sdr.GetString(i++));
				LoadProperty(SortOrderProperty, sdr.GetInt32(i++));
				LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
				LoadProperty(ModifiedDateTimeProperty, sdr.GetSmartDate(i++));
				//will only use this property to determine if the question version has been changed
				LoadProperty(OriginalQuestionProperty, GetProperty(QuestionProperty));
			}

			MarkAsChild();
			MarkOld();
			BusinessRules.CheckRules();
		}

		protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
		{
			AddPrimaryKeyParam(cm, QuestionnaireQuestionIDProperty);

			cm.Parameters.AddWithValue("@QuestionnaireGroupID", GetProperty(QuestionnaireGroupIDProperty));
			cm.Parameters.AddWithValue("@IndicatorDetailID", GetProperty(IndicatorDetailIDProperty));
			cm.Parameters.AddWithValue("@IndicatorDetailName", GetProperty(IndicatorDetailNameProperty));
			cm.Parameters.AddWithValue("@QuestionID", GetProperty(QuestionIDProperty));
			cm.Parameters.AddWithValue("@Question", GetProperty(QuestionProperty));
			cm.Parameters.AddWithValue("@QuestionTooltip", Singular.Misc.NothingDBNull(GetProperty(QuestionTooltipProperty)));
			cm.Parameters.AddWithValue("@EvidenceTooltip", Singular.Misc.NothingDBNull(GetProperty(EvidenceTooltipProperty)));
			cm.Parameters.AddWithValue("@SortOrder", GetProperty(SortOrderProperty));
			cm.Parameters.AddWithValue("@QuestionnaireID", GetProperty(QuestionnaireIDProperty));
			cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));

			//only for used in updMAQuestionnaireQuestion stored proc
			if (!this.IsNew)
			{
				if (GetProperty(QuestionProperty) == GetProperty(OriginalQuestionProperty))
				{
					cm.Parameters.AddWithValue("@QuestionModified", false);
				}
				else
				{
					cm.Parameters.AddWithValue("@QuestionModified", true);
				}
			}		

			return (scm) =>
			{
				// Post Save
				if (this.IsNew)
				{
					LoadProperty(QuestionnaireQuestionIDProperty, scm.Parameters["@QuestionnaireQuestionID"].Value);
				}
			};
		}

		protected override void SaveChildren()
		{
			UpdateChild(GetProperty(MAQuestionnaireQuestionTypeListProperty));
			UpdateChild(GetProperty(QuestionnaireQuestionLegalDesignationListProperty));
			UpdateChild(GetProperty(QuestionnaireQuestionManagementSphereListProperty));
		}

		protected override void SetupDeleteCommand(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@QuestionnaireQuestionID", GetProperty(QuestionnaireQuestionIDProperty));
		}

		#endregion

	}

}