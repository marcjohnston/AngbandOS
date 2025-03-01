// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WoodSpiderMonsterRace : MonsterRace
{
    protected WoodSpiderMonsterRace(Game game) : base(game) { }


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override bool Animal => true;
    public override int ArmorClass => 16;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 3),
        (nameof(StingAttack), nameof(PoisonAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It scuttles towards you.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wood spider";
    public override bool Friends => true;
    public override int Hdice => 3;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override int LevelFound => 7;
    public override int Mexp => 15;
    public override int NoticeRange => 8;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string? MultilineName => "Wood\nspider";
    public override bool WeirdMind => true;
}
