using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public static Manager instance;
    public GameObject chunkParent;
    public Transform minPosition, maxPosition;
    [Range(0,1.0f)]
    public float speedLerp;
    public GameObject[] chunks1;
    
    public Character character1,character2;
    
	public WorldMover worldMover;
    
    private float screenWidth;
    private float screenHeight;
    private int swapCount = 0;
	public enum Direction{
		up,right,down,left
	}
	public Direction direction;
	public ExtraLife powerUp;
	
	
	
	
	
	// Use this for initialization
    void Awake()
    {
		instance = this;
        Vector2 topRightCorner = new Vector2(1, 1); //viewport space places (1,1) at the top-right corner
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        screenHeight = edgeVector.y;
        Debug.Log("top right corner in world coordinate = " + edgeVector);
        screenWidth = edgeVector.x;
        minPosition.transform.position = new Vector3(-screenWidth, -screenHeight);
        maxPosition.transform.position = new Vector3(screenWidth, screenHeight);
    }
	void Start () {
        chunks1 = new GameObject[chunkParent.transform.childCount];
	    for(int i =0 ; i<chunkParent.transform.childCount; i++)
        {
            chunks1[i] = chunkParent.transform.GetChild(i).gameObject;
        }
        ShuffleChunks1();
        InvokeRepeating("NewPowerUp",5.0f,10.0f);
	}
	

    public void ShuffleChunks1()
    {
		Debug.Log ("startshuffle");
		StopAllCoroutines();
        StartCoroutine(Shuffle());
        
    }
    public void Rotate(){
		Direction nextDirection = Direction.left;
		switch(direction){
		case Direction.up: nextDirection = Direction.left; Physics2D.gravity = new Vector2(0,-9.81f * Mathf.Pow(-1,swapCount)); break;
		case Direction.left: nextDirection = Direction.down; Physics2D.gravity = new Vector2(9.81f * Mathf.Pow(-1,swapCount),0); break;
		case Direction.down: nextDirection = Direction.right; Physics2D.gravity = new Vector2(0,9.81f * Mathf.Pow(-1,swapCount)); break;
		case Direction.right: nextDirection = Direction.up; Physics2D.gravity = new Vector2(-9.81f * Mathf.Pow(-1,swapCount),0); break;
		}
		//Camera.main.transform.Rotate(0,0,90);
		character1.transform.Rotate(0,0,90);
		character2.transform.Rotate(0,0,90);
		direction = nextDirection;
		character1.rigidbody2D.velocity = Vector2.zero;
		character2.rigidbody2D.velocity = Vector2.zero;
    }
    public void SwapDirection(){
		swapCount ++;
		character1.ChangeDirection();
		character2.ChangeDirection();
		switch(direction){
		case Direction.up: direction = Direction.down; break;
		case Direction.left: direction = Direction.right; break;
		case Direction.down: direction = Direction.up; break;
		case Direction.right: direction = Direction.left; break;
		}
    }
    
    public void SwapPlayers(){
		iTween.MoveTo(character1.gameObject,character2.transform.position,.6f);
		iTween.MoveTo(character2.gameObject,character1.transform.position,.6f);
		
		
    }
    
    IEnumerator Shuffle()
    {
    
        float x;
        float y;
        RaycastHit hit;
        if(character1.Grounded(out hit)){
			character1.transform.parent = hit.transform;;
        }
		if(character2.Grounded(out hit)){
			character2.transform.parent = hit.transform;;
		}
		for(int i = 1; i< chunks1.Length; i++){
			bool placed = false;
			x = Random.Range(-screenWidth, screenWidth);
			y = Random.Range(-screenHeight, screenHeight);
			Vector3 position = new Vector3(x,y,0);
			Vector3 initialPos = chunks1[i].transform.position;
			while(!placed){
				
				chunks1[i].transform.position = position;
				placed = true;
				
				for(int j =0; j<i; j++){
					if(chunks1[i].collider2D.bounds.Intersects(chunks1[j].collider2D.bounds)){
						placed = false;
						break;
					}
				
				}
				yield return null;
			}
			chunks1[i].transform.position = initialPos;
			StartCoroutine(CustomLerp(chunks1[i],position, speedLerp));
			
			
		}
      
        
    }
    
    void ShuffleEnded(){
		character1.transform.parent = this.transform;
		character2.transform.parent = this.transform;
    }
    
    IEnumerator CustomLerp(GameObject objectToMove, Vector3 relativePosition, float speed){
		Vector3 destination = relativePosition + transform.position;
		while(Vector3.SqrMagnitude(objectToMove.transform.position - destination) >1.0f){
			objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position,destination,speedLerp);
			destination = transform.position + relativePosition;
			yield return new WaitForEndOfFrame();
		}
    }
    public void GameLost(byte loserID){
		Debug.Log ((1-loserID)+" Won");
    }
    private void NewPowerUp(){
    
		float x = Random.Range(-screenWidth, screenWidth);
		float y = Random.Range(-screenHeight, screenHeight);
		Vector3 position = new Vector3(x,y,0);
		GameObject pUp = Instantiate(powerUp.gameObject, position, powerUp.transform.rotation) as GameObject;
		pUp.transform.parent = chunkParent.transform.parent;
		
    }
    
    
}
