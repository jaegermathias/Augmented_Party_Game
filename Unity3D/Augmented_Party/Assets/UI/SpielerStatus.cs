using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpielerStatus : MonoBehaviour
{	
	//public Button playButton;
	public GameObject SpielerStatus1;
	public GameObject SpielerStatus2;
	public GameObject SpielerStatus3;
	public GameObject SpielerStatus4;
	public GameObject[] SpielerStatusSammlung;
	//public Text nameText;
	public RectTransform StatusPanel;
	
	void Start()
	{
		SpielerStatusSammlung = new GameObject[4]{
			SpielerStatus1,
			SpielerStatus2,
			SpielerStatus3,
			SpielerStatus4
		};
		//Spieler1Status.text = "Spieler1:III"; // Tut, was es soll
		//removeButton.gameObject.SetActive(false);
	}
	
	public void UIReady()
	{

	}

	
	public void UIRemove()
	{

	}
	
//	public void SetLocalPlayer()
//	{
//		isLocalPlayer = true;
//		nameText.text = "YOU";
//	}
}
