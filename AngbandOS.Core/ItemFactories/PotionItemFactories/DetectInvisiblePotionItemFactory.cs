// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DetectInvisiblePotionItemFactory : PotionItemFactory
{
    private DetectInvisiblePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Detect Invisible";

    public override int Cost => 50;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Detect Invisible";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Detect invisible gives you times see invisibility
        return Game.SeeInvisibilityTimer.AddTimer(12 + Game.DieRoll(12));
    }
    public override Item CreateItem() => new Item(Game, this);
}
