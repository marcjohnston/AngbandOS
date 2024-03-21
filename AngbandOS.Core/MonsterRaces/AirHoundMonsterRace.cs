// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AirHoundMonsterRace : MonsterRace
{
    protected AirHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreathePoisonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Air hound";

    public override bool Animal => true;
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 8),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 8),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "Swirling vapours surround this beast as it floats towards you, seemingly walking on air. Noxious gases sting your throat.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Air hound";
    public override bool Friends => true;
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override int Mexp => 200;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Air     ";
    public override string SplitName3 => "   hound    ";
}
