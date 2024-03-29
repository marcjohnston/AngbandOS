// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CopperheadSnakeMonsterRace : MonsterRace
{
    protected CopperheadSnakeMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperJSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It has a copper head and sharp venomous fangs.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Copperhead snake";
    public override int Hdice => 4;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override int LevelFound => 5;
    public override int Mexp => 15;
    public override int NoticeRange => 6;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string? MultilineName => "Copperhead\nsnake";
}
