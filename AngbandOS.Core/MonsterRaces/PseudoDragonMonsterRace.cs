// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PseudoDragonMonsterRace : MonsterRace
{
    protected PseudoDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheDarkMonsterSpell),
        nameof(BreatheLightMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A small relative of the dragon that inhabits dark caves.";
    public override bool Dragon => true;
    public override bool Drop60 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Pseudo dragon";
    public override int Hdice => 20;
    public override int Hside => 10;
    public override int LevelFound => 10;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Pseudo\ndragon";
}
