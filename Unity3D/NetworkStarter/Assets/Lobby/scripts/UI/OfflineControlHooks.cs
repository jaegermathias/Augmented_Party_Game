using UnityEngine;
using UnityEngine.UI;

public class OfflineControlHooks : MonoBehaviour
{
	public delegate void CanvasHook();

	public CanvasHook OnStartHostHook;
	public CanvasHook OnStartServerHook;
	public CanvasHook OnStartClientHook;
	public CanvasHook OnStartMMHook;

	public Text addressInput;
	public Button firstButton;

	public string GetAddress()
	{
		return addressInput.text;
	}


	public void UIStartHost()
	{
		if (OnStartHostHook != null)
			OnStartHostHook.Invoke();
	}

	public void UIStartServer()
	{
		if (OnStartServerHook != null)
			OnStartServerHook.Invoke();
	}

	public void UIStartClient()
	{
		if (OnStartClientHook != null)
			OnStartClientHook.Invoke();
	}

	public void UIStartMM()
	{
		if (OnStartMMHook != null)
			OnStartMMHook.Invoke();
	}
}
