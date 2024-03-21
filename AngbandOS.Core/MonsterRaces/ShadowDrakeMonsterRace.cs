// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShadowDrakeMonsterRace : MonsterRace
{
    protected ShadowDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(HasteMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Shadow drake";

    public override bool Animal => true;
    public override int ArmorClass => 50;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(ColdAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(ColdAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(ColdAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a dragon-like form wrapped in shadow. Glowing red eyes shine out in the dark.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Shadow drake";
    public override int Hdice => 20;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool Invisible => true;
    public override int LevelFound => 30;
    public override int Mexp => 700;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Shadow   ";
    public override string SplitName3 => "   drake    ";
    public override bool TakeItem => true;
}
