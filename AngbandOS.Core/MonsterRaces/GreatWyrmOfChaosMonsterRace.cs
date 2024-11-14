// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfChaosMonsterRace : MonsterRace
{
    protected GreatWyrmOfChaosMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBreatheBallMonsterSpell),
        nameof(DisenchantBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonDragonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 170;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 8, 14)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A massive dragon of changing form. As you watch, it appears first fair and then foul. Its body is twisted by chaotic forces as it strives to stay real. Its very existence distorts the universe around it.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Chaos";
    public override int Hdice => 45;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 67;
    public override int Mexp => 29000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Great\nWyrm of\nChaos";
}
