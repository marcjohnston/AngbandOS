// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NecronomiconDeathBookItemFactory : DeathBookItemFactory
{
    private NecronomiconDeathBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "[Necronomicon]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Necronomicon]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 90;
    public override int[] Locale => new int[] { 90, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellDeathRay)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellRaiseTheDead)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellEsoteria)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellWordOfDeath)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellEvocation)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellHellfire)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellAnnihilation)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellWraithform))
    };

    public override Item CreateItem() => new NecronomiconDeathBookItem(SaveGame);
}
