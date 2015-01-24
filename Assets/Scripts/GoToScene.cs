using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {

	public void LoadScene(int sceneId){
		Application.LoadLevel(sceneId);
	}
}
