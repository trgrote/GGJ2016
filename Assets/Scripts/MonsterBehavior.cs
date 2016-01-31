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

		// stun monster and then turn red, countdown to kill
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
	    m_Character.Move(_currentDirection, false, false);
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.CompareTag("MonsterBoundary"))
		{
			_currentDirection = -_currentDirection;
		}
	}
}