using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    internal class ViewClassHeroesStoreCommand : IStoreCommand
    {
        public char Key => 'c';

        public bool RequiresRerendering => false;

        public string Description => "view Class heroes";

        public void Execute(SaveGame saveGame, Store store)
        {
            Gui.Save();
            Program.HiScores.ClassFilter = saveGame.Player.ProfessionIndex;
            Program.HiScores.DisplayScores(new HighScore(saveGame.Player));
            Program.HiScores.ClassFilter = -1;
            Gui.Load();
        }

        public bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);
    }
}
