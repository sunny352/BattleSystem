using UnityEngine;
using System.Collections;

public class IResultBase
{
	public int SourceID { get; private set; }
	public int TargetID { get; private set; }
	public bool IsEnable { get; set; }
	public void Init(int sourceID, int targetID, params object[] paramList)
	{
		SourceID = sourceID;
		TargetID = targetID;
		OnInit(paramList);
	}
	protected virtual void OnInit(params object[] paramList) { }
	public virtual void PreProcess(ResultControl control) { }
	public virtual void Execute(ResultControl control) { }
}
