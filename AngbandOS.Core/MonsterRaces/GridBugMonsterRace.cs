// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GridBugMonsterRace : MonsterRace
{
    protected GridBugMonsterRace(Game game) : base(game) { }


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperISymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    
    public override bool Animal => true;
    public override int ArmorClass => 2;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(ElectricityAttackEffect), 1, 4),
    };
    public override string Description => "A strange electric bug.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Grid bug";
    public override bool Friends => true;
    public override int Hdice => 2;
    public override int Hside => 4;
    public override bool ImmuneFear => true;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 1;
    public override int Mexp => 2;
    public override int NoticeRange => 10;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Grid\nbug";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
