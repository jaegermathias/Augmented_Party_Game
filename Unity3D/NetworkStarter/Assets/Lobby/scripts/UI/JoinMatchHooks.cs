using UnityEngine;
using System.Collections;
using System.Security.Principal;
using UnityEngine.UI;

public class JoinMatchHooks : MonoBehaviour {

	public delegate void ButtonHook(int value);
	public delegate void CanvasHook();

	public CanvasHook OnReturnToMMHook;

	public ButtonHook OnGameHook;

	public Button firstButton;
	public Text gameButton0;
	public Text gameButton1;
	public Text gameButton2;
	public Text gameButton3;
	public Text gameButton4;
	public Text gameButton5;

	public void UIReturnToMM()
	{
		if (OnReturnToMMHook != null)
			OnReturnToMMHook.Invoke();
	}

	public void UIJoin(int value)
	{
		if (OnGameHook != null)
			OnGameHook(value);
	}


	public void SetMatchName(int index, string name)
	{
		switch (index)
		{
			case 0: gameButton0.text = name; return;
			case 1: gameButton1.text = name ; return;
			case 2: gameButton2.text = name; return;
			case 3: gameButton3.text = name; return;
			case 4: gameButton4.text = name; return;
			case 5: gameButton5.text = name; return;
		}
	}

	void Update()
	{
		/*
		if (GuiLobbyManager.ControllerButton(GuiLobbyManager.ControlButton.Y))
		{
			UIJoin0();
		}

		if (GuiLobbyManager.ControllerButton(GuiLobbyManager.ControlButton.X))
		{
			UIReturnToMM();
		}

		if (GuiLobbyManager.ControllerButton(GuiLobbyManager.ControlButton.B))
		{
			UIJoin1();
		}
		 * */
	}
}
