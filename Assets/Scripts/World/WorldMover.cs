using UnityEngine;
using System.Collections;

public class WorldMover : MonoBehaviour {
    
    public float speed;
    
  
    void FixedUpdate()
    {

        this.transform.position += new Vector3(speed,0,0) * Time.fixedDeltaTime;
    }
}
