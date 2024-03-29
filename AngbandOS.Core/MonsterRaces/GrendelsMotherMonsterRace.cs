// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GrendelsMotherMonsterRace : MonsterRace
{
    protected GrendelsMotherMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperOSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 100;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "She taught her son everything he knows.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Grendel's mother";
    public override bool Giant => true;
    public override int Hdice => 25;
    public override int Hside => 100;
    public override bool ImmunePoison => true;
    public override int LevelFound => 28;
    public override int Mexp => 1500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Grendel's\nmother";
    public override bool Unique => true;
}
