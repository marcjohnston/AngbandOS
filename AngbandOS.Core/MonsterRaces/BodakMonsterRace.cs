// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BodakMonsterRace : MonsterRace
{
    protected BodakMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBallMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(SummonDemonMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerUSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Bodak";

    public override int ArmorClass => 68;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(FireAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(Exp20AttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a humanoid form composed of flames and hatred.";
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Bodak";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 750;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 90;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Bodak    ";
    public override bool TakeItem => true;
}
