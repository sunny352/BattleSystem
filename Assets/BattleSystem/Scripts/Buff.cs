using UnityEngine;
using System.Collections;
using System;

public class Buff
{
	//计时结束
	public Action<Buff> onTimerFinished;
	//计时变化
	public Action<Buff> onTimerChanged;
	//Buff定时生效
	public Action<Buff> onBuffOperation;
	public int ID { get; private set; }
	public bool IsEnable { get; set; }
	private IBuffElement[] m_list;
	public void Init(int id)
	{
		ID = id;
		m_list = new IBuffElement[1];
	}
	public void OnEnter(BuffControl buffControl)
	{
		for (int index = 0; index < m_list.Length; ++index)
		{
			m_list[index].OnEnter(buffControl, this);
		}
	}
	public void OnExit(BuffControl buffControl)
	{
		for (int index = 0; index < m_list.Length; ++index)
		{
			m_list[index].OnExit(buffControl, this);
		}
		onTimerFinished = null;
		onTimerChanged = null;
		onBuffOperation = null;
	}
	public void FixedUpdate(BuffControl buffControl)
	{
		for (int index = 0; index < m_list.Length; ++index)
		{
			m_list[index].OnFixedUpdate(buffControl, this);
		}
		if (null != onTimerChanged)
		{
			onTimerChanged(this);
		}
	}
	public void OnSelfResult(IResultBase result, ResultControl resultControl, BuffControl buffControl)
	{
		for (int index = 0; index < m_list.Length; ++index)
		{
			m_list[index].OnSelfResult(result, resultControl, buffControl, this);
		}
	}
	public void OnOtherResult(IResultBase result, ResultControl control, BuffControl buffControl)
	{
		for (int index = 0; index < m_list.Length; ++index)
		{
			m_list[index].OnOtherResult(result, control, buffControl, this);
		}
	}
}
