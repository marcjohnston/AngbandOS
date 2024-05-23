// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CantripsforBeginnersFolkBookItemFactory : BookItemFactory
{
    private CantripsforBeginnersFolkBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    public override string Name => "[Cantrips for Beginners]";

    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "& Folk Spellbook~ [Cantrips for Beginners]";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    protected override string[] SpellNames => new string[]
    {
        nameof(FolkSpellZap),
        nameof(FolkSpellWizardLock),
        nameof(FolkSpellDetectInvisibility),
        nameof(FolkSpellDetectMonsters),
        nameof(FolkSpellBlink),
        nameof(FolkSpellLightArea),
        nameof(FolkSpellTrapAndDoorDestruction),
        nameof(FolkSpellCureLightWounds),
    };
    protected override string ItemClassName => nameof(FolkSpellBooksItemClass);
    public override string? CodedDivineName => $"& Book~ of Folk Magic";
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.FolkBook;
    public override int PackSort => 2;
    public override bool HatesFire => true;
}
