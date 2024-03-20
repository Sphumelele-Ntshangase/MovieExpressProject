﻿// Generated 11 Sep 2018 15:50 - Singular Systems Object Generator Version 2.2.694
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


namespace METTLib.Reports
{
	[Serializable]
	public class ReportInterventionNextStep
	 : SingularBusinessBase<ReportInterventionNextStep>
	{
		#region " Properties and Methods "

		#region " Properties "

		public static PropertyInfo<int> QuestionnaireAnswerResultIDProperty = RegisterProperty<int>(c => c.QuestionnaireAnswerResultID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		[Display(AutoGenerateField = false), Key]
		public int QuestionnaireAnswerResultID
		{
			get { return GetProperty(QuestionnaireAnswerResultIDProperty); }
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
		StringLength(500, ErrorMessage = "Indicator Detail Name cannot be more than 500 characters")]
		public String IndicatorDetailName
		{
			get { return GetProperty(IndicatorDetailNameProperty); }
			set { SetProperty(IndicatorDetailNameProperty, value); }
		}

		public static PropertyInfo<String> NextStepsProperty = RegisterProperty<String>(c => c.NextSteps, "Next Steps", "");
		/// <summary>
		/// Gets and sets the Next Steps value
		/// </summary>
		[Display(Name = "Next Steps", Description = ""),
		StringLength(500, ErrorMessage = "Next Steps cannot be more than 500 characters")]
		public String NextSteps
		{
			get { return GetProperty(NextStepsProperty); }
			set { SetProperty(NextStepsProperty, value); }
		}

		#endregion

		#region " Methods "

		protected override object GetIdValue()
		{
			return GetProperty(QuestionnaireAnswerResultIDProperty);
		}

		public override string ToString()
		{
			if (this.IndicatorDetailName.Length == 0)
			{
				if (this.IsNew)
				{
					return String.Format("New {0}", "Report Intervention Next Step");
				}
				else
				{
					return String.Format("Blank {0}", "Report Intervention Next Step");
				}
			}
			else
			{
				return this.IndicatorDetailName;
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
			// Set any variables here, not in the constructor or NewReportInterventionNextStep() method.
		}

		public static ReportInterventionNextStep NewReportInterventionNextStep()
		{
			return DataPortal.CreateChild<ReportInterventionNextStep>();
		}

		public ReportInterventionNextStep()
		{
			MarkAsChild();
		}

		internal static ReportInterventionNextStep GetReportInterventionNextStep(SafeDataReader dr)
		{
			var r = new ReportInterventionNextStep();
			r.Fetch(dr);
			return r;
		}

		protected void Fetch(SafeDataReader sdr)
		{
			using (BypassPropertyChecks)
			{
				int i = 0;
				LoadProperty(QuestionnaireAnswerResultIDProperty, sdr.GetInt32(i++));
				LoadProperty(QuestionnaireGroupIDProperty, sdr.GetInt32(i++));
				LoadProperty(IndicatorDetailIDProperty, sdr.GetInt32(i++));
				LoadProperty(IndicatorDetailNameProperty, sdr.GetString(i++));
				LoadProperty(NextStepsProperty, sdr.GetString(i++));
			}

			MarkAsChild();
			MarkOld();
			BusinessRules.CheckRules();
		}

		protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
		{
			AddPrimaryKeyParam(cm, QuestionnaireAnswerResultIDProperty);

			cm.Parameters.AddWithValue("@QuestionnaireGroupID", GetProperty(QuestionnaireGroupIDProperty));
			cm.Parameters.AddWithValue("@IndicatorDetailID", GetProperty(IndicatorDetailIDProperty));
			cm.Parameters.AddWithValue("@IndicatorDetailName", GetProperty(IndicatorDetailNameProperty));
			cm.Parameters.AddWithValue("@NextSteps", GetProperty(NextStepsProperty));

			return (scm) =>
			{
	// Post Save
	if (this.IsNew)
				{
					LoadProperty(QuestionnaireAnswerResultIDProperty, scm.Parameters["@QuestionnaireAnswerResultID"].Value);
				}
			};
		}

		protected override void SaveChildren()
		{
			// No Children
		}

		protected override void SetupDeleteCommand(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@QuestionnaireAnswerResultID", GetProperty(QuestionnaireAnswerResultIDProperty));
		}

		#endregion

	}

}