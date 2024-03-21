// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CarcharothTheJawsOfThirstMonsterRace : MonsterRace
{
    protected CarcharothTheJawsOfThirstMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonHoundMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Carcharoth, the Jaws of Thirst";

    public override bool Animal => true;
    public override int ArmorClass => 110;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 4, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 4, 4)
    };
    public override bool BashDoor => true;
    public override string Description => "The first guard of Angband, Carcharoth, also known as 'The Red Maw', is the largest wolf to ever walk the earth. He is highly intelligent and a deadly opponent in combat.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Carcharoth, the Jaws of Thirst";
    public override int Hdice => 75;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 92;
    public override bool Male => true;
    public override int Mexp => 40000;
    public override bool MoveBody => true;
    public override int NoticeRange => 80;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Carcharoth ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
