// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MajorMagicksFolkBookItemFactory : FolkBookItemFactory
{
    private MajorMagicksFolkBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.BrightPurple;
    public override string Name => "[Major Magicks]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Major Magicks]";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new Item(Game, this);
    protected override string[] SpellNames => new string[]
    {
        nameof(FolkSpellResistLightning),
        nameof(FolkSpellResistAcid),
        nameof(FolkSpellCureMediumWounds),
        nameof(FolkSpellTeleport),
        nameof(FolkSpellStoneToMud),
        nameof(FolkSpellRayOfLight),
        nameof(FolkSpellSatisfyHunger),
        nameof(FolkSpellSeeInvisible)
    };
}