// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ViewClassHeroesStoreCommand : StoreCommand
{
    private ViewClassHeroesStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'c';

    public override string Description => "view Class heroes";

    public override bool IsEnabled(Store store) => (store.GetType() == typeof(HallStore));

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        //SaveGame.SaveScreen();
        //Program.HiScores.ClassFilter = saveGame.ProfessionIndex;
        //Program.HiScores.DisplayScores(new HighScore(saveGame));
        //Program.HiScores.ClassFilter = -1;
        //SaveGame.Load();
    }
}
