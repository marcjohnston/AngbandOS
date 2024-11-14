// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NexusVortexMonsterRace : MonsterRace
{
    protected NexusVortexMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(NexusBreatheBallMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerVSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    
    public override int ArmorClass => 40;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(EngulfAttack), nameof(HurtAttackEffect), 5, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A maelstrom of potent magical energy.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Nexus vortex";
    public override int Hdice => 32;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 37;
    public override int Mexp => 800;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override bool ResistNexus => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Nexus\nvortex";
}
