// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ViewRacialHeroesStoreCommand : BaseStoreCommand
{
    private ViewRacialHeroesStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'v';

    public override string Description => "view racial Heroes";

    public override bool IsEnabled(Store store) => (store.GetType() == typeof(HallStore));

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        //storeCommandEvent.SaveGame.SaveScreen();
        //Program.HiScores.RaceFilter = saveGame.Player.RaceIndex;
        //Program.HiScores.DisplayScores(new HighScore(saveGame));
        //Program.HiScores.RaceFilter = -1;
        //storeCommandEvent.SaveGame.Load();
    }
}
