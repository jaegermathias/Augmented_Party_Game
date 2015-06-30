using System;
using UnityEngine;
using UnityEngine.UI;

public class OnlineControlHooks : MonoBehaviour
{
	public delegate void CanvasHook();

	public CanvasHook OnStopHook;

	public Text statusText;
	public Text addressText;
	public Button firstButton;

	public void UIStop()
	{
		if (OnStopHook != null)
			OnStopHook.Invoke();
	}

	public void SetStatus(string status)
	{
		statusText.text = "Status:  " + status;
	}

	public void SetAddress(string address)
	{
		addressText.text = "Address: " + address;
	}
}
