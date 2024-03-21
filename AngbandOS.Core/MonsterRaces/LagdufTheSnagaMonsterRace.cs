// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LagdufTheSnagaMonsterRace : MonsterRace
{
    protected LagdufTheSnagaMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    public override string Name => "Lagduf, the Snaga";

    public override int ArmorClass => 32;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9)
    };
    public override bool BashDoor => true;
    public override string Description => "A captain of a regiment of weaker orcs, Lagduf keeps his troop in order with displays of excessive violence.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Lagduf, the Snaga";
    public override int Hdice => 19;
    public override int Hside => 10;
    public override int LevelFound => 8;
    public override bool Male => true;
    public override int Mexp => 80;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Lagduf   ";
    public override bool Unique => true;
}
