using UnityEngine;
using System.Collections;


// Attach self to camera, fade to 100 alpha
[RequireComponent(typeof(SpriteRenderer))]
public class FadeToBlack : MonoBehaviour 
{
	SpriteRenderer _sprite;

	float _speed = 2.0f;
	// Use this for initialization
	void Start () 
	{
		_sprite = GetComponent<SpriteRenderer>();

		GetComponent<Transform>().SetParent( Camera.main.GetComponent<Transform>() );

		StartCoroutine(FadeToBlackProcess());
	}

	IEnumerator FadeToBlackProcess()
	{
		Color color = _sprite.color;
		color.a = 0;
		_sprite.color = color;

		Color target_color = color;
		target_color.a = 1;

		while ( _sprite.color.a < 0.95f )
		{
			_sprite.color = Color.Lerp( _sprite.color, target_color, Time.deltaTime * _speed);
			yield return null;
		}
		_sprite.color = target_color;
	}
}
