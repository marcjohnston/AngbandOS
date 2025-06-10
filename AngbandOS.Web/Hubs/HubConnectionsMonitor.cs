using AngbandOS.Web.Models;
using System.Collections.Concurrent;
namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a monitor for a hub.  Connections to a hub are tracked by the user and the date/time.  Disconnections remove the tracking.
    /// </summary>
    public class HubConnectionsMonitor
    {
        private readonly ConcurrentDictionary<string, HubConnectionDetails> hubConnections = new ConcurrentDictionary<string, HubConnectionDetails>();

        /// <summary>
        /// Returns details about all of the current connections.
        /// </summary>
        /// <returns></returns>
        public ActiveUserDetails[] GetAll()
        {
            List<ActiveUserDetails> activeConnections = new List<ActiveUserDetails>();
            foreach (KeyValuePair<string, HubConnectionDetails> connectionIdAndHubConnectionDetails in hubConnections)
            {
                activeConnections.Add(new ActiveUserDetails()
                {
                    ConnectionId = connectionIdAndHubConnectionDetails.Key,
                    DateTime = connectionIdAndHubConnectionDetails.Value.DateTime,
                    Username = connectionIdAndHubConnectionDetails.Value.Username
                });
            }
            return activeConnections.ToArray();
        }

        /// <summary>
        /// Adds a connection to the monitor.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="username"></param>
        public void Connected(string connectionId, string? username)
        {
            hubConnections.TryAdd(connectionId, new HubConnectionDetails()
            {
                DateTime = DateTime.Now,
                Username = username
            });
        }

        /// <summary>
        /// Removes a connection from the monitor.
        /// </summary>
        /// <param name="connectionId"></param>
        public void Disconnected(string connectionId)
        {
            hubConnections.TryRemove(connectionId, out _);
        }
    }
}
