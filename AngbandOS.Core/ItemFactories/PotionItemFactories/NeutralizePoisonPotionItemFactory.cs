// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NeutralizePoisonPotionItemFactory : PotionItemFactory
{
    private NeutralizePoisonPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Neutralize Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 75;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Neutralize Poison";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Cure poison removes any poison you have
        return Game.PoisonTimer.ResetTimer();
    }
    public override Item CreateItem() => new Item(Game, this);
}
