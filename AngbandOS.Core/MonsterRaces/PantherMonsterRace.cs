// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PantherMonsterRace : MonsterRace
{
    protected PantherMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerFSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A large black cat, stalking you with intent. It thinks you're its next meal.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Panther";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override int LevelFound => 10;
    public override int Mexp => 25;
    public override int NoticeRange => 40;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Panther";
}
