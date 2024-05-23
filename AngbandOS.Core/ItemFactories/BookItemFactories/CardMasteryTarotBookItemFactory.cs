// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CardMasteryTarotBookItemFactory : BookItemFactory
{
    private CardMasteryTarotBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    public override string Name => "[Card Mastery]";
    public override string CodedName => "& Tarot Spellbook~ $Name$";
    public override string? AlternateCodedName => $"& Book~ of Tarot Magic $Name$";

    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;


    protected override string[] SpellNames => new string[]
    {
        nameof(TarotSpellSummonObject),
        nameof(TarotSpellSummonAnimal),
        nameof(TarotSpellPhantasmalServant),
        nameof(TarotSpellSummonMonster),
        nameof(TarotSpellConjureElemental),
        nameof(TarotSpellTeleportLevel),
        nameof(TarotSpellWordOfRecall),
        nameof(TarotSpellBanish)
    };
    protected override string ItemClassName => nameof(TarotSpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.TarotBook;
    public override int PackSort => 3;
    public override bool HatesFire => true;
}
