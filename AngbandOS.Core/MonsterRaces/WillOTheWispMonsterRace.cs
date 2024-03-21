// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WillOTheWispMonsterRace : MonsterRace
{
    protected WillOTheWispMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseSeriousWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.BrightTurquoise;
    public override string Name => "Will o' the wisp";

    public override int ArmorClass => 150;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9)
    };
    public override string Description => "A strange ball of glowing light. It disappears and reappears and seems to draw you to it. You seem somehow compelled to stand still and watch its strange dancing motion.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Will o' the wisp";
    public override int Hdice => 20;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 37;
    public override int Mexp => 500;
    public override bool Nonliving => true;
    public override int NoticeRange => 30;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "    Will    ";
    public override string SplitName2 => "   o' the   ";
    public override string SplitName3 => "    wisp    ";
}
