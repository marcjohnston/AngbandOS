// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EnlightenmentPotionItemFactory : PotionItemFactory
{
    private EnlightenmentPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Enlightenment";

    public override int Cost => 800;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Enlightenment";
    public override int LevelNormallyFound => 25;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (25, 1),
        (50, 1),
        (100, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Enlightenment shows you the whole level
        Game.MsgPrint("An image of your surroundings forms in your mind...");
        Game.RunScript(nameof(LightScript));
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
