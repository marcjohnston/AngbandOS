using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.UI;
using System;

namespace AngbandOS.StoreCommands
{
    internal class ViewClassHeroesStoreCommand : IStoreCommand
    {
        public char Key => 'c';

        public bool RequiresRerendering => false;

        public string Description => "view Class heroes";

        public void Execute(SaveGame saveGame, Store store)
        {
            saveGame.Save();
            //Program.HiScores.ClassFilter = saveGame.Player.ProfessionIndex;
            //Program.HiScores.DisplayScores(new HighScore(saveGame));
            //Program.HiScores.ClassFilter = -1;
            saveGame.Load();
        }

        public bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);
    }
}
