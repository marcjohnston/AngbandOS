// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GhoulMonsterRace : MonsterRace
{
    protected GhoulMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(HoldMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(PoisonAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(ParalyzeAttackEffect), 1, 5),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "Flesh is falling off in chunks from this decaying abomination.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Ghoul";
    public override bool Friends => true;
    public override int Hdice => 15;
    public override int Hside => 9;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 26;
    public override int Mexp => 95;
    public override int NoticeRange => 30;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Ghoul";
    public override bool Undead => true;
}
