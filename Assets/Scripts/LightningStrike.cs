using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class LightningStrike : MonoBehaviour 
{
	[SerializeField] private float _visibleTime = 1.0f;
	[SerializeField] private float _speed = 2f;

	[SerializeField] private FadeOut _flashFadeOut;

	void Start()
	{
		_flashFadeOut.StartFadeOut();
		StartCoroutine(VisibleCountDown());
	}

	IEnumerator VisibleCountDown()
	{
		yield return new WaitForSeconds( _visibleTime );
		StartFadeOut();
	}

	public void StartFadeOut()
	{
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		StartCoroutine( FadeOutCoroutine( sprite ) );
	}

	IEnumerator FadeOutCoroutine(SpriteRenderer sprite)
	{
		sprite.color = Color.white;
		Color blank_color = sprite.color;
		blank_color.a = 0.0f;
		while ( sprite.color.a > 0.05f )
		{
			sprite.color = Color.Lerp( sprite.color, blank_color, Time.deltaTime * _speed);
			yield return null;
		}
		sprite.color = blank_color;
	}
}
