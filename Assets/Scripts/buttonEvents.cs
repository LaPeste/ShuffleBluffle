using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonEvents : MonoBehaviour {
	public Button Btn; 
	public Image BtnImage; 

	// Use this for initialization
	void Start () {
	
		BtnImage = Btn.GetComponent<Image> ();
		BtnImage.fillAmount = 1.0f;

	}
	
	// Update is called once per frame
	public void Update () 
	{
	}


	public void onClickEff()
	{	
		if (BtnImage.fillAmount == 1.0f) 
		{
			Debug.Log ("do something");
			BtnImage.fillAmount = 0.0f;
			StartCoroutine(Fill());
		}
	}
	IEnumerator Fill ()
	{
		Btn.interactable = false;
		while (BtnImage.fillAmount< 1.0f) {
				//Debug.Log(lbBtnImage.fillAmount);
				BtnImage.fillAmount += 0.006f;
				yield return new WaitForSeconds(0.05f);
				}
		yield return new WaitForSeconds(0.1f);

		Btn.interactable = true;
	}

}
