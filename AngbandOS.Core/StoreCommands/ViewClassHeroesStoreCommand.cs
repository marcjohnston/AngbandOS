namespace AngbandOS.StoreCommands
{
    internal class ViewClassHeroesStoreCommand : BaseStoreCommand
    {
        public override char Key => 'c';

        public override string Description => "view Class heroes";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.SaveGame.SaveScreen();
            //Program.HiScores.ClassFilter = saveGame.Player.ProfessionIndex;
            //Program.HiScores.DisplayScores(new HighScore(saveGame));
            //Program.HiScores.ClassFilter = -1;
            storeCommandEvent.SaveGame.Load();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);
    }
}
