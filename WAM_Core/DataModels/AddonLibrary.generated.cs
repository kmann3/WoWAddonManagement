//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace WAM_Core.DataModels
{
	/// <summary>
	/// Database       : AddonLibrary
	/// Data Source    : AddonLibrary
	/// Server Version : 3.19.3
	/// </summary>
	public partial class AddonLibraryDB : LinqToDB.Data.DataConnection
	{
		public ITable<Addon> Addons { get { return this.GetTable<Addon>(); } }

		public AddonLibraryDB()
		{
			InitDataContext();
		}

		public AddonLibraryDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}

	[Table("Addons")]
	public partial class Addon
	{
		[PrimaryKey, NotNull    ] public string AddonGuid { get; set; } // text(max)
		[Column,        Nullable] public string AddonName { get; set; } // text(max)
		[Column,        Nullable] public string GitUrl    { get; set; } // text(max)
	}

	public static partial class TableExtensions
	{
		public static Addon Find(this ITable<Addon> table, string AddonGuid)
		{
			return table.FirstOrDefault(t =>
				t.AddonGuid == AddonGuid);
		}
	}
}
