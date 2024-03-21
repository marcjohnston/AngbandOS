// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AzathothChaosBookItemFactory : ChaosBookItemFactory
{
    private AzathothChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.


    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "[The Book of Azathoth]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[The Book of Azathoth]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;

    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new Item(SaveGame, this);

    protected override string[] SpellNames => new string[]
    {
        nameof(ChaosSpellGravityBeam),
        nameof(ChaosSpellMeteorSwarm),
        nameof(ChaosSpellFlameStrike),
        nameof(ChaosSpellCallChaos),
        nameof(ChaosSpellShardBall),
        nameof(ChaosSpellManaStorm),
        nameof(ChaosSpellBreatheChaos),
        nameof(ChaosSpellCallTheVoid)
    };
}
