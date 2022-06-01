using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class BDA : StructuredField
	{
		private static string _abbr = "BDA";
		private static string _title = "Bar Code Data";
		private static string _desc = "The Bar Code Data structured field contains the data for a bar code object.";
		private static List<Offset> _oSets = new List<Offset>();

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		public override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		public override IReadOnlyList<Offset> Offsets => _oSets;

		public BDA(byte[] id, byte flag, ushort sequence, byte[] data) : base(id, flag, sequence, data) { }
	}
}