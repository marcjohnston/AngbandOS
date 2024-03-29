// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GorgimeraMonsterRace : MonsterRace
{
    protected GorgimeraMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override int ArmorClass => 55;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(FireAttackEffect), 1, 3),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(ParalyzeAttackEffect), 2, 4),
        new MonsterAttackDefinition(nameof(ButtAttack), nameof(HurtAttackEffect), 1, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "It has 3 heads - gorgon, goat and dragon - all attached to a lion's body.";
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Gorgimera";
    public override int Hdice => 25;
    public override int Hside => 20;
    public override bool ImmuneFire => true;
    public override int LevelFound => 27;
    public override int Mexp => 200;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Gorgimera";
}
