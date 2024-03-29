// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KarakalSpiritOfFireMonsterRace : MonsterRace
{
    protected KarakalSpiritOfFireMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBallMonsterSpell),
        nameof(PlasmaBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 50;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 6, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A towering fire elemental, Karakal burns everything beyond recognition.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Karakal, Spirit of Fire";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 38;
    public override bool Male => true;
    public override int Mexp => 3000;
    public override int NoticeRange => 12;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string? MultilineName => "Karakal";
    public override bool Unique => true;
}
