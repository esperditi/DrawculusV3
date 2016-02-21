//using UnityEngine;
//using System.Collections;
//
//public class NetworkController : MonoBehaviour {
//
//	string _room = "DrawculaTest";
//
//	//On startup connect to photon network 
//	void Start () {
//		Debug.Log ("Connecting to Photon Server for Drawcula Project");
//		PhotonNetwork.ConnectUsingSettings ("0.1");
//		Debug.Log ("Connection to Photon Server successful!");
//	}
//
//	//Join online cloud lobby and specified room
//	void OnJoinedLobby() {
//		Debug.Log ("Joined Lobby for Drawcula Project");
//		RoomOptions roomOptions = new RoomOptions() {};
//		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
//	}
//
//	//After connecting to room in lobby, instantiate the player
//	void OnJoinedRoom() {
//		PhotonNetwork.Instantiate ("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
//	}
//}

using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {

	private const string Version = "1.0";
	public string roomname = "MultiplayerRoom";
	public string playerPrefabName = "MultiplayerCar01";
	public GameObject[] spawnpoints;
	public int SpawnpointMax = 1;

	void Start () {
		Debug.Log("Inside Start");
		Debug.Log("Number of players in Lobby" +SpawnpointMax);
		spawnpoints = new GameObject[1];
		spawnpoints[0] = GameObject.Find ("P1");
		spawnpoints[1] = GameObject.Find ("P2");
		spawnpoints[2] = GameObject.Find ("P3");
		spawnpoints[3] = GameObject.Find ("P4");
		PhotonNetwork.ConnectUsingSettings(Version);
	}

	void OnJoinedLobby () {
		Debug.Log("Inside OnJoinedLobby: " + SpawnpointMax);
		RoomOptions roomOptions = new RoomOptions() {isVisible = true, maxPlayers = 1};
		PhotonNetwork.JoinOrCreateRoom(roomname, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom ()
	{
		Debug.Log("Inside OnJoinedRoom");
		if (PhotonNetwork.room.playerCount == 4)
		{
			StartGame();
		}
	}

	void StartGame ()
	{
		Debug.Log("Inside StartGame");

		//spawn the player at different positions
		for (int i = 0; i < SpawnpointMax; i ++)
		{
			PhotonNetwork.Instantiate("NetworkedPlayer",spawnpoints[i].transform.position,spawnpoints[i].transform.rotation,0);
		}
	}
}