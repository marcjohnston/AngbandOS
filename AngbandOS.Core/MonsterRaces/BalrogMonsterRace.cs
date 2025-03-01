// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BalrogMonsterRace : MonsterRace
{
    protected BalrogMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(DemonSummonMonsterSpell),
        nameof(HiUndeadSummonMonsterSpell),
        nameof(UndeadSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperUSymbol);

    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;

    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 80;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(FireAttackEffect), 2, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 6),
        (nameof(HitAttack), nameof(FireAttackEffect), 6, 2),
        (nameof(HitAttack), nameof(HurtAttackEffect), 6, 5)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a massive humanoid demon wreathed in flames.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Balrog";
    public override int Hdice => 30;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override bool KillWall => true;
    public override int LevelFound => 50;
    public override int Mexp => 10000;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Balrog";
}
