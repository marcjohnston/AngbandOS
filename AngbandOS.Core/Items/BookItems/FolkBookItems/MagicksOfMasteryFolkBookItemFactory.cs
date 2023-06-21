// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MagicksOfMasteryFolkBookItemFactory : FolkBookItemFactory
{
    private MagicksOfMasteryFolkBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "[Magicks of Mastery]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Magicks of Mastery]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new MagicksOfMasteryFolkBookItem(SaveGame);
    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<FolkSpellRecharging>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellTeleportLevel>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellIdentify>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellTeleportAway>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellElementalBall>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetection>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellWordOfRecall>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellClairvoyance>()
    };
}
