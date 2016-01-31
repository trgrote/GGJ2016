using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BridgeBreak : MonoBehaviour 
{
	[SerializeField] GameObject _lightningStrike;
	[SerializeField] GameObject _groundBlocks;
	[SerializeField] GameObject _fadeToBlackPrefab;

	bool _processBegin = false;

	[SerializeField] private bool _transitionAfterFade = false;

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( _processBegin ) return;

		if ( other.CompareTag("Player"))
		{
			_lightningStrike.SetActive(true);   // turn on lightning
			_groundBlocks.SetActive(false);     // disable ground

			// Begin fade to black after 0.2 seconds
			StartCoroutine( WaitToFade() );
			StartCoroutine( WaitToSwitch() );

			_processBegin = true;
		}
	}

	IEnumerator WaitToFade()
	{
		yield return new WaitForSeconds( 0.5f );

		Instantiate( _fadeToBlackPrefab );
	}

	IEnumerator WaitToSwitch()
	{
		yield return new WaitForSeconds( 2f );

		// Change Level
		if ( _transitionAfterFade ) 
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
