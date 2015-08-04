using UnityEngine;
using System.Collections;

public class ResultControl
{
	public void Process(IResultBase result)
	{
		result.PreProcess(this);
		BattleSystem system = BattleSystem.Lookup(result.SourceID);
		if (null != system)
		{
			system.BuffCtrl.OnSelfResult(result, this);
		}
		system = BattleSystem.Lookup(result.TargetID);
		if (null != system)
		{
			system.BuffCtrl.OnOtherResult(result, this);
		}
		if (result.IsEnable)
		{
			result.Execute(this);
		}
	}
}
