// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BeginnersHandbookSorceryBookItemFactory : BookItemFactory
{
    private BeginnersHandbookSorceryBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "[Beginner's Handbook]";

    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "& Sorcery Spellbook~ [Beginner's Handbook]";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;

    protected override string[] SpellNames => new string[]
    {
        nameof(SorcerySpellDetectMonsters),
        nameof(SorcerySpellPhaseDoor),
        nameof(SorcerySpellDetectDoorsAndTraps),
        nameof(SorcerySpellLightArea),
        nameof(SorcerySpellConfuseMonster),
        nameof(SorcerySpellTeleport),
        nameof(SorcerySpellSleepMonster),
        nameof(SorcerySpellRecharging)
    };
    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    public override string? CodedDivineName => $"& Book~ of Sorcery Magic";
    protected override string ItemClassName => nameof(SorcerySpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
    public override bool HatesFire => true;
    public override int PackSort => 7;
}
