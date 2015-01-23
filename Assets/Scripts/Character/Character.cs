using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public Transform minPosition, maxPosition;
    private Vector2 min{
     get{
        return minPosition.transform.position;
     }
    }
    private Vector2 max
    {
        get
        {
            return maxPosition.transform.position;
        }
    }
    public int score;
	// Use this for initialization
	void Start () {
	
	}
    void FixedUpdate()
    {
        if (Died())
        {
            ReSpawn();
        }
    }

    private bool Died()
    {
        return transform.position.x < min.x || transform.position.y < min.y;
    }

    void ReSpawn()
    {
        transform.position = new Vector3(Random.value * max.x, Random.value * max.y, 0);
        score -= 10;

    }
	
	
}
