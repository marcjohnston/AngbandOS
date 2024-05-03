// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MassCarnageScrollItemFactory : ScrollItemFactory
{
    private MassCarnageScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Mass Carnage";

    public override int Cost => 1000;
    public override string FriendlyName => "Mass Carnage";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 4),
        (100, 4)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.RunScriptBool(nameof(MassCarnageScript), true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
