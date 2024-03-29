// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class UglukTheUrukMonsterRace : MonsterRace
{
    protected UglukTheUrukMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 90;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "Another of Morgoth's servants, this orc is strong and cunning. He is ugly and scarred from many power struggles.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Ugluk, the Uruk";
    public override int Hdice => 64;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 550;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Ugluk";
    public override bool Unique => true;
}
