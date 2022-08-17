using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.UI;

namespace Cthangband.StoreCommands
{
    internal class ViewRacialHeroesStoreCommand : IStoreCommand
    {
        public char Key => 'v';

        public bool RequiresRerendering => false;

        public string Description => "view racial Heroes";

        public void Execute(SaveGame saveGame, Store store)
        {
            saveGame.Gui.Save();
            //Program.HiScores.RaceFilter = saveGame.Player.RaceIndex;
            //Program.HiScores.DisplayScores(new HighScore(saveGame));
            //Program.HiScores.RaceFilter = -1;
            saveGame.Gui.Load();
        }

        public bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);
    }
}
