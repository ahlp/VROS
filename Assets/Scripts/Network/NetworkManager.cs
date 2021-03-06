﻿using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public string gameVersion = "v0.1";
	private const string roomName = "room01";
	private RoomInfo[] roomsList;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings (gameVersion);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if (!PhotonNetwork.connected){

			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		
		} else if (PhotonNetwork.room == null){
			
			// Create Room
			if (GUI.Button(new Rect(100, 100, 250, 100), "New Room")) PhotonNetwork.CreateRoom(roomName);

			// Join Room
			if (GUI.Button(new Rect(100, 300, 250, 100), "Join Room")) PhotonNetwork.JoinRoom(roomName);
			/*if (roomsList != null){
				
				for (int i = 0; i<roomsList.Length; i++){
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
						PhotonNetwork.JoinRoom(roomsList[i].name);
				}

			}*/

		}

	}

	void OnReceivedRoomListUpdate(){
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom(){
		// Spawn player
		PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
	}
}
