﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLibManager;

namespace Insthync.MMOG
{
    public class MapNetworkManager : LiteNetLibManager.LiteNetLibManager
    {
        public LiteNetLibScene hostingScene;
        public string publicMachineAddress = "127.0.0.1";
        public string centralServerAddress = "127.0.0.1";
        public int centralServerPort = 6000;
        private CentralNetworkManager cacheCentralNetworkManager;
        public CentralNetworkManager CacheCentralNetworkManager
        {
            get
            {
                if (cacheCentralNetworkManager == null)
                    cacheCentralNetworkManager = gameObject.AddComponent<CentralNetworkManager>();
                return cacheCentralNetworkManager;
            }
        }
        // This server will connect to central server to receive following data:
        // Login server address, Chat server address, Database server configuration
        protected override void RegisterServerMessages()
        {
            base.RegisterServerMessages();
        }

        protected override void RegisterClientMessages()
        {
            base.RegisterClientMessages();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            CacheCentralNetworkManager.onClientConnected = OnCentralClientConnected;
            CacheCentralNetworkManager.onClientDisconnected = OnCentralClientDisconnected;
            CacheCentralNetworkManager.StartClient(centralServerAddress, centralServerPort);
        }

        private void OnCentralClientConnected(NetPeer netPeer)
        {

        }

        private void OnCentralClientDisconnected(NetPeer netPeer, DisconnectInfo disconnectInfo)
        {

        }
    }
}