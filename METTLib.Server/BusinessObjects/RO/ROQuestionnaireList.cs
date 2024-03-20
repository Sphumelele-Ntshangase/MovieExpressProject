﻿// Generated 11 Jul 2018 14:07 - Singular Systems Object Generator Version 2.2.694
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
	public class ROQuestionnaireList
	 : SingularReadOnlyListBase<ROQuestionnaireList, ROQuestionnaire>
	{
		#region " Business Methods "

		public ROQuestionnaire GetItem(int QuestionnaireID)
		{
			foreach (ROQuestionnaire child in this)
			{
				if (child.QuestionnaireID == QuestionnaireID)
				{
					return child;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "Questionnaires";
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

		public static ROQuestionnaireList NewROQuestionnaireList()
		{
			return new ROQuestionnaireList();
		}

		public ROQuestionnaireList()
		{
			// must have parameter-less constructor
		}

		public static ROQuestionnaireList GetROQuestionnaireList()
		{
			return DataPortal.Fetch<ROQuestionnaireList>(new Criteria());
		}

		protected void Fetch(SafeDataReader sdr)
		{
			this.RaiseListChangedEvents = false;
			this.IsReadOnly = false;
			while (sdr.Read())
			{
				this.Add(ROQuestionnaire.GetROQuestionnaire(sdr));
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
						cm.CommandText = "GetProcs.getROQuestionnaireList";
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