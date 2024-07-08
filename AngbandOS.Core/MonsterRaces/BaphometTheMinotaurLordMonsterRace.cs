// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BaphometTheMinotaurLordMonsterRace : MonsterRace
{
    protected BaphometTheMinotaurLordMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(Arrow7D6MonsterSpell),
        nameof(BreatheForceMonsterSpell),
        nameof(LightningBallMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(SlowMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 120;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ButtAttack), nameof(HurtAttackEffect), 12, 13),
        (nameof(ButtAttack), nameof(HurtAttackEffect), 12, 13),
        (nameof(HitAttack), nameof(HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(HurtAttackEffect), 10, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "A fearsome bull-headed demon, Baphomet swings a mighty axe as he curses all that defy him.";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Baphomet, the Minotaur Lord";
    public override int Hdice => 35;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 51;
    public override bool Male => true;
    public override int Mexp => 18000;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override int Rarity => 4;
    public override int Sleep => 30;
    public override int Speed => 130;
    public override string? MultilineName => "Baphomet";
    public override bool Unique => true;
}
