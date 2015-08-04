using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor
{
	public int ID { get; private set; }
	public bool IsEnable { get; set; }
	public BattleSystem BattleSys { get; private set; }
	public Actor(int id)
	{
		ID = id;
		BattleSys = BattleSystem.Create();
	}
	public void FixedUpdate()
	{
		BattleSys.FixedUpdate();
	}
	public void Release()
	{
		BattleSystem.Release(BattleSys);
		BattleSys = null;
	}
}

public class ActorManager
{
	public static int CreateActor()
	{
		Actor actor = new Actor(++m_idIndex);
		m_actorList.Add(actor);
		return actor.ID;
	}
	public static void ReleaseActor(int id)
	{
		Actor actor = m_actorList.Find(item => item.ID == id);
		if (null != actor)
		{
			actor.IsEnable = false; 
		}
	}
	public static void FixedUpdate()
	{
		m_actorList.ForEach(delegate(Actor actor)
		{
			if (actor.IsEnable)
			{
				actor.FixedUpdate();
			}
		});
		m_actorList.RemoveAll(actor => !actor.IsEnable);
	}
	private static List<Actor> m_actorList = new List<Actor>();
	private static int m_idIndex = 0;
}