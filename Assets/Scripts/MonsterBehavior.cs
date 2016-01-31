using UnityEngine;
using System.Collections;

using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class MonsterBehavior : MonoBehaviour 
{
	private PlatformerCharacter2D m_Character;
	private bool m_Jump;
	private Animator m_Anim;            // Reference to the player's animator component.

	private bool _stunned = false;

	Transform _player = null;

	float _currentDirection = -1;

	public void Kill()
	{
		// kill Monster
		m_Anim.SetBool("Dead", true);

		_stunned = true;

		// stun monster and then turn red, countdown to kill
		StartCoroutine(DieAfter(1.5f));
	}

	IEnumerator DieAfter( float time )
	{
		yield return new WaitForSeconds( time );
		Destroy( this.gameObject );
	}

	public void Stun()
	{
	}

	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
	}

	private void Start()
	{
		_player = GameObject.FindWithTag("Player").GetComponent<Transform>();

		m_Anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if ( Input.GetKeyDown(KeyCode.U))
		{
			Kill();
		}
	}

	private void FixedUpdate()
	{
	    // Read the inputs.
	    // Pass all parameters to the character control script.
	    if ( ! _stunned )
	    {
	    	m_Character.Move(_currentDirection, false, false);
	    }
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		if ( _stunned ) return;
		
		// Kill Player
		if ( collision.collider.CompareTag("Player") )
		{
			PlayerDeath player = collision.gameObject.GetComponent<PlayerDeath>();
			player.Kill();
		}
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.CompareTag("MonsterBoundary"))
		{
			_currentDirection = -_currentDirection;
		}
	}
}