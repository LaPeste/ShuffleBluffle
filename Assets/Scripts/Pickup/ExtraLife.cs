using UnityEngine;
using System.Collections;

public class ExtraLife : MonoBehaviour {
	public AudioClip audio;
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			
			coll.gameObject.GetComponent<Character>().Lifes ++;
			if(audio!=null)AudioSource.PlayClipAtPoint(audio, Vector3.zero);
			Destroy(this.gameObject);
		}
	}
}
