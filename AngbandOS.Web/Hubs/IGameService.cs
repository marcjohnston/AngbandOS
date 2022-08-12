using Cthangband;

namespace AngbandOS.Web.Hubs
{
    public interface IGameService
    {
        string NewGame();
        void Play(string guid, string connectionId);
        void Keypressed(string connectionId, string keys);
    }
}
