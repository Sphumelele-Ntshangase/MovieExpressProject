﻿

// Generated 17 Jul 2018 13:15 - Singular Systems Object Generator Version 2.2.694
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
	public class ROQuestionnaireAnswerScoreAuditorList
	 : METTReadOnlyListBase<ROQuestionnaireAnswerScoreAuditorList, ROQuestionnaireAnswerScoreAuditor>
	{
		#region " Business Methods "

		public ROQuestionnaireAnswerScoreAuditor GetItem(int QuestionnaireAnswerScoreID)
		{
			foreach (ROQuestionnaireAnswerScoreAuditor child in this)
			{
				if (child.QuestionnaireAnswerScoreID == QuestionnaireAnswerScoreID)
				{
					return child;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "Questionnaire Answer Scores";
		}

		#endregion

		#region " Data Access "

		[Serializable]
		public class Criteria
			: CriteriaBase<Criteria>
		{

			public int? QuestionnaireAnswerSetID = null;
			public Criteria(int? QuestionnaireAnswerSetID)
			{
				this.QuestionnaireAnswerSetID = QuestionnaireAnswerSetID;
			}

			public Criteria()
			{
			}

		}

		public static ROQuestionnaireAnswerScoreAuditorList NewROQuestionnaireAnswerScoreAuditorList()
		{
			return new ROQuestionnaireAnswerScoreAuditorList();
		}

		public ROQuestionnaireAnswerScoreAuditorList()
		{
			// must have parameter-less constructor
		}

		public static ROQuestionnaireAnswerScoreAuditorList GetROQuestionnaireAnswerScoreAuditorList()
		{
			return DataPortal.Fetch<ROQuestionnaireAnswerScoreAuditorList>(new Criteria());
		}

		public static ROQuestionnaireAnswerScoreAuditorList GetROQuestionnaireAnswerScoreAuditorList(int? QuestionnaireAnswerSetID)
		{
			return DataPortal.Fetch<ROQuestionnaireAnswerScoreAuditorList>(new Criteria(QuestionnaireAnswerSetID));
		}


		protected void Fetch(SafeDataReader sdr)
		{
			this.RaiseListChangedEvents = false;
			this.IsReadOnly = false;
			while (sdr.Read())
			{
				this.Add(ROQuestionnaireAnswerScoreAuditor.GetROQuestionnaireAnswerScoreAuditor(sdr));
			}
			this.IsReadOnly = true;
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
						cm.CommandText = "GetProcs.getROQuestionnaireAnswerScoreAuditorList";

						cm.Parameters.AddWithValue("@QuestionnaireAnswerSetID", Singular.Misc.NothingDBNull(crit.QuestionnaireAnswerSetID));

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