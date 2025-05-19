// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KadathTown : TownGameConfiguration
{
    public override string[] StoreFactoryNames => new string[] {
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory),
        nameof(AbandonedStoreFactory)
    };


    /// <summary>
    /// Returns the Kadath dungeon because it is the dungeon under the city of Kadath.
    /// </summary>
    public override string DungeonName => nameof(KadathDungeon);

    public override int HousePrice => 0;
    public override string Name => "Kadath, home of the Gods";
    public override char Char => 'K';
    public override bool AllowStartupTown => false;
    public override bool UnusedStoreLotsAreGraveyards => true;
    public override bool CanBeEscortedHere => false;
}