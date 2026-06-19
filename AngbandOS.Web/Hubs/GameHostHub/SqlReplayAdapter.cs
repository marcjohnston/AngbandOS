using AngbandOS.Core.Interface;
using AngbandOS.Web.Interface;

namespace AngbandOS.Web.Hubs
{
    internal class SqlReplayAdapter : IReplayPersistentStorage
    {
        private readonly int GameReplayId;
        private readonly IWebPersistentStorage WebPersistentStorage;
        public SqlReplayAdapter(int gameReplayId, IWebPersistentStorage webPersistentStorage)
        {
            GameReplayId = gameReplayId;
            WebPersistentStorage = webPersistentStorage;
        }
        public void WriteStep(DateTime dateTime, char keystroke, int seed, string? stackTrace = null)
        {
            WebPersistentStorage.WriteStep(GameReplayId, dateTime, keystroke, seed, stackTrace);
        }
    }
}
