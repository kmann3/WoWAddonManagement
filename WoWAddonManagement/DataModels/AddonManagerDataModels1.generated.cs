//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : AddonManagement
	/// Data Source    : AddonManagement
	/// Server Version : 3.14.2
	/// </summary>
	public partial class AddonManagementDB : LinqToDB.Data.DataConnection
	{
		public AddonManagementDB()
		{
			InitDataContext();
		}

		public AddonManagementDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}
}