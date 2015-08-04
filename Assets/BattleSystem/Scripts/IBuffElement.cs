using UnityEngine;
using System.Collections;

public class IBuffElement
{
	public virtual void OnEnter(BuffControl buffControl, Buff buff) { }
	public virtual void OnExit(BuffControl buffControl, Buff buff) { }
	public virtual void OnFixedUpdate(BuffControl buffControl, Buff buff) { }
	public virtual void OnSelfResult(IResultBase result, ResultControl resultControl, BuffControl buffControl, Buff buff) { }
	public virtual void OnOtherResult(IResultBase result, ResultControl resultControl, BuffControl buffControl, Buff buff) { }
}
