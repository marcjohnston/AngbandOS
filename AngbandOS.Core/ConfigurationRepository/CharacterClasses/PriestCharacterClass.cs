// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class PriestCharacterClass : BaseCharacterClass
{
    private PriestCharacterClass(SaveGame savedGame) : base(savedGame) { }
    public override int ID => 2;
    public override string Title => "Priest";
    public override int[] AbilityBonus => new[] { -1, -3, 3, -1, 0, 2 };
    public override int BaseDisarmBonus => 25;
    public override int BaseDeviceBonus => 30;
    public override int BaseSaveBonus => 32;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 16;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 48;
    public override int BaseRangedAttackBonus => 36;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 10;
    public override int SaveBonusPerLevel => 12;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 2;
    public override int ExperienceFactor => 20;
    public override string ClassSubName(Realm? realm)
    {
        switch (realm)
        {
            case DeathRealm:
                return "Exorcist";
            default:
                return "Priest";
        }
    }
    public override int PrimeStat => Ability.Wisdom;
    public override string[] Info => new string[] {
        "Devout followers of the Great Ones, Priests use WIS based",
        "spell casting. They may choose either Life or Death magic,",
        "and another realm of their choice. Priests can't use edged",
        "weapons unless they are blessed, but can use any armor."
    };
    public override int SpellWeight => 350;
    public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get(nameof(DivineCastingType));
    public override int SpellStat => Ability.Wisdom;
    public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get(nameof(PriestlyArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != SaveGame.RandomLessThan(10000 / ((level * level) + 40)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        SaveGame.SingletonRepository.Realms.Get(nameof(LifeRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(DeathRealm))
    };
    public override Realm[] AvailableSecondaryRealms => new Realm[] {
        SaveGame.SingletonRepository.Realms.Get(nameof(NatureRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(ChaosRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(TarotRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(FolkRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(CorporealRealm))
    };
    public override bool WorshipsADeity => true;

    public override GodName DefaultDeity(Realm? realm)
    {
        switch (realm)
        {
            case NatureRealm:
                return GodName.Hagarg_Ryonis;

            case FolkRealm:
                return GodName.Zo_Kalar;

            case ChaosRealm:
                return GodName.Nath_Horthah;

            case CorporealRealm:
                return GodName.Lobon;

            case TarotRealm:
                return GodName.Tamash;

            default:
                return GodName.None;
        }
    }

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(BeginnersHandbookSorceryBookItemFactory),
        nameof(MaceHaftedWeaponItemFactory),
        nameof(BlackPrayersDeathBookItemFactory)
    };
}
