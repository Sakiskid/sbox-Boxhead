namespace Sandbox.Util
{
	public class ActionGraphUtilities
	{
		/// <summary>
		/// Returns positiveValue or negativeValue based on incoming bool
		/// </summary>
		[ActionGraphNode( "sakiskid.acutils.boolToInt" )]
		[Title( "Bool To Int" ), Group( "Sakiskid Utilities" ), Icon( "exposure_plus_1" )]
		public static int BoolToInt( bool boolean, int positiveValue = 1, int NegativeValue = 0)
		{
			if ( boolean == true ) return positiveValue;
			else return NegativeValue;
		}
		
		/// <summary>
		/// Returns positiveValue or negativeValue based on incoming signal. NOT WORKING
		/// </summary>
		[ActionGraphNode( "sakiskid.acutils.boolToInt" ), Pure]
		[Title( "Signal To Int" ), Group( "Sakiskid Utilities" ), Icon( "exposure_plus_1" )]
		public static int SignalToInt( object node, int positiveValue = 1, int NegativeValue = 0)
		{
			// if ( boolean == true ) return positiveValue;
			// else return NegativeValue;
			return 1;
		}
	}
}
