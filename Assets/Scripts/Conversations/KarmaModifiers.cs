using UnityEngine;
using System.Collections;

public class KarmaModifiers : MonoBehaviour 
{
	public void Nature()
	{
		KarmaValues.Nature++;
	}
	public void Civilzation()
	{
		KarmaValues.Civilzation++;
	}
	public void Good()
	{
		KarmaValues.Good++;
	}
	public void Evil()
	{
		KarmaValues.Evil++;
	}
	public void Active()
	{
		KarmaValues.Active++;
	}

	public void ReduceActive()
	{
		KarmaValues.Active--;
	}
}
