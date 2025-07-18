// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CantorasTheSkeletalLordMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.IceBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell),
        nameof(MonsterSpellsEnum.WaterBallMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 120;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 5)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A legion of evil undead druj animating the skeleton of a once mighty sorcerer. His power is devastating and his speed unmatched in the underworld. Flee his wrath!";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 1;
    public override int FreqSpell => 1;
    public override string FriendlyName => "Cantoras, the Skeletal Lord";
    public override int Hdice => 75;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 84;
    public override bool Male => true;
    public override int Mexp => 45000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 140;
    public override string? MultilineName => "Cantoras";
    public override bool Undead => true;
    public override bool Unique => true;
}
