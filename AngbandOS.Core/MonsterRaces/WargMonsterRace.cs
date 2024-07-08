// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WargMonsterRace : MonsterRace
{
    protected WargMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large wolf with eyes full of cunning.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Warg";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 8;
    public override int LevelFound => 14;
    public override int Mexp => 40;
    public override int NoticeRange => 20;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string? MultilineName => "Warg";
}
