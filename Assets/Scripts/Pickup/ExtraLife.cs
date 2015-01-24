using UnityEngine;
using System.Collections;

public class ExtraLife : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			
			coll.gameObject.GetComponent<Character>().Lifes ++;
			Destroy(this.gameObject);
		}
	}
}
