using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour 
{
	private Animator m_Anim;            // Reference to the player's animator component.

	void Start()
	{
		m_Anim = GetComponent<Animator>();
	}

	bool _dying = false;

	public void Kill()
	{
		if ( _dying ) return;


		// kill Monster
		m_Anim.SetBool("Dead", true);

		// stun monster and then turn red, countdown to kill
		StartCoroutine(DieAfter(1.5f));

		_dying = true;
	}

	IEnumerator DieAfter( float time )
	{
		yield return new WaitForSeconds( time );
		// Destroy( this.gameObject );
	}
}
