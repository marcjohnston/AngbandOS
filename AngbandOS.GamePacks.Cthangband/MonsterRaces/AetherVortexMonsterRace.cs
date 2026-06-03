// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AetherVortexMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ChaosBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ConfusionBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.DarkBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.LightningBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ForceBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.GravityBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.InertiaBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.LightBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.NexusBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.PlasmaBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ShardsBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.SoundBreathProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.TimeBreathProjectileMonsterSpell)
    };

    public override string SymbolName => nameof(LowerVSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 40;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(EngulfAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 5, 5),
        (nameof(EngulfAttack), nameof(AttackEffectsEnum.FireAttackEffect), 3, 3),
        (nameof(EngulfAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 3, 3),
        (nameof(EngulfAttack), nameof(AttackEffectsEnum.ColdAttackEffect), 3, 3)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "An awesome vortex of pure magic, power radiates from its frame.";
    public override bool EmptyMind => true;
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Aether vortex";
    public override int Hdice => 32;
    public override int Hside => 20;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override bool LightningAura => true;
    public override int Mexp => 4500;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override int BallAndBreatheProjectileBonusRadius => 1;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override int Sleep => 0;
    public override int Speed => 130;
    public override string? MultilineName => "Aether\nvortex";
}
