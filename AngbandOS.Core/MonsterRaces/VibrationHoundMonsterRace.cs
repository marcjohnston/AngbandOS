// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VibrationHoundMonsterRace : MonsterRace
{
    protected VibrationHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheSoundMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.BrightOrange;
    public override string Name => "Vibration hound";

    public override bool Animal => true;
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "A blurry canine form which seems to be moving as fast as the eye can follow. You can feel the earth resonating beneath your feet.";
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Vibration hound";
    public override bool Friends => true;
    public override int Hdice => 25;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 27;
    public override int Mexp => 250;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Vibration  ";
    public override string SplitName3 => "   hound    ";
}
