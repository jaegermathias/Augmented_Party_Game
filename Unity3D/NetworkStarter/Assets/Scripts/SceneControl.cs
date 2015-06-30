using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SceneControl : NetworkBehaviour
 {
 	const int sceneIndex = 2;
 	
	[Command]
	public void CmdNewScene()
	{
		NetworkServer.SetAllClientsNotReady();
		NetworkManager.singleton.ServerChangeScene("ManyCrates");
	}

	[Command]
	public void CmdLobby()
	{
		var lobby = NetworkLobbyManager.singleton as NetworkLobbyManager;
		if (lobby)
		{
			NetworkManager.singleton.ServerChangeScene(lobby.lobbyScene);
		}
	}

	[ClientCallback]
	void OnGUI()
	{

		if (!isLocalPlayer) {
			return;
		}
		
		if (GUI.Button(new Rect(240, 30, 100, 20), "New Scene"))
		{
			CmdNewScene();
		}

		if (GUI.Button(new Rect(360, 30, 100, 20), "Exit"))
		{
			CmdLobby();
		}
	}
}
