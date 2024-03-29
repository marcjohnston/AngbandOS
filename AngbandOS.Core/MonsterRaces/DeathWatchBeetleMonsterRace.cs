// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DeathWatchBeetleMonsterRace : MonsterRace
{
    protected DeathWatchBeetleMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperKSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override bool Animal => true;
    public override int ArmorClass => 60;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 5, 4),
        new MonsterAttackDefinition(nameof(WailAttack), nameof(TerrifyAttackEffect), 5, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle that produces a chilling sound.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Death watch beetle";
    public override int Hdice => 25;
    public override int Hside => 12;
    public override int LevelFound => 31;
    public override int Mexp => 190;
    public override int NoticeRange => 16;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Death\nwatch\nbeetle";
    public override bool WeirdMind => true;
}
