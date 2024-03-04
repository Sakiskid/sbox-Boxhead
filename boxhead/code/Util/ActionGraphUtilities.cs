namespace Sandbox.Util
{
	public class ActionGraphUtilities
	{
		/// <summary>
		/// Returns positiveValue or negativeValue based on incoming bool
		/// </summary>
		[ActionGraphNode( "sakiskid.acutils.boolToInt" ), Pure]
		[Title( "Bool To Int" ), Group( "Sakiskid Utilities" ), Icon( "exposure_plus_1" )]
		public static int GetBoolToInt( bool boolean, int positiveValue = 1, int NegativeValue = 0)
		{
			if ( boolean == true ) return positiveValue;
			else return NegativeValue;
		}
	}
}
