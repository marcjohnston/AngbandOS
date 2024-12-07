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
    private PriestCharacterClass(Game savedGame) : base(savedGame) { }
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
    public override int PrimeStat => AbilityEnum.Wisdom;
    public override string[] Info => new string[] {
        "Devout followers of the Great Ones, Priests use WIS based",
        "spell casting. They may choose either Life or Death magic,",
        "and another realm of their choice. Priests can't use edged",
        "weapons unless they are blessed, but can use any armor."
    };
    public override int SpellWeight => 350;

    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers for magic.
    /// </summary>
    public override string SpellNoun => "prayer";

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers.
    /// </summary>
    public override string MagicType => "prayer";

    /// <summary>
    /// Returns false, because the diving casting type does not allow the player to choose which prayer to learn.
    /// </summary>
    public override bool CanChooseSpellToStudy => false;

    /// <summary>
    /// Returns "recite" because the divine casting type recites prayers; as opposed to casting spells.
    /// </summary>
    public override string CastVerb => "recite";

    /// <summary>
    /// Returns true, because the Priest class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    public override int SpellStat => AbilityEnum.Wisdom;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(10000 / ((level * level) + 40)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(LifeRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm))
    };
    public override Realm[] AvailableSecondaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(NatureRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(FolkRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(CorporealRealm))
    };
    public override bool WorshipsADeity => true;

    public override God? DefaultDeity(Realm? realm)
    {
        switch (realm)
        {
            case NatureRealm:
                return Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod));

            case FolkRealm:
                return Game.SingletonRepository.Get<God>(nameof(ZoKalarGod));

            case ChaosRealm:
                return Game.SingletonRepository.Get<God>(nameof(NathHorthahGod));

            case CorporealRealm:
                return Game.SingletonRepository.Get<God>(nameof(LobonGod));

            case TarotRealm:
                return Game.SingletonRepository.Get<God>(nameof(TamashGod));

            default:
                return null;
        }
    }

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(MaceHaftedWeaponItemFactory),
    };
}
