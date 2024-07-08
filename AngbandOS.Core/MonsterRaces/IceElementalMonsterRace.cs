// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IceElementalMonsterRace : MonsterRace
{
    protected IceElementalMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ColdBallMonsterSpell),
        nameof(IceBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperESymbol);
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(ColdAttackEffect), 1, 3),
        (nameof(HitAttack), nameof(HurtAttackEffect), 4, 6),
        (nameof(BiteAttack), nameof(ColdAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a towering glacier of ice.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Ice elemental";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 36;
    public override int Mexp => 650;
    public override int NoticeRange => 10;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 90;
    public override int Speed => 110;
    public override string? MultilineName => "Ice\nelemental";
}
