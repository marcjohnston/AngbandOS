// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MatureBlackDragonMonsterRace : MonsterRace
{
    protected MatureBlackDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBreatheBallMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 55;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "A large dragon, with scales of deepest black.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Mature black dragon";
    public override int Hdice => 46;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 37;
    public override int Mexp => 1350;
    public override int NoticeRange => 20;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Mature\nblack\ndragon";
}
