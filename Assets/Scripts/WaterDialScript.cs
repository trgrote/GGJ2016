using UnityEngine;
using System.Collections;

public class WaterDialScript : MonoBehaviour 
{

	[SerializeField] MonsterBehavior[] _monsters;
	[SerializeField] Transform _water;

	Vector3 _startingPosition;
	Vector3 _highPostion;

	void Start()
	{
		_startingPosition = _water.transform.position;
		_highPostion = _startingPosition;
		_highPostion.y += 4f;
	}

	public void OnWaterTrigger()
	{
		foreach ( var mons in _monsters )
		{
			mons.Kill();

			--KarmaValues.Nature;
			++KarmaValues.Civilzation;
			++KarmaValues.Evil;
		}

		StartCoroutine(WaterRise());
	}

	const float _transitionTime = 0.5f;

	IEnumerator WaterRise()
	{
		float dist = _highPostion.y - _water.transform.position.y;
		float detla = dist / _transitionTime;  // units / time = change over time

		Debug.Log(detla);

		float elapsed_time = 0;
		while ( elapsed_time < _transitionTime )
		{
			Vector3 new_pos = _water.transform.position;
			new_pos.y += detla * Time.deltaTime;
			_water.transform.position = new_pos;

			elapsed_time += Time.deltaTime;
			yield return null;
		}

		_water.transform.position = _highPostion;

		yield return StartCoroutine(WaterSubSide());
	}

	IEnumerator WaterSubSide()
	{
		float dist = _startingPosition.y - _water.transform.position.y;
		float detla = dist / _transitionTime;  // units / time = change over time

		Debug.Log(detla);

		float elapsed_time = 0;
		while ( elapsed_time < _transitionTime )
		{
			Vector3 new_pos = _water.transform.position;
			new_pos.y += detla * Time.deltaTime;
			_water.transform.position = new_pos;

			elapsed_time += Time.deltaTime;
			yield return null;
		}

		_water.transform.position = _startingPosition;
	}
}
