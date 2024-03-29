// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GibberingMoutherMonsterRace : MonsterRace
{
    protected GibberingMoutherMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheLightMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override int ArmorClass => 20;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrawlAttack), nameof(PoisonAttackEffect), 1, 4),
    };
    public override string Description => "A chaotic mass of pulsating flesh, mouths and eyes.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Gibbering mouther";
    public override int Hdice => 8;
    public override int Hside => 6;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 14;
    public override int Mexp => 20;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 15;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Gibbering\nmouther";
}
