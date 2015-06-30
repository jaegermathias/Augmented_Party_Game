using UnityEngine;
using UnityEngine.UI;

public class MatchMakerHooks : MonoBehaviour {

	public delegate void CanvasHook();

	public CanvasHook OnCreateGameHook;
	public CanvasHook OnJoinGameHook;
	public CanvasHook OnExitHook;

	public Button firstButton;
	public Text gameNameInput;
	public Text mmServerInput;

	public string GetGameName()
	{
		return gameNameInput.text;
	}

	public string GetMMServer()
	{
		return mmServerInput.text;
	}

	public void SetMMServer(string value)
	{
		mmServerInput.text = value;
	}

	public void UICreateGame()
	{
		if (OnCreateGameHook != null)
			OnCreateGameHook.Invoke();
	}

	public void UIJoinGame()
	{
		if (OnJoinGameHook != null)
			OnJoinGameHook.Invoke();
	}

	public void UIExit()
	{
		if (OnExitHook != null)
			OnExitHook.Invoke();
	}
}

