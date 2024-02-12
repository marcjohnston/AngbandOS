// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class RogueCharacterClass : BaseCharacterClass
{
    private RogueCharacterClass(SaveGame savedGame) : base(savedGame) { }
    public override int ID => 3;
    public override string Title => "Rogue";
    public override int[] AbilityBonus => new[] { 2, 1, -2, 3, 1, -1 };
    public override int BaseDisarmBonus => 45;
    public override int BaseDeviceBonus => 32;
    public override int BaseSaveBonus => 28;
    public override int BaseStealthBonus => 5;
    public override int BaseSearchBonus => 32;
    public override int BaseSearchFrequency => 24;
    public override int BaseMeleeAttackBonus => 60;
    public override int BaseRangedAttackBonus => 66;
    public override int DisarmBonusPerLevel => 15;
    public override int DeviceBonusPerLevel => 10;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 40;
    public override int RangedAttackBonusPerLevel => 10;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 25;
    public override string ClassSubName(Realm? realm)
    {
        switch (realm)
        {
            case SorceryRealm:
                return "Burglar";

            case DeathRealm:
                return "Assassin";

            case TarotRealm:
                return "Card Sharp";

            default:
                return "Thief";
        }
    }
    public override int PrimeStat => Ability.Dexterity;
    public override string[] Info => new string[] {
        "Stealth based characters who are adept at picking locks,",
        "searching, and disarming traps. Rogues can use stealth to",
        "their advantage in order to backstab sleeping or fleeing",
        "foes. They also dabble in INT based magic, learning spells",
        "from the Tarot, Sorcery, Death, or Folk realms."
   };
    public override int SpellWeight => 350;
    public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get(nameof(ArcaneCastingType));
    public override int SpellStat => Ability.Intelligence;
    public override int MaximumWeight => 30;
    public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get(nameof(RogueArtifactBias));
    public override int FromScrollWarriorArtifactBiasPercentageChance => 25;
    public override bool SenseInventoryTest(int level) => (0 != SaveGame.Rng.RandomLessThan(20000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        SaveGame.SingletonRepository.Realms.Get(nameof(SorceryRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(DeathRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(TarotRealm)),
        SaveGame.SingletonRepository.Realms.Get(nameof(FolkRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(BeginnersHandbookSorceryBookItemFactory),
        nameof(DaggerWeaponItemFactory),
        nameof(SoftLeatherSoftArmorItemFactory)
    };

    protected override void OutfitItem(Item item)
    {
        if (item.Factory.CategoryEnum == ItemTypeEnum.Sword && SaveGame.Studies<DeathRealm>())
        {
            item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(WeaponOfPoisoningRareItem));
        }
    }
}
