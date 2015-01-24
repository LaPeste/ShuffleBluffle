using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	
	public AnimationCurve cameraShakeX, cameraShakeY;
	public AnimationCurve idleX, idleY;
	public AnimationCurve swapPlayersX, swapPlayersY;
	public AnimationCurve changeDirectionX, changeDirectionY;
	public AnimationCurve changeGravityX, changeGravityY;
	
	public delegate void AnimationFunction(float moment);
	private Vector3 initialCameraPos;
	
	private float lastChange;
	
	public enum CameraMotion{
		idle,
		shake,
		swap,
		direction,
		gravity
	}
	
	public CameraMotion CurrentMotion{
		set{
			currentMotion = value;
			lastChange = Time.time;
		}
		get{
			return currentMotion;
		}
	}
	
	private CameraMotion currentMotion;
	private void Start(){
		initialCameraPos = transform.position;
	}
	
	private void Update(){
		switch(currentMotion){
			case CameraMotion.idle:      playIdle(Time.time); break;
			case CameraMotion.shake:     playShake(Time.time-lastChange); break;
		    case CameraMotion.swap:      playSwapPlayers(Time.time-lastChange); break;
		    case CameraMotion.direction: playDirection(Time.time-lastChange); break;
		    case CameraMotion.gravity:   playGravity(Time.time-lastChange); break;
		}
		if(Time.time - lastChange>1){
			currentMotion = CameraMotion.idle;
		}
		
	}
	
	public void playShake(float moment){
		transform.position = initialCameraPos + new Vector3(cameraShakeX.Evaluate(moment),cameraShakeY.Evaluate(moment),0);
	}
	public void playIdle(float moment){
		transform.position = initialCameraPos + new Vector3(idleX.Evaluate(moment),idleY.Evaluate(moment),0);
	}
	public void playSwapPlayers(float moment){
		transform.position = initialCameraPos + new Vector3(swapPlayersX.Evaluate(moment),swapPlayersY.Evaluate(moment),0);
	}
	public void playDirection(float moment){
		transform.position = initialCameraPos + new Vector3(changeDirectionX.Evaluate(moment),changeDirectionY.Evaluate(moment),0);
	}
	public void playGravity(float moment){
		transform.position = initialCameraPos + new Vector3(changeGravityX.Evaluate(moment),changeGravityY.Evaluate(moment),0);
	}
}
