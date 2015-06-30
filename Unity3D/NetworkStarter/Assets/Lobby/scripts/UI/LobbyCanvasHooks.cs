using UnityEngine;
using UnityEngine.UI;

public class LobbyCanvasHooks : MonoBehaviour
{
	public delegate void CanvasHook();

	public CanvasHook OnAddPlayerHook;

	public Button firstButton;

	public void UIAddPlayer()
	{
		if (OnAddPlayerHook != null)
			OnAddPlayerHook.Invoke();
	}
}
