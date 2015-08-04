using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem
{
	public int ID { get; private set; }
	public bool IsEnable { get; private set; }
	public Property BattleProp { get; private set; }
	public BuffControl BuffCtrl { get; private set; }
	private BattleSystem()
	{
		ID = ++m_idCount;
		IsEnable = true;
		BattleProp = new Property(this);
		BuffCtrl = new BuffControl(this);
	}
	public void FixedUpdate()
	{
		BuffCtrl.FixedUpdate();
	}
	public static BattleSystem Create()
	{
		BattleSystem system = new BattleSystem();
		m_systemDict.Add(system.ID, system);
		return system;
	}
	public static void Release(BattleSystem system)
	{
		m_systemDict.Remove(system.ID);
	}
	public static BattleSystem Lookup(int id)
	{
		BattleSystem system = null;
		if (m_systemDict.TryGetValue(id, out system))
		{
			return system;
		}
		else
		{
			return null;
		}
	}
	private static Dictionary<int, BattleSystem> m_systemDict = new Dictionary<int, BattleSystem>();
	private static int m_idCount = 0;
}
