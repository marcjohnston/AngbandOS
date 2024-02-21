// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CthaatAquadingenNatureBookItemFactory : NatureBookItemFactory
{
    private CthaatAquadingenNatureBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.Green;

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override string Name => "[Cthaat Aquadingen]";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Cthaat Aquadingen]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 80;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new Item(SaveGame, this);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellEarthquake)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellWhirlwindAttack)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellBlizzard)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellLightningStorm)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellWhirlpool)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellCallSunlight)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellElementalBranding)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellNaturesWrath))
    };
}
