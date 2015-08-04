using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BuffControl
{
	public Action<Buff> onBuffAdded;
	public Action<Buff> onBuffRemoved;
	public BattleSystem BattleSys { get; private set; }
	public BuffControl(BattleSystem battleSys)
	{
		BattleSys = battleSys;
	}
	public virtual Buff Add()
	{
		if (null != onBuffAdded)
		{
			onBuffAdded(null);
		}
		return null;
	}
	public virtual void Remove(int id)
	{
		m_list.ForEach(delegate(Buff buff) { if (buff.ID == id) { buff.IsEnable = false; } });
	}
	public virtual void FixedUpdate()
	{
		if (0 == m_list.Count)
		{
			return;
		}
		bool isNeedRemove = false;
		m_list.ForEach(delegate(Buff buff)
		{
			if (buff.IsEnable)
			{
				buff.FixedUpdate(this);
			}
			if (!buff.IsEnable)
			{
				buff.OnExit(this);
				if (null != onBuffRemoved)
				{
					onBuffRemoved(buff);
				}
				isNeedRemove = true;
			}
		});
		if (isNeedRemove)
		{
			m_list.RemoveAll(item => item.IsEnable);
		}
	}
	public virtual void OnSelfResult(IResultBase result, ResultControl control)
	{
		m_list.ForEach(delegate(Buff buff)
		{
			if (buff.IsEnable)
			{
				buff.OnSelfResult(result, control, this);
			}
		});
	}
	public virtual void OnOtherResult(IResultBase result, ResultControl control)
	{
		m_list.ForEach(delegate(Buff buff)
		{
			if (buff.IsEnable)
			{
				buff.OnOtherResult(result, control, this);
			}
		});
	}
	private List<Buff> m_list = new List<Buff>();
}
