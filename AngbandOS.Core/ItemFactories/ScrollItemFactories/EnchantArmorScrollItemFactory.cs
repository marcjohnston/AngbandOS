// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EnchantArmorScrollItemFactory : ScrollItemFactory
{
    private EnchantArmorScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Enchant Armor";

    public override int Cost => 125;
    public override string CodedName => "Enchant Armor";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.Identified = true;
        if (!Game.EnchantItem(0, 0, 1))
        {
            eventArgs.UsedUp = false;
        }
    }
}
