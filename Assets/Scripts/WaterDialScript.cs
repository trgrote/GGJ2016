using UnityEngine;
using System.Collections;

public class WaterDialScript : MonoBehaviour 
{

	[SerializeField] MonsterBehavior[] _monsters;
	[SerializeField] Transform _water;

	public void OnWaterTrigger()
	{
		foreach ( var mons in _monsters )
		{
			mons.Kill();
		}

	}

	IEnumerator WaterRise()
	{
		yield return null;
	}

	IEnumerator WaterSubSide()
	{
		yield return null;
	}
}
