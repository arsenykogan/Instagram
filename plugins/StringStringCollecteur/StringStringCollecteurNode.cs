#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "StringCollecteur", Category = "String", Help = "Basic template with one string in/out", Tags = "")]
	#endregion PluginInfo
	public class StringStringCollecteurNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultString = "")]
		ISpread<string> FInput;

		[Output("Output")]
		ISpread<string> FOutput;
		
		[Input("Clear")]
		ISpread<bool> FClear;
		
		[Output("New Strings")]
		ISpread<bool> FNewString;
		
		[Output("Number of New Strings")]
		ISpread<int> FNumberOfNewString;

		#endregion fields & pins

		public void Evaluate(int SpreadMax)
		{
			FNewString[0] = false;
			FNumberOfNewString[0] = 0;
			for (int i = 0; i < FInput.SliceCount; i++) {
				if (FOutput.IndexOf(FInput[i]) < 0) {
					FOutput.Add(FInput[i]);	
					FNewString[0] = true;
					FNumberOfNewString[0]++;
				}
			}
			
			if (FClear[0]) {
				FOutput.SliceCount = 0;
			}

		}
	}
}
