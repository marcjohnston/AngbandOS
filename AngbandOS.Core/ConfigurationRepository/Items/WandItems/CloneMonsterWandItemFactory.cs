// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CloneMonsterWandItemFactory : WandItemFactory
{
    private CloneMonsterWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<MinusSignSymbol>();
    public override string Name => "Clone Monster";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Clone Monster";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 50, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        return saveGame.CloneMonster(dir);
    }
    public override Item CreateItem() => new CloneMonsterWandItem(SaveGame);
}