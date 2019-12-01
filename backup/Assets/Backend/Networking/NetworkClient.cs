﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Project.Utilities;
using System;
//using Project.Player;
//using Project.Scriptable;
//using Project.Gameplay;

namespace Project.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        [Header("Network Client")]
        [SerializeField]
        private Transform networkContainer;
        [SerializeField]
        private GameObject Character;

        public static string ClientID { get; private set; }

        private Dictionary<string, NetworkIdentity> serverObjects;

        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            initialize();
            setupEvents();
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }

        private void initialize()
        {
            serverObjects = new Dictionary<string, NetworkIdentity>();
        }

        private void setupEvents()
        {
            On("open", (E) =>
            {
                Debug.Log("Connection has been made to the server");
            });

            On("register", (E) =>
            {
                ClientID = E.data["id"].ToString().RemoveQuotes();
                Debug.LogFormat("Client's ID ({0})", ClientID);
            });

            On("spawn", (E) =>
            {
                string id = E.data["id"].ToString().RemoveQuotes();
                //GameObject go = new GameObject("Server ID: " + id);
                //go.transform.SetParent(networkContainer);
                GameObject go = Instantiate(Character, networkContainer);
                go.name = string.Format("Player ({0})", id);
                NetworkIdentity ni = go.GetComponent<NetworkIdentity>();
                ni.SetControllerID(id);
                ni.SetSocketReference(this);
                serverObjects.Add(id, ni);
            });

            On("disconnected", (E) =>
            {
                string id = E.data["id"].ToString().RemoveQuotes();
                GameObject go = serverObjects[id].gameObject;
                Destroy(go);
                serverObjects.Remove(id);
            });

            On("updatePosition", (E) => {
                string id = E.data["id"].ToString().RemoveQuotes();
                float x = E.data["position"]["x"].f;
                float y = E.data["position"]["y"].f;

                NetworkIdentity ni = serverObjects[id];
                ni.transform.position = new Vector3(x, y, 0);
            });

        }
    }

    [Serializable]
    public class Player
    {
        public string id;
        public Position position;
    }

    [Serializable]
    public class Position
    {
        public float x;
        public float y;
    }
}