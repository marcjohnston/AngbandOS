using Cthangband;

namespace AngbandOS.Web.Hubs
{
    public interface IGameHub
    {
        /// <summary>
        /// Incoming web client request to play a game.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task Play(string guid);

        /// <summary>
        /// Incoming message from a web client of a keypress.
        /// </summary>
        /// <returns></returns>
        Task Keypressed(string c);

        /// <summary>
        /// Outgoing message to a web client to set the background color for a screen position.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        Task SetCellBackground(int row, int col, string color);

        /// <summary>
        /// Outgoing message to a web client to clear the screen.
        /// </summary>
        /// <returns></returns>
        Task Clear();

        /// <summary>
        /// Outgoing message to a web client to print text at a specific screen position and in a specific color.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="text"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        Task Print(int row, int col, string text, string color);

        /// <summary>
        /// Outgoing message to a web client to set a background image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task SetBackground(BackgroundImage image);

        /// <summary>
        /// Outgoing message to a web client to play a sound.
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        Task PlaySound(SoundEffect sound);

        /// <summary>
        /// Outgoing message to a web client to play a music track.
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        Task PlayMusic(MusicTrack music);
    }
}
