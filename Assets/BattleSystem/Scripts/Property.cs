using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Property
{
	public BattleSystem BattleSys { get; private set; }
	public Property(BattleSystem battleSys)
	{
		BattleSys = battleSys;
	}
	public void Register<T>(string name)
	{
		Register<T>(name, default(T), string.Empty);
	}
	public void Register<T>(string name, T defaultValue)
	{
		Register<T>(name, defaultValue, string.Empty);
	}
	public void Register<T>(string name, T defaultValue, string description)
	{
		PropertyValue<T> prop = new PropertyValue<T>();
		prop.Value = defaultValue;
		m_propDict.Add(name, prop);
		m_descDict.Add(name, description);
	}
	public bool SetValue<T>(string name, T value)
	{
		IPropertyBase prop = null;
		if (m_propDict.TryGetValue(name, out prop))
		{
			var realProp = prop as PropertyValue<T>;
			if (null != realProp)
			{
				realProp.Value = value;
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}
	public T GetValue<T>(string name)
	{
		IPropertyBase prop = null;
		if (m_propDict.TryGetValue(name, out prop))
		{
			var realProp = prop as PropertyValue<T>;
			if (null != realProp)
			{
				return realProp.Value;
			}
			else
			{
				return default(T);
			}
		}
		else
		{
			return default(T);
		}
	}
	public string GetValueFormat(string name, string format)
	{
		IPropertyBase prop = null;
		if (m_propDict.TryGetValue(name, out prop))
		{
			return prop.ToFormat(format);
		}
		else
		{
			return string.Empty;
		}
	}
	private Dictionary<string, IPropertyBase> m_propDict = new Dictionary<string, IPropertyBase>();
	private static Dictionary<string, string> m_descDict = new Dictionary<string, string>();
}

public class IPropertyBase
{
	public virtual string ToFormat(string format) { return string.Empty; }
}

public class PropertyValue<T> : IPropertyBase
{
	public override string ToFormat(string format)
	{
		return string.Format(format, Value);
	}
	public T Value { get; set; }
}
