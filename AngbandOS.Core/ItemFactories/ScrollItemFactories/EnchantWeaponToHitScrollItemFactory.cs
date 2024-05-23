// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EnchantWeaponToHitScrollItemFactory : ScrollItemFactory
{
    private EnchantWeaponToHitScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Enchant Weapon To-Hit";

    public override int Cost => 125;
    public override string CodedName => "Enchant Weapon To-Hit";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!Game.EnchantItem(1, 0, 0))
        {
            eventArgs.UsedUp = false;
        }
        eventArgs.Identified = true;
    }
}
