using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public GameObject chunkParent;
    //public Transform debugMin, debugMax;
    public float speedLearp;
    public GameObject[] chunks1;
    private float screenWidth;
    private float screenHeight;
	// Use this for initialization
    void Awake()
    {
        Vector2 topRightCorner = new Vector2(1, 1); //viewport space places (1,1) at the top-right corner
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        screenHeight = edgeVector.y;
        Debug.Log("top right corner in world coordinate = " + edgeVector);
        screenWidth = edgeVector.x;
       // debugMin.transform.position = new Vector3(-screenWidth, -screenHeight);
      //  debugMax.transform.position = new Vector3(screenWidth, screenHeight);
    }
	void Start () {
        chunks1 = new GameObject[chunkParent.transform.childCount];
	    for(int i =0 ; i<chunkParent.transform.childCount; i++)
        {
            chunks1[i] = chunkParent.transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShuffleChunks1( )
    {

        StartCoroutine(Shuffle());
        
    }
    IEnumerator Shuffle()
    {
        float x;
        float y;
        foreach (GameObject chunk in chunks1)
        {
            x = Random.Range(-screenWidth, screenWidth);
            y = Random.Range(-screenHeight, screenHeight);
            Debug.Log("x = " + x + " y = " + y);
            iTween.MoveTo(chunk, new Vector2(x, y), speedLearp);
            yield return null;
            //chunk.transform.position = new Vector2(x, y);
        }
    }
}
