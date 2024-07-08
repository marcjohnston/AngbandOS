// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NightLizardMonsterRace : MonsterRace
{
    protected NightLizardMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperRSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 16;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 6),
    };
    public override string Description => "It is a black lizard with overlapping scales and a powerful jaw.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Night lizard";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 7;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Night\nlizard";
}
