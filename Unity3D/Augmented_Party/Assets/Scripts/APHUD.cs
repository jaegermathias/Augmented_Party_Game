#if ENABLE_UNET

namespace UnityEngine.Networking
{
	[AddComponentMenu("Network/NetworkManagerHUD")]
	[RequireComponent(typeof(NetworkManager))]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class APHUD : MonoBehaviour
	{
		public NetworkManager manager;
		[SerializeField] public bool showGUI = true;
		[SerializeField] public int offsetX;
		[SerializeField] public int offsetY;

		public GUISkin customSkin;

		// Runtime variable
		bool showServer = false;

		void Awake()
		{
			manager = GetComponent<NetworkManager>();
			//offsetX = Screen.width / 2;
			//offsetY = Screen.height / 2;
			offsetX = 0;
			offsetY = 0;
		}

		void Update()
		{
			if (!showGUI)
				return;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					manager.StartServer();
				}
				if (Input.GetKeyDown(KeyCode.H))
				{
					manager.StartHost();
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					manager.StartClient();
				}
			}
			if (NetworkServer.active && NetworkClient.active)
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					manager.StopHost();
				}
			}
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			//int xpos = 10 + offsetX;
			//int ypos = 40 + offsetY;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (GUILayout.Button("Netzwerkspiel hosten(H)"))
				{
					manager.StartHost();
				}

				if (GUILayout.Button("Netzwerkspiel beitreten (C)"))
				{
					manager.StartClient();
				}
				manager.networkAddress = GUILayout.TextField(manager.networkAddress);

				if (GUILayout.Button("LAN Server Only(S)"))
				{
					manager.StartServer();
				}
			}
			else
			{
				if (NetworkServer.active)
				{
					GUILayout.Label("Server: port=" + manager.networkPort);
				}
				if (NetworkClient.active)
				{
					GUILayout.Label("Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
				}
			}

			if (NetworkClient.active && !ClientScene.ready)
			{
				if (GUILayout.Button("Client Ready"))
				{
					ClientScene.Ready(manager.client.connection);
				
					if (ClientScene.localPlayers.Count == 0)
					{
						ClientScene.AddPlayer(0);
					}
				}
			}

			if (NetworkServer.active || NetworkClient.active)
			{
				if (GUILayout.Button("Stop (X)"))
				{
					manager.StopHost();
				}
			}

			if (!NetworkServer.active && !NetworkClient.active)
			{
				if (manager.matchMaker == null)
				{
					if (GUILayout.Button("Enable Match Maker (M)"))
					{
						manager.StartMatchMaker();
					}
				}
				else
				{
					if (manager.matchInfo == null)
					{
						if (manager.matches == null)
						{
							if (GUILayout.Button("Create Internet Match"))
							{
								manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, false, "", manager.OnMatchCreate);
							}

							GUILayout.Label("Room Name:");
							manager.matchName = GUILayout.TextField(manager.matchName);

							if (GUILayout.Button("Find Internet Match"))
							{
								manager.matchMaker.ListMatches(0,20, "", manager.OnMatchList);
							}
						}
						else
						{
							foreach (var match in manager.matches)
							{
								if (GUILayout.Button("Join Match:" + match.name))
								{
									manager.matchName = match.name;
									manager.matchSize = (uint)match.currentSize;
									manager.matchMaker.JoinMatch(match.networkId, "", manager.OnMatchJoined);
								}
							}
						}
					}

					if (GUILayout.Button("MM-Server wechseln"))
					{
						showServer = !showServer;
					}
					if (showServer)
					{
						if (GUILayout.Button("Local"))
						{
							manager.SetMatchHost("localhost", 1337, false);
							showServer = false;
						}
						if (GUILayout.Button("Internet"))
						{
							manager.SetMatchHost("mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
						if (GUILayout.Button("Staging"))
						{
							manager.SetMatchHost("staging-mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
					}

					GUILayout.Label( "MM Uri: " + manager.matchMaker.baseUri);

					if (GUILayout.Button("Disable Match Maker"))
					{
						manager.StopMatchMaker();
					}
				}
			}
		}
	}
};
#endif //ENABLE_UNET
