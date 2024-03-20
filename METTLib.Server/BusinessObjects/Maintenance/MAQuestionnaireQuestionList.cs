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


namespace METTLib.Maintenance
{
	[Serializable]
	public class MAQuestionnaireQuestionList
	 : METTBusinessListBase<MAQuestionnaireQuestionList, MAQuestionnaireQuestion>
	{
		#region " Business Methods "

		public MAQuestionnaireQuestion GetItem(int QuestionnaireQuestionID)
		{
			foreach (MAQuestionnaireQuestion child in this)
			{
				if (child.QuestionnaireQuestionID == QuestionnaireQuestionID)
				{
					return child;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "Questionnaire Questions";
		}

		public MAQuestionnaireQuestionType GetMAQuestionnaireQuestionType(int QuestionnaireQuestionTypeID)
		{
			MAQuestionnaireQuestionType obj = null;
			foreach (MAQuestionnaireQuestion parent in this)
			{
				obj = parent.MAQuestionnaireQuestionTypeList.GetItem(QuestionnaireQuestionTypeID);
				if (obj != null)
				{
					return obj;
				}
			}
			return null;
		}

		#endregion

		#region " Data Access "

		[Serializable]
		public class Criteria
			: CriteriaBase<Criteria>
		{

			public int GroupID { get; set; }
			public int QuestionnaireID { get; set; }

			public int? QuestionnaireQuestionID { get; set; }

			public Criteria(int? questionnaireQuestionID)
			{
				QuestionnaireQuestionID = questionnaireQuestionID;
			}

			public Criteria(int groupID, int questionnaireID)
			{
				GroupID = groupID;
				QuestionnaireID = questionnaireID;
			}

			public Criteria()
			{
			}

		}

		public static MAQuestionnaireQuestionList NewMAQuestionnaireQuestionList(int groupID, int questionnaireID)
		{
			return DataPortal.Fetch<MAQuestionnaireQuestionList>(new Criteria(groupID, questionnaireID));
		}

		public static MAQuestionnaireQuestionList NewMAQuestionnaireQuestionList()
		{
			return new MAQuestionnaireQuestionList();
		}

		public MAQuestionnaireQuestionList()
		{
			// must have parameter-less constructor
		}


		public static MAQuestionnaireQuestionList GetMAQuestionnaireQuestionList(int? QuestionnaireQuestionID)
		{
			return DataPortal.Fetch<MAQuestionnaireQuestionList>(new Criteria(QuestionnaireQuestionID));
		}


		public static MAQuestionnaireQuestionList GetMAQuestionnaireQuestionList()
		{
			return DataPortal.Fetch<MAQuestionnaireQuestionList>(new Criteria());
		}

		protected void Fetch(SafeDataReader sdr)
		{
			this.RaiseListChangedEvents = false;
			while (sdr.Read())
			{
				this.Add(MAQuestionnaireQuestion.GetMAQuestionnaireQuestion(sdr));
			}
			this.RaiseListChangedEvents = true;

			MAQuestionnaireQuestion parent = null;
			if (sdr.NextResult())
			{
				while (sdr.Read())
				{
					if (parent == null || parent.QuestionnaireQuestionID != sdr.GetInt32(1))
					{
						parent = this.GetItem(sdr.GetInt32(1));
					}
					parent.MAQuestionnaireQuestionTypeList.RaiseListChangedEvents = false;
					parent.MAQuestionnaireQuestionTypeList.Add(MAQuestionnaireQuestionType.GetMAQuestionnaireQuestionType(sdr));
					parent.MAQuestionnaireQuestionTypeList.RaiseListChangedEvents = true;
				}

			}
			if (sdr.NextResult())
			{
				while (sdr.Read())
				{
					if (parent == null || parent.QuestionnaireQuestionID != sdr.GetInt32(1))
					{
						parent = this.GetItem(sdr.GetInt32(1));
					}
					parent.QuestionnaireQuestionLegalDesignationList.RaiseListChangedEvents = false;
					parent.QuestionnaireQuestionLegalDesignationList.Add(QuestionnaireQuestionLegalDesignation.GetQuestionnaireQuestionLegalDesignation(sdr));
					parent.QuestionnaireQuestionLegalDesignationList.RaiseListChangedEvents = true;
				}
			}

			if (sdr.NextResult())
			{
				while (sdr.Read())
				{
					if (parent == null || parent.QuestionnaireQuestionID != sdr.GetInt32(1))
					{
						parent = this.GetItem(sdr.GetInt32(1));
					}
					parent.QuestionnaireQuestionManagementSphereList.RaiseListChangedEvents = false;
					parent.QuestionnaireQuestionManagementSphereList.Add(QuestionnaireQuestionManagementSphere.GetQuestionnaireQuestionManagementSphere(sdr));
					parent.QuestionnaireQuestionManagementSphereList.RaiseListChangedEvents = true;
				}
			}



			foreach (MAQuestionnaireQuestion child in this)
			{
				child.CheckRules();
				foreach (MAQuestionnaireQuestionType MAQuestionnaireQuestionType in child.MAQuestionnaireQuestionTypeList)
				{
					MAQuestionnaireQuestionType.CheckRules();
				}
			}
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
						cm.CommandText = "GetProcs.getMAQuestionnaireQuestionList";

						cm.Parameters.AddWithValue("@questionnairegroupID", Misc.ZeroNothingDBNull(crit.GroupID));
						cm.Parameters.AddWithValue("@QuestionnaireID", Misc.ZeroNothingDBNull(crit.QuestionnaireID));
						cm.Parameters.AddWithValue("@QuestionnaireQuestionID", Misc.ZeroNothingDBNull(crit.QuestionnaireQuestionID));

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