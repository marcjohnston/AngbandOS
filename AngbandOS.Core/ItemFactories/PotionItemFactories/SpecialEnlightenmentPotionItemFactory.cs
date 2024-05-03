// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpecialEnlightenmentPotionItemFactory : PotionItemFactory
{
    private SpecialEnlightenmentPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "*Enlightenment*";

    public override int Cost => 80000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "*Enlightenment*";
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 4)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // *Enlightenment* shows you the whole level, increases your intelligence and
        // wisdom, identifies all your items, and detects everything
        Game.MsgPrint("You begin to feel more enlightened...");
        Game.MsgPrint(null);
        Game.RunScript(nameof(LightScript));
        Game.TryIncreasingAbilityScore(Ability.Intelligence);
        Game.TryIncreasingAbilityScore(Ability.Wisdom);
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
        Game.DetectTreasure();
        Game.DetectObjectsGold();
        Game.RunScript(nameof(DetectNormalObjectsScript));
        Game.RunScript(nameof(IdentifyAllItemsScript));
        Game.RunScript(nameof(SelfKnowledgeScript));
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
