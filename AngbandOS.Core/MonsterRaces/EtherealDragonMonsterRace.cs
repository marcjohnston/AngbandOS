// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EtherealDragonMonsterRace : MonsterRace
{
    protected EtherealDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfusionBreatheBallMonsterSpell),
        nameof(DarkBreatheBallMonsterSpell),
        nameof(LightBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 6, 12),
    };
    public override string Description => "A huge dragon emanating from the elemental plains, the ethereal dragon is a master of light and dark. Its form disappears from sight as it cloaks itself in unearthly shadows.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Ethereal dragon";
    public override int Hdice => 21;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 43;
    public override int Mexp => 11000;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 15;
    public override int Speed => 120;
    public override string? MultilineName => "Ethereal\ndragon";
}
