using UnityEngine;
using System.Collections;

public class KeepInScreen : MonoBehaviour {

	protected Vector2 min{
		get{
			return Manager.instance.minPosition.transform.position;
		}
	}
	protected Vector2 max
	{
		get
		{
			return Manager.instance.maxPosition.transform.position;
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	protected virtual void FixedUpdate()
	{
		if (Died())
		{
			ReSpawn();
		}
		
	}
	
	protected bool Died()
	{
		return transform.position.x < min.x || transform.position.y < min.y || transform.position.x>max.x || transform.position.y>max.y;
	}
	
	protected virtual void ReSpawn()
	{
		transform.position = new Vector3(Random.value * max.x, Random.value * max.y, 0);
		
		
	}
	
	
}
