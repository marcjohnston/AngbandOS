// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosDrakeMonsterRace : MonsterRace
{
    protected ChaosDrakeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBreatheBallMonsterSpell),
        nameof(DisenchantBreatheBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 6),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A dragon twisted by the forces of chaos. It seems first ugly, then fair, as its form shimmers and changes in front of your eyes.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Chaos drake";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 700;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistDisenchant => true;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Chaos\ndrake";
}
