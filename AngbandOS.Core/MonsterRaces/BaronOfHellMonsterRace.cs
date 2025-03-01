// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BaronOfHellMonsterRace : MonsterRace
{
    protected BaronOfHellMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(PlasmaBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperUSymbol);

    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override int ArmorClass => 130;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 11, 2),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 11, 2),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 11, 2),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "A minor demon lord with a goat's head, tough to kill.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Baron of hell";
    public override int Hdice => 150;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override bool Male => true;
    public override int Mexp => 900;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Baron\nof\nhell";
}
