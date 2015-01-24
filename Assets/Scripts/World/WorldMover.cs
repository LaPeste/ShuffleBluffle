using UnityEngine;
using System.Collections;

public class WorldMover : MonoBehaviour {
    
    public float speed;
    
    void FixedUpdate()
    {

       
        switch(Manager.instance.direction){
			case Manager.Direction.down:  this.transform.position += new Vector3(0,-speed,0) * Time.fixedDeltaTime; break;
			case Manager.Direction.up:    this.transform.position += new Vector3(0,speed,0) * Time.fixedDeltaTime; break;
			case Manager.Direction.left:  this.transform.position += new Vector3(-speed,0,0) * Time.fixedDeltaTime; break;
		    case Manager.Direction.right: this.transform.position += new Vector3(speed,0,0) * Time.fixedDeltaTime; break;
		}
    }
}
