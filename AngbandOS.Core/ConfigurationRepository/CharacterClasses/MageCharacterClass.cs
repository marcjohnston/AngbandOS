﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class MageCharacterClass : BaseCharacterClass
{
    private MageCharacterClass(SaveGame savedGame) : base(savedGame) { }
    public override int ID => 1;
    public override string Title => "Mage";
    public override int[] AbilityBonus => new[] { -5, 3, 0, 1, -2, 1 };
    public override int BaseDisarmBonus => 30;
    public override int BaseDeviceBonus => 36;
    public override int BaseSaveBonus => 30;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 16;
    public override int BaseSearchFrequency => 20;
    public override int BaseMeleeAttackBonus => 34;
    public override int BaseRangedAttackBonus => 20;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 13;
    public override int SaveBonusPerLevel => 9;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 15;
    public override int RangedAttackBonusPerLevel => 15;
    public override int HitDieBonus => 0;
    public override int ExperienceFactor => 30;
    public override int PrimeStat => Ability.Intelligence;
    public override string[] Info => new string[] {
        "Flexible INT based spell casters who can cast magic from",
        "any two realms of their choice. However, they can't wear",
        "much armour before it starts disrupting their casting."
    };
    public override int SpellWeight => 300;
    public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get<ArcaneCastingType>();
    public override int SpellStat => Ability.Intelligence;
    public override int MaximumMeleeAttacksPerRound(int level) => 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 2;
    public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<MageArtifactBias>();
    public override bool SenseInventoryTest(int level) => (0 != SaveGame.Rng.RandomLessThan(240000 / (level + 5)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
        SaveGame.SingletonRepository.Realms.Get<SorceryRealm>(),
        SaveGame.SingletonRepository.Realms.Get<NatureRealm>(),
        SaveGame.SingletonRepository.Realms.Get<ChaosRealm>(),
        SaveGame.SingletonRepository.Realms.Get<DeathRealm>(),
        SaveGame.SingletonRepository.Realms.Get<TarotRealm>(),
        SaveGame.SingletonRepository.Realms.Get<FolkRealm>(),
        SaveGame.SingletonRepository.Realms.Get<CorporealRealm>()
    };
    public override Realm[] AvailableSecondaryRealms => new Realm[] {
        SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
        SaveGame.SingletonRepository.Realms.Get<SorceryRealm>(),
        SaveGame.SingletonRepository.Realms.Get<NatureRealm>(),
        SaveGame.SingletonRepository.Realms.Get<ChaosRealm>(),
        SaveGame.SingletonRepository.Realms.Get<DeathRealm>(),
        SaveGame.SingletonRepository.Realms.Get<TarotRealm>(),
        SaveGame.SingletonRepository.Realms.Get<FolkRealm>(),
        SaveGame.SingletonRepository.Realms.Get<CorporealRealm>()
    };
    public override bool WorshipsADeity => true;

    protected override ItemFactory[] Outfit => new ItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<SwordDagger>(),
        SaveGame.SingletonRepository.ItemFactories.Get<BlackPrayersDeathBookItemFactory>()
    };
}