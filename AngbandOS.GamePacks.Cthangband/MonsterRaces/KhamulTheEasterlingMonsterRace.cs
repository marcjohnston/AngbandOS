// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KhamulTheEasterlingMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseCriticalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.KinSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportLevelMonsterSpell)
    };

    public override string SymbolName => nameof(UpperWSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A warrior-king of the East. Khamul is a powerful opponent, his skill in combat awesome and his form twisted by evil cunning.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Khamul the Easterling";
    public override int Hdice => 35;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 53;
    public override bool Male => true;
    public override int Mexp => 50000;
    public override bool MoveBody => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Khamul\nthe\nEasterling";
    public override bool Undead => true;
    public override bool Unique => true;
}
