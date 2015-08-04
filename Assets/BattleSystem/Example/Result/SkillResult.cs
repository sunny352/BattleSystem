using UnityEngine;
using System.Collections;

public class SkillResult : IResultBase
{
	protected override void OnInit(params object[] paramList)
	{
		Debug.LogFormat("paramList length is {0}", paramList.Length);
	}

	public override void PreProcess(ResultControl control)
	{
		
	}

	public override void Execute(ResultControl control)
	{
		
	}
}
