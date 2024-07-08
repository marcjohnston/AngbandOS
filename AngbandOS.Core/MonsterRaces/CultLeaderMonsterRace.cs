// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CultLeaderMonsterRace : MonsterRace
{
    protected CultLeaderMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonCthuloidMonsterSpell),
        nameof(SummonMonsterMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightTurquoise;
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "An evil priest, dressed all in black. Deadly spells hit you at an alarming rate as his black spiked mace rains down Attack after Attack on your pitiful frame.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Cult leader";
    public override int Hdice => 52;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override bool Male => true;
    public override int Mexp => 1800;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Cult\nleader";
}
