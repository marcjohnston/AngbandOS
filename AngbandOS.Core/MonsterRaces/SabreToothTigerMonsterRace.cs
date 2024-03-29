// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SabreToothTigerMonsterRace : MonsterRace
{
    protected SabreToothTigerMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerFSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 50;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "A fierce and dangerous cat, its huge tusks and sharp claws would lacerate even the strongest armor.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Sabre-tooth tiger";
    public override int Hdice => 20;
    public override int Hside => 14;
    public override int LevelFound => 20;
    public override int Mexp => 120;
    public override int NoticeRange => 40;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Sabre-tooth\ntiger";
}
