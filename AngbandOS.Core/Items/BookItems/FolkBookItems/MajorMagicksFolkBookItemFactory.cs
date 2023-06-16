// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MajorMagicksFolkBookItemFactory : FolkBookItemFactory
{
    private MajorMagicksFolkBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "[Major Magicks]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Major Magicks]";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int? SubCategory => 2;

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new MajorMagicksFolkBookItem(SaveGame);
    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<FolkSpellResistLightning>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellResistAcid>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellCureMediumWounds>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellTeleport>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellStoneToMud>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellRayOfLight>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellSatisfyHunger>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellSeeInvisible>()
    };
}
