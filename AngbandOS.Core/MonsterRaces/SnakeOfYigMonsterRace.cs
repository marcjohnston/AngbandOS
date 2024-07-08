// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SnakeOfYigMonsterRace : MonsterRace
{
    protected SnakeOfYigMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreathePoisonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperJSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override bool Animal => true;
    public override int ArmorClass => 80;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 3, 12),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 3, 12),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 3, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant snake that drips with poison.";
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Snake of Yig";
    public override bool Friends => true;
    public override int Hdice => 48;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 83;
    public override int Mexp => 600;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool RandomMove25 => true;
    public override int Rarity => 4;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Snake\nof\nYig";
}
