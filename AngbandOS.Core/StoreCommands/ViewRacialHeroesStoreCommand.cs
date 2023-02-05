namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class ViewRacialHeroesStoreCommand : BaseStoreCommand
    {
        private ViewRacialHeroesStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'v';

        public override string Description => "view racial Heroes";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            //storeCommandEvent.SaveGame.SaveScreen();
            //Program.HiScores.RaceFilter = saveGame.Player.RaceIndex;
            //Program.HiScores.DisplayScores(new HighScore(saveGame));
            //Program.HiScores.RaceFilter = -1;
            //storeCommandEvent.SaveGame.Load();
        }
    }
}
