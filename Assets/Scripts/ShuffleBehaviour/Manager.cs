using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

   
    List<GameObject> chunks1;
    private float screenWidth;
    private float screenHeight;
	// Use this for initialization
    void Awake()
    {
        Vector2 topRightCorner = new Vector2(1, 1); //viewport space places (1,1) at the top-right corner
        Vector2 edgeVector = camera.ViewportToWorldPoint(topRightCorner);
        screenHeight = edgeVector.y * 2;
        screenWidth = edgeVector.x * 2;
        chunks1 = new List<GameObject>();
    }
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShuffleChunks1( )
    {
        float x;
        float y;
        foreach(GameObject chunk in chunks1)
        {
            x = Random.Range(-screenWidth, screenWidth);
            y = Random.Range(-screenHeight, screenHeight);
        }
        
    }
}
