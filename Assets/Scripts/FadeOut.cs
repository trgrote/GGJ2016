using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeOut : MonoBehaviour 
{
	[SerializeField] private float _speed = 2f;

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
