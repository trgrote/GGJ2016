using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatueSpawner : MonoBehaviour 
{
	[SerializeField] private GameObject _statueLove;
	[SerializeField] private GameObject _statueWar;
	[SerializeField] private GameObject _statueBalance;
	[SerializeField] private GameObject _statueAction;

	// Use this for initialization
	void Start () 
	{
		// Enable statue based off character karma
		Dictionary< KarmaTypes, int > karmaMap = new Dictionary< KarmaTypes, int >();

		karmaMap[ KarmaTypes.Nature ] = KarmaValues.Nature;
		karmaMap[ KarmaTypes.Civilzation ] = KarmaValues.Civilzation;
		karmaMap[ KarmaTypes.Good ] = KarmaValues.Good;
		karmaMap[ KarmaTypes.Evil ] = KarmaValues.Evil;
		karmaMap[ KarmaTypes.Active ] = KarmaValues.Active;

		KarmaTypes max = KarmaTypes.Civilzation;
		int current_max = -1000;

		KarmaTypes min = KarmaTypes.Civilzation;
		int current_min = 1000;

		foreach ( var entry in karmaMap )
		{
			if ( entry.Value > current_max )
			{
				current_max = entry.Value;
				max = entry.Key;
			}

			if ( entry.Value < current_min )
			{
				current_min = entry.Value;
				min = entry.Key;
			}
		}

		Debug.Log("Max is " + max );
		Debug.Log("Min is " + min );

		if ( min == KarmaTypes.Active )
		{
			// Special case for inactive players
			_statueBalance.SetActive(true);
		}
		else
		{
			switch ( max )
			{
				case KarmaTypes.Nature:
					_statueLove.SetActive(true);
					break;
				case KarmaTypes.Civilzation:
					_statueWar.SetActive(true);
					break;
				case KarmaTypes.Good:
					_statueLove.SetActive(true);
					break;
				case KarmaTypes.Evil:
					_statueWar.SetActive(true);
					break;
				case KarmaTypes.Active:
					_statueAction.SetActive(true);   /// this is the weirdest one
					break;
			}
		}
	}
}
