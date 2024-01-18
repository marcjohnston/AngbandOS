// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BlackMassDeathBookItemFactory : DeathBookItemFactory
{
    private BlackMassDeathBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "[Black Mass]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Black Mass]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new BlackMassDeathBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellOrbOfEntropy)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellNetherBolt)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellTerror)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellVampiricDrain)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellPoisonBranding)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellDispelGood)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellCarnage)),
        SaveGame.SingletonRepository.Spells.Get(nameof(DeathSpellRestoreLife))
    };
}
