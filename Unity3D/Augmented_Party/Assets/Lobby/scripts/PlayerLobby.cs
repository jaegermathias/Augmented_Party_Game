using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerLobby : NetworkLobbyPlayer
{
	public Canvas playerCanvasPrefab;
	public Canvas playerCanvas;
	
	// Blau RGB: 51 105 232 Normalisiert: 
	private static Color blau = new Color (0.2F, 0.042F, 0.910F);
	//Rot RGB: 213 15 37 Normalisiert: 
	private static Color rot = new Color (0.835F, 0.059F, 0.145F);
	// Gelb RGB: 238 178 17 Normalisiert: 
	private static Color gelb = new Color (0.933F, 0.698F, 0.066F);
	// Gruen RGB: 0 153 37 Normalisiert: 
	private static Color gruen = new Color (0.0F, 0.6F, 0, 145F);
	
	private Color[] farben = new Color[4]{blau,rot,gelb,gruen};

	private int guiVersatz = 1;

	// cached components
	ColorControl cc;
	NetworkLobbyPlayer lobbyPlayer;

	void Awake ()
	{
		cc = GetComponent<ColorControl> ();
		lobbyPlayer = GetComponent<NetworkLobbyPlayer> ();

				if (Application.platform == RuntimePlatform.Android)
					guiVersatz = 1;
				else {
					guiVersatz = 2;
				}
	}


	public override void OnClientEnterLobby ()
	{
		if (playerCanvas == null) {
			playerCanvas = (Canvas)Instantiate (playerCanvasPrefab, Vector3.zero, Quaternion.identity);
			playerCanvas.sortingOrder = 1;

			playerCanvas.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = farben[lobbyPlayer.slot];
		}

		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks> ();
		hooks.panelPos.localPosition = new Vector3 (GetPlayerPos (lobbyPlayer.slot), 0, 0);

//		switch (lobbyPlayer.slot) {
//		case 0:
//			{
//				Debug.Log (blau);
//				break;
//			}
//		case 1:
//			{
//				Debug.Log (blau);
//				break;
//			}
//		default:
//			{
//				break;
//			}
//		}



		hooks.SetReady (lobbyPlayer.readyToBegin);
	}

	public override void OnClientExitLobby ()
	{
		if (playerCanvas != null) {
			Destroy (playerCanvas.gameObject);
		}
	}

	public override void OnClientReady (bool readyState)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks> ();
		hooks.SetReady (readyState);
	}

	float GetPlayerPos (int slot)
	{
		var lobby = NetworkManager.singleton as GuiLobbyManager;
		if (lobby == null) {
			// no lobby?
			return slot * 200;
		}

		// this spreads the player canvas panels out across the screen
		var screenWidth = playerCanvas.pixelRect.width;
		screenWidth -= 200; // border padding
		var playerWidth = screenWidth / (lobby.maxPlayers - 1);
		return -(screenWidth / 2) + slot * playerWidth;
	}

	public override void OnStartLocalPlayer ()
	{
		if (playerCanvas == null) {
			playerCanvas = (Canvas)Instantiate (playerCanvasPrefab, Vector3.zero, Quaternion.identity);
			playerCanvas.sortingOrder = 1;
		}

		// setup button hooks
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks> ();
		hooks.panelPos.localPosition = new Vector3 (GetPlayerPos (lobbyPlayer.slot) * guiVersatz, 0, 0);
		hooks.SetColor (cc.myColor);

		hooks.OnColorChangeHook = OnGUIColorChange;
		hooks.OnReadyHook = OnGUIReady;
		hooks.OnRemoveHook = OnGUIRemove;
		hooks.SetLocalPlayer ();
	}

	void OnDestroy ()
	{
		if (playerCanvas != null) {
			Destroy (playerCanvas.gameObject);
		}
	}

	public void SetColor (Color color)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks> ();
		hooks.SetColor (color);
	}

	public void SetReady (bool ready)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks> ();
		hooks.SetReady (ready);
	}

	[Command]
	public void CmdExitToLobby ()
	{
		var lobby = NetworkManager.singleton as GuiLobbyManager;
		if (lobby != null) {
			lobby.ServerReturnToLobby ();
		}
	}

	// events from UI system

	void OnGUIColorChange ()
	{
		if (isLocalPlayer)
			cc.ClientChangeColor ();
	}

	void OnGUIReady ()
	{
		if (isLocalPlayer)
			lobbyPlayer.SendReadyToBeginMessage ();
	}

	void OnGUIRemove ()
	{
		if (isLocalPlayer) {
			ClientScene.RemovePlayer (lobbyPlayer.playerControllerId);

			var lobby = NetworkManager.singleton as GuiLobbyManager;
			if (lobby != null) {
				lobby.SetFocusToAddPlayerButton ();
			}
		}
	}
}

