// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SorcererMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseCriticalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBallMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlinkMonsterSpell),
        nameof(MonsterSpellsEnum.CreateTrapsMonsterSpell),
        nameof(MonsterSpellsEnum.DragonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.MonsterSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A human figure in robes, he moves with magically improved speed, and his hands are ablur with spell casting.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Sorcerer";
    public override int Hdice => 52;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override bool Male => true;
    public override int Mexp => 2150;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string? MultilineName => "Sorcerer";
}
