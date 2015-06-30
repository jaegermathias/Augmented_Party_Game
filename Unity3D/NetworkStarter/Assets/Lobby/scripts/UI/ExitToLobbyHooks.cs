using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitToLobbyHooks : MonoBehaviour
{
	public delegate void CanvasHook();

	public CanvasHook OnExitHook;

	public Button firstButton;

	public void UIExit()
	{
		if (OnExitHook != null)
			OnExitHook.Invoke();
	}
}
