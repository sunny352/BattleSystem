using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BuffFactroy : TFactroy<IBuffElement, string>
{
	public static void Register<T>() where T : IBuffElement, new()
	{
		Register<T>(typeof(T).ToString());
	}
}
public class ResultFactory : TFactroy<IResultBase, string>
{
	public static void Register<T>() where T : IResultBase, new()
	{
		Register<T>(typeof(T).ToString());
	}
}

public class TFactroy<T, U>
{
	public static T Create(U typeID)
	{
		Func<T> func = null;
		if (m_factroyDict.TryGetValue(typeID, out func))
		{
			return func();
		}
		else
		{
			return default(T);
		}
	}
	public static void Register<R>(U typeID) where R : T, new()
	{
		m_factroyDict.Add(typeID, delegate() { return new R(); });
	}
	private static Dictionary<U, Func<T>> m_factroyDict = new Dictionary<U, Func<T>>();
}