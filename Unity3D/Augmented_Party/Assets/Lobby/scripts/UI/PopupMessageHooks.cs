using UnityEngine;
using UnityEngine.UI;

public class PopupMessageHooks : MonoBehaviour {

	public delegate void CanvasHook();

	public CanvasHook OnExitHook;

	public Button firstButton;
	public Text titleText;
	public Text messagText;

	public void UIExit()
	{
		if (OnExitHook != null)
			OnExitHook.Invoke();
	}
}

