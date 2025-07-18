// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BoneGolemMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseCriticalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.BrightBeige;
    
    public override int ArmorClass => 170;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 6, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 6, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 4, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A skeletal form, black as night, constructed from the bones of its previous victims and inhabited by the soul of a lich of great power.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Bone golem";
    public override int Hdice => 35;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillWall => true;
    public override int LevelFound => 71;
    public override int Mexp => 23000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Bone\ngolem";
    public override bool Undead => true;
}
