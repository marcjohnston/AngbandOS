// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GothmogTheHighCaptainOfBalrogsMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DisintegrationBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.DemonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.KinSummonMonsterSpell),
        nameof(MonsterSpellsEnum.ReaverSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperUSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 140;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.FireAttackEffect), 9, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.FireAttackEffect), 9, 12),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 8, 12),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.DrainStaffChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.DrainWandChargesAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "Gothmog is the Chief Balrog in Morgoth's personal guard. He is renowned for slaying Ecthelion the Warder of the Gates and he has never been defeated in combat. With his whip of flame and awesome fiery breath he saved his master from Ungoliant's rage.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Gothmog, the High Captain of Balrogs";
    public override int Hdice => 80;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool KillWall => true;
    public override int LevelFound => 95;
    public override bool Male => true;
    public override int Mexp => 43000;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 130;
    public override string? MultilineName => "Gothmog";
    public override bool Unique => true;
}
