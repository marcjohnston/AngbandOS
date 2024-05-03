// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MasterSorcerersHandbookSorceryBookItemFactory : SorceryBookItemFactory
{
    private MasterSorcerersHandbookSorceryBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "[Master Sorcerer's Handbook]";

    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "[Master Sorcerer's Handbook]";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new Item(Game, this);

    protected override string[] SpellNames => new string[]
    {
        nameof(SorcerySpellMagicMapping),
        nameof(SorcerySpellIdentify),
        nameof(SorcerySpellSlowMonster),
        nameof(SorcerySpellMassSleep),
        nameof(SorcerySpellTeleportAway),
        nameof(SorcerySpellHasteSelf),
        nameof(SorcerySpellDetectionTrue),
        nameof(SorcerySpellIdentifyTrue)
    };
}
