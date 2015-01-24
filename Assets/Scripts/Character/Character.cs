using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : KeepInScreen {
   
   public Text textFeedback;
   public int playerID;
   public int Lifes{
		set{
			if(value<life){
				if(Manager.instance.dieSounds!=null) if (Manager.instance.dieSounds.Length>0) AudioSource.PlayClipAtPoint(Manager.instance.dieSounds[Random.Range (0,Manager.instance.dieSounds.Length)],Vector3.zero);
			}
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
   public Animator[] animators;
   private int life = 7;
   public GameObject moveLeft, moveRight;
   private void Start(){
		Lifes = life;
   }
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
    public void EnableAnimators(bool state){
		foreach(Animator anim in animators){
			anim.enabled = state;
		}
	
    }
	
}
