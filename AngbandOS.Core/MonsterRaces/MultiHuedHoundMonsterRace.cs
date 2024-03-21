// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MultiHuedHoundMonsterRace : MonsterRace
{
    protected MultiHuedHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheAcidMonsterSpell),
        nameof(BreatheColdMonsterSpell),
        nameof(BreatheLightningMonsterSpell),
        nameof(BreatheFireMonsterSpell),
        nameof(BreathePoisonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Multi-hued hound";

    public override bool Animal => true;
    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 6),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 4, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 4, 4)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "Shimmering in rainbow hues, this hound is beautiful and deadly. ";
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Multi-hued hound";
    public override bool Friends => true;
    public override int Hdice => 30;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 600;
    public override int NoticeRange => 25;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Multi-hued ";
    public override string SplitName3 => "   hound    ";
}
