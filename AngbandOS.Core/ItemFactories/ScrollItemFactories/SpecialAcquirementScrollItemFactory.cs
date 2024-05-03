// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpecialAcquirementScrollItemFactory : ScrollItemFactory
{
    private SpecialAcquirementScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "*Acquirement*";

    public override int Cost => 200000;
    public override string FriendlyName => "*Acquirement*";
    public override int LevelNormallyFound => 60;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (60, 16)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.Acquirement(Game.MapY.IntValue, Game.MapX.IntValue, Game.DieRoll(2) + 1, true);
        eventArgs.Identified = true;
    }
}
