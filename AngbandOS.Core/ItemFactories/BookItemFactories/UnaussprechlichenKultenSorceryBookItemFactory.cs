// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class UnaussprechlichenKultenSorceryBookItemFactory : BookItemFactory
{
    private UnaussprechlichenKultenSorceryBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "[Unaussprechlichen Kulten]";
    protected override string? DescriptionSyntax => "Sorcery Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Sorcery $Name$";
    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };

    public override int Weight => 30;
    public override bool KindIsGood => true;

    protected override string[] SpellNames => new string[]
    {
        nameof(SorcerySpellDetectObjectsAndTreasure),
        nameof(SorcerySpellDetectEnchantment),
        nameof(SorcerySpellCharmMonster),
        nameof(SorcerySpellDimensionDoor),
        nameof(SorcerySpellSenseMinds),
        nameof(SorcerySpellSelfKnowledge),
        nameof(SorcerySpellTeleportLevel),
        nameof(SorcerySpellWordOfRecall)
    };

    protected override string ItemClassName => nameof(SorcerySpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 7;
}
