using UnityEngine;
using System.Collections;

public class Chunk : KeepInScreen {

	
	protected override void ReSpawn ()
	{
		
		bool placed = false;
	
		float randValue = Random.Range (min.y , max.y);
		Vector3 position = RandomPosition();
		transform.position = position;
		while(!placed){
			
			this.transform.position = position;
			randValue = Random.Range (min.y , max.y);
			
			position = RandomPosition();
			placed = true;
			
			for(int j =0; j<Manager.instance.chunks1.Length; j++){
				if(this.collider2D.bounds.Intersects(Manager.instance.chunks1[j].collider2D.bounds) && this.transform != Manager.instance.chunks1[j].transform){
					placed = false;
					break;
				}
				
			}
			
		}
	}
	
	
	
	private Vector3 RandomPosition(){
		switch(Manager.instance.direction){
			case Manager.Direction.left: return new Vector3(max.x,Random.Range(min.y, max.y),0); break;
			case Manager.Direction.right: return new Vector3(min.x,Random.Range(min.y, max.y),0); break;
			case Manager.Direction.up: return new Vector3(Random.Range(min.x, max.x),min.y,0); break;
		    case Manager.Direction.down: return new Vector3(Random.Range(min.x, max.x),max.y,0); break;
		    default: return Vector3.zero;
			
			}
	}
	
	
}
