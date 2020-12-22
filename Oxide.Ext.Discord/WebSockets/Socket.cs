﻿namespace Oxide.Ext.Discord.WebSockets
{
    using System;
    using Oxide.Core;
    using Oxide.Ext.Discord.Exceptions;
    using WebSocketSharp;

    public class Socket
    {
        private DiscordClient client;

        private WebSocket socket;

        private SocketListner listner;

        public bool hasConnectedOnce = false;

        public Socket(DiscordClient client)
        {
            this.client = client;
        }

        public void Connect(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new NoURLException();
            }

            if (socket != null)
            {
                // Assume force-reconnect
                Disconnect(false);
            }
            client.DestroyHeartbeat();

            socket = new WebSocket($"{url}/?v=6&encoding=json");

            if(listner == null)
                listner = new SocketListner(client, this);

            socket.OnOpen += listner.SocketOpened;
            socket.OnClose += listner.SocketClosed;
            socket.OnError += listner.SocketErrored;
            socket.OnMessage += listner.SocketMessage;

            socket.ConnectAsync();
        }

        public void Disconnect(bool normal = true)
        {
            if (IsClosed() || IsClosing()) return;

            socket?.CloseAsync(normal ? CloseStatusCode.Normal : CloseStatusCode.Abnormal);
        }

        public void ReconnectRequested()
        {
            if (IsClosed() || IsClosing()) return;

            socket?.CloseAsync(4000, "Discord server requested reconnect");
        }

        public void Dispose()
        {
            listner = null;
            socket = null;
        }

        public void Send(string message, Action<bool> completed = null)
        {
            if (IsAlive())
                socket.SendAsync(message, completed);
        }

        public bool IsAlive()
        {
            if (socket == null)
                return false;
            return socket.ReadyState == WebSocketState.Open;
        }

        public bool IsClosing()
        {
            if (socket == null)
                return false;
            return socket.ReadyState == WebSocketState.Closing;
        }

        public bool IsClosed()
        {
            if (socket == null)
                return true;
            return socket.ReadyState == WebSocketState.Closed;
        }
    }
}
