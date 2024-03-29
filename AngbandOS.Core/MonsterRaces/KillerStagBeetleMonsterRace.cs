// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerStagBeetleMonsterRace : MonsterRace
{
    protected KillerStagBeetleMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperKSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override bool Animal => true;
    public override int ArmorClass => 55;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle with vicious claws.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer stag beetle";
    public override int Hdice => 20;
    public override int Hside => 8;
    public override int LevelFound => 22;
    public override int Mexp => 80;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Killer\nstag\nbeetle";
    public override bool WeirdMind => true;
}
