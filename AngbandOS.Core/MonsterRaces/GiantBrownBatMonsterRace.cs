// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBrownBatMonsterRace : MonsterRace
{
    protected GiantBrownBatMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerBSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 15;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override string Description => "It screeches as it attacks.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant brown bat";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override int LevelFound => 6;
    public override int Mexp => 10;
    public override int NoticeRange => 10;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 130;
    public override string? MultilineName => "Giant\nbrown\nbat";
}
