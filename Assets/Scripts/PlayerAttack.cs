using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public FadeOut _Flash;

	private const float _flashCountDown = 1.0f;
	private bool _canFlash = true;

	private const float _attackCountDown = 0.6f;
	private bool _canAttack = true;

	const float _attackDistance = 1.5f;

	const float _flashRadius = 7f;

	Animator anim;

 	[SerializeField] private LayerMask _hitMask;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_canFlash && Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			_Flash.StartFadeOut ();
			Flash();
			StartCoroutine(FlashCoolDown());
		}

		if ( _canAttack && Input.GetKeyDown(KeyCode.Alpha2))
		{
			Debug.Log("ATTACKING");
			Attack();
		}
	}

	IEnumerator FlashCoolDown()
	{
		_canFlash = false;
		yield return new WaitForSeconds( _flashCountDown );
		_canFlash = true;
	}

	IEnumerator AttackCoolDown()
	{
		_canAttack = false;
		yield return new WaitForSeconds( _attackCountDown );
		_canAttack = true;
	}

	void Flash()
	{
		var cast = Physics2D.CircleCast( transform.position, _flashRadius, Vector2.zero, 0, _hitMask );

		if ( cast.collider != null && cast.collider.CompareTag("Monster") )
		{
			// get monster thing and kill
			MonsterBehavior mons = cast.collider.GetComponent<MonsterBehavior>();

			if ( mons )
			{
				mons.Stun();
			}
		}
	}

	void Attack()
	{
		anim.SetBool ("Attack", true);

		// Attack in front of me
		float direction = Mathf.Sign( transform.localScale.x );

		var cast = Physics2D.Raycast( transform.position, new Vector2( direction, 0f ), _attackDistance, _hitMask );

		if ( cast.collider != null && cast.collider.CompareTag("Monster") )
		{
			// get monster thing and kill
			MonsterBehavior mons = cast.collider.GetComponent<MonsterBehavior>();

			if ( mons )
			{
				mons.Kill();
			}
		}

		_canAttack = false;
		StartCoroutine( AttackCoolDown() );
		StartCoroutine(WaitTIllAttackEnds());
	}

	IEnumerator WaitTIllAttackEnds()
	{
		yield return new WaitForSeconds( 0.5f );
		anim.SetBool ("Attack", false);
	}

	void OnDrawGizmos()
	{
		// draw attack line
		Gizmos.color = Color.red;
		Vector2 end = (Vector2) transform.position + new Vector2( Mathf.Sign( transform.localScale.x ) * _attackDistance, 0 );

		Gizmos.DrawLine( transform.position, end );

		Gizmos.color = Color.blue;

		Gizmos.DrawWireSphere( transform.position, _flashRadius);
	}
}
