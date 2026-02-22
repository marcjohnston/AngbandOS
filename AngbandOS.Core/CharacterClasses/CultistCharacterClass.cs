// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class CultistCharacterClass : CharacterClass
{
    private CultistCharacterClass(Game savedGame) : base(savedGame) { }
    protected override string EnhancementBindingKey => nameof(CultistCharacterClassItemEnhancement);
    public override int ID => 12;
    public override string Title => "Cultist";
    public override bool ReceivesLevelRewards => true;
    public override int? InstantChaosResistanceLevel => 20;
    public override bool RenderChaosMessageForWieldingUnpriestlyWeapon => true;
    public override int UnpriestlyWeaponAdditionalFailureChance => 25;
    public override bool HasPatron => true;
    public override int UseDevice => 36;
    public override int? SpellMinFailChance => 5;
    public override int SavingThrow => 32;
    public override int Stealth => 1;
    public override int Search => 16;
    public override int BaseSearchFrequency => 18;
    public override int MeleeToHit => 30;
    public override int RangedToHit => 20;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 13;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 15;
    public override int RangedAttackBonusPerLevel => 15;
    public override int HitDieBonus => 0;
    public override int ExperienceFactor => 30;
    public override Ability PrimeStat => Game.IntelligenceAbility;
    public override string[] Info => new string[] {
        "INT based spell casters, who use Chaos and another realm",
        "of their choice. Can't wield weapons except for powerful",
        "chaos blades. Learn to resist chaos (at lvl 20). Have a",
        "cult patron who will randomly give them rewards or",
        "punishments as they increase in level."
    };
    public override int SpellWeight => 300;

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
    public override int MaximumMeleeAttacksPerRound(int level) => 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 2;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(240000 / (level + 5)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm))
    };
    public override Realm[] AvailableSecondaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(LifeRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(SorceryRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(NatureRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(FolkRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(CorporealRealm))
    };
    public override bool WorshipsADeity => true;

    public override Bonuses? GetBonusesForMeleeWeapon(Item? oPtr)
    {
        // Cultists that are NOT wielding the a blade of chaos lose bonuses for being an unpriestly weapon.
        if (oPtr != null)
        {
            if (!oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ChaoticAttribute)).Get())
            {
                return new Bonuses()
                {
                    AttackBonus = -10,
                    DamageBonus = -10,
                    DisplayedAttackBonus = -10,
                    DisplayedDamageBonus = -10,
                    HasUnpriestlyWeapon = true,
                };
            }
        }
        return null;
    }

    public override void CalcBonuses()
    {
        if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.HasChaosResistance = true;
        }
    }
}
