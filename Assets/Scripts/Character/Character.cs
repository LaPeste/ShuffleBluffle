using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : KeepInScreen {
   
   public Text textFeedback;
   public byte playerID;
   public int Lifes{
		set{
			
			life = value;
			string s = "";
			
			for(int i =0; i<value; i++){
				s+="I ";
			}
			textFeedback.text = s;
		}
		get{
			return life;
		}
   }
   
   private int life = 5;
   public GameObject moveLeft, moveRight;
   protected override void ReSpawn ()
	{
		base.ReSpawn ();
		this.rigidbody2D.velocity = Vector2.zero;
		Lifes --;
		if(Lifes<=0){
			Manager.instance.GameLost(playerID);
		}
	}
	
	protected override void FixedUpdate(){
		base.FixedUpdate();
		
	}
	public bool Grounded(out RaycastHit hit){
	
		return Physics.Raycast(this.transform.position,Vector3.down,out hit,2.0f);
	}
    public void ChangeDirection(){
		moveLeft.SetActive(!moveLeft.activeSelf);
		moveRight.SetActive(!moveRight.activeSelf);
    }
	
}
