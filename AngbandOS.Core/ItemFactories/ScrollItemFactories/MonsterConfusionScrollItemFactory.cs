// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MonsterConfusionScrollItemFactory : ScrollItemFactory
{
    private MonsterConfusionScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Monster Confusion";

    public override int Cost => 30;
    public override string CodedName => "Monster Confusion";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!Game.HasConfusingTouch)
        {
            Game.MsgPrint("Your hands begin to glow.");
            Game.HasConfusingTouch = true;
            eventArgs.Identified = true;
        }
    }
}
