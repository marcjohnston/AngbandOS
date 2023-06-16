// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HasteMonsterWandItemFactory : WandItemFactory
{
    private HasteMonsterWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '-';
    public override string Name => "Haste Monster";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Haste Monster";
    public override int Level => 2;
    public override int[] Locale => new int[] { 2, 0, 0, 0 };
    public override int? SubCategory => WandType.HasteMonster;
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        return saveGame.SpeedMonster(dir);
    }
    public override Item CreateItem() => new HasteMonsterWandItem(SaveGame);
}
