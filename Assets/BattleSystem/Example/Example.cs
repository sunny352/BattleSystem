using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
	void Awake()
	{
		ResultFactory.Register<SkillResult>();
		ResultFactory.Register<DamageResult>();
		ResultFactory.Register<DeadResult>();

		BuffFactroy.Register<PropBuffElement>();
	}
	void Start()
	{
		IResultBase skillResult = ResultFactory.Create("SkillResult");
		skillResult.Init(1, 2, 3, 4, 5, 6);
	}

	void Update()
	{

	}
}
