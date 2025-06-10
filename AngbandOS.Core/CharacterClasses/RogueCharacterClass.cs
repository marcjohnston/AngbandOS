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
    private RogueCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 3;
    public override string Title => "Rogue";
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
    public override Ability PrimeStat => Game.DexterityAbility;
    public override string[] Info => new string[] {
        "Stealth based characters who are adept at picking locks,",
        "searching, and disarming traps. Rogues can use stealth to",
        "their advantage in order to backstab sleeping or fleeing",
        "foes. They also dabble in INT based magic, learning spells",
        "from the Tarot, Sorcery, Death, or Folk realms."
   };
    public override int SpellWeight => 350;


    /// <summary>
    /// Returns true, because arcane spell casting movement can be encumbered by the spell weight of the players armor.
    /// </summary>
    public override bool WeightEncumbersMovement => true;


    /// <summary>
    /// Returns true, because arcane spell casting requires the players hands to be unrestricted for spell casting.
    /// </summary>
    public override bool CoveredHandsRestrictCasting => true;


    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;
    public override Ability SpellStat => Game.IntelligenceAbility;
    public override int MaximumWeight => 30;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
    public override int FromScrollWarriorArtifactBiasPercentageChance => 25;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(20000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(SorceryRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(FolkRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(DaggerWeaponItemFactory),
        nameof(SoftLeatherSoftArmorItemFactory)
    };

    protected override void OutfitItem(Item item)
    {
        if (item.ItemClass == Game.SingletonRepository.Get<ItemClass>(nameof(SwordsItemClass)) && Game.Studies(nameof(DeathRealm)))
        {
            item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfPoisoningItemEnhancement));
        }
    }
}
