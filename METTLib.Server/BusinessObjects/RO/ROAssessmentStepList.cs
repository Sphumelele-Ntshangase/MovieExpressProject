﻿// Generated 23 Jul 2018 01:44 - Singular Systems Object Generator Version 2.2.693
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
	public class ROAssessmentStepList
	 : METTReadOnlyListBase<ROAssessmentStepList, ROAssessmentStep>
	{
		#region " Business Methods "

		public ROAssessmentStep GetItem(int AssessmentStepID)
		{
			foreach (ROAssessmentStep child in this)
			{
				if (child.AssessmentStepID == AssessmentStepID)
				{
					return child;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "RO Assessmentsteps";
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

		public static ROAssessmentStepList NewROAssessmentStepList()
		{
			return new ROAssessmentStepList();
		}

		public ROAssessmentStepList()
		{
			// must have parameter-less constructor
		}

		public static ROAssessmentStepList GetROAssessmentStepList()
		{
			return DataPortal.Fetch<ROAssessmentStepList>(new Criteria());
		}

		protected void Fetch(SafeDataReader sdr)
		{
			this.RaiseListChangedEvents = false;
			this.IsReadOnly = false;
			while (sdr.Read())
			{
				this.Add(ROAssessmentStep.GetROAssessmentStep(sdr));
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
						cm.CommandText = "GetProcs.getROAssessmentStepList";
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