// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MagicksOfMasteryFolkBookItemFactory : BookItemFactory
{
    private MagicksOfMasteryFolkBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    public override string Name => "[Magicks of Mastery]";


    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override int Cost => 2500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "[Magicks of Mastery]";
    public override string CodedName => "& Folk Spellbook~ [Magicks of Mastery]";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    protected override string[] SpellNames => new string[]
    {
        nameof(FolkSpellRecharging),
        nameof(FolkSpellTeleportLevel),
        nameof(FolkSpellIdentify),
        nameof(FolkSpellTeleportAway),
        nameof(FolkSpellElementalBall),
        nameof(FolkSpellDetection),
        nameof(FolkSpellWordOfRecall),
        nameof(FolkSpellClairvoyance)
    };
    protected override string ItemClassName => nameof(FolkSpellBooksItemClass);
    public override string? CodedDivineName => $"& Book~ of Folk Magic";
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.FolkBook;
    public override int PackSort => 2;
    public override bool HatesFire => true;
}
