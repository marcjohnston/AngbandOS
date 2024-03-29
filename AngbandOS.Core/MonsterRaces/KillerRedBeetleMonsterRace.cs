// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerRedBeetleMonsterRace : MonsterRace
{
    protected KillerRedBeetleMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperKSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 45;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(SpitAttack), nameof(FireAttackEffect), 4, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle wreathed in flames.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer red beetle";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 27;
    public override int Mexp => 95;
    public override int NoticeRange => 14;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Killer\nred\nbeetle";
    public override bool WeirdMind => true;
}
