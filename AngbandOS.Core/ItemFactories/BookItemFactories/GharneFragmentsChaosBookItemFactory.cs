// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GharneFragmentsChaosBookItemFactory : BookItemFactory
{
    private GharneFragmentsChaosBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "[G'harne Fragments]";
    protected override string? DescriptionSyntax => "Chaos Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Chaos Magic $Name$";
    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;

    public override int Weight => 30;
    public override bool KindIsGood => true;

    protected override string[] SpellNames => new string[]
    {
        nameof(ChaosSpellPolymorphOther),
        nameof(ChaosSpellChainLightning),
        nameof(ChaosSpellArcaneBinding),
        nameof(ChaosSpellDisintegrate),
        nameof(ChaosSpellAlterReality),
        nameof(ChaosSpellPolymorphSelf),
        nameof(ChaosSpellChaosBranding),
        nameof(ChaosSpellSummonDemon)
    };
    protected override string ItemClassName => nameof(ChaosSpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.ChaosBook;
    public override int PackSort => 5;
    public override bool HatesFire => true;
}