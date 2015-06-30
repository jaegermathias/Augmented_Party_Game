using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class GuiLobbyManager : NetworkLobbyManager
{
	public LobbyCanvasControl lobbyCanvas;
	public OfflineCanvasControl offlineCanvas;
	public OnlineCanvasControl onlineCanvas;
	public ExitToLobbyCanvasControl exitToLobbyCanvas;
	public ConnectingCanvasControl connectingCanvas;
	public PopupCanvasControl popupCanvas;
	public MatchMakerCanvasControl matchMakerCanvas;
	public JoinMatchCanvasControl joinMatchCanvas;

	public string onlineStatus;
	static public GuiLobbyManager s_Singleton;

	void Start()
	{
		s_Singleton = this;
		offlineCanvas.Show();
	}

	void OnLevelWasLoaded()
	{
		if (lobbyCanvas != null) lobbyCanvas.OnLevelWasLoaded();
		if (offlineCanvas != null) offlineCanvas.OnLevelWasLoaded();
		if (onlineCanvas != null) onlineCanvas.OnLevelWasLoaded();
		if (exitToLobbyCanvas != null) exitToLobbyCanvas.OnLevelWasLoaded();
		if (connectingCanvas != null) connectingCanvas.OnLevelWasLoaded();
		if (popupCanvas != null) popupCanvas.OnLevelWasLoaded();
		if (matchMakerCanvas != null) matchMakerCanvas.OnLevelWasLoaded();
		if (joinMatchCanvas != null) joinMatchCanvas.OnLevelWasLoaded();
	}

	public void SetFocusToAddPlayerButton()
	{
		if (lobbyCanvas == null)
			return;

		lobbyCanvas.SetFocusToAddPlayerButton();
	}

	// ----------------- Server callbacks ------------------

	public override void OnLobbyStopHost()
	{
		lobbyCanvas.Hide();
		offlineCanvas.Show();
	}

	public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
	{
		//This hook allows you to apply state data from the lobby-player to the game-player
		//var cc = lobbyPlayer.GetComponent<ColorControl>();
		//var playerX = gamePlayer.GetComponent<Player>();
		//playerX.myColor = cc.myColor;
		return true;
	}

	// ----------------- Client callbacks ------------------

	public override void OnLobbyClientConnect(NetworkConnection conn)
	{
		connectingCanvas.Hide();
	}

	public override void OnClientError(NetworkConnection conn, int errorCode)
	{
		connectingCanvas.Hide();
		StopHost();

		popupCanvas.Show("Client Error", errorCode.ToString());
	}

	public override void OnLobbyClientDisconnect(NetworkConnection conn)
	{
		lobbyCanvas.Hide();
		offlineCanvas.Show();
	}

	public override void OnLobbyStartClient(NetworkClient client)
	{
		if (matchInfo != null)
		{
			connectingCanvas.Show(matchInfo.address);
		}
		else
		{
			connectingCanvas.Show(networkAddress);
		}
	}

	public override void OnLobbyClientAddPlayerFailed()
	{
		popupCanvas.Show("Error", "No more players allowed.");
	}

	public override void OnLobbyClientEnter()
	{
		lobbyCanvas.Show();
		onlineCanvas.Show(onlineStatus);

		exitToLobbyCanvas.Hide();

	}

	public override void OnLobbyClientExit()
	{
		lobbyCanvas.Hide();
		onlineCanvas.Hide();

		if (Application.loadedLevelName == base.playScene)
		{
			exitToLobbyCanvas.Show();
		}
	}
}
