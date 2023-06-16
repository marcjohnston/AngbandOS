namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ViewClassHeroesStoreCommand : BaseStoreCommand
{
    private ViewClassHeroesStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'c';

    public override string Description => "view Class heroes";

    public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        //SaveGame.SaveScreen();
        //Program.HiScores.ClassFilter = saveGame.Player.ProfessionIndex;
        //Program.HiScores.DisplayScores(new HighScore(saveGame));
        //Program.HiScores.ClassFilter = -1;
        //SaveGame.Load();
    }
}
