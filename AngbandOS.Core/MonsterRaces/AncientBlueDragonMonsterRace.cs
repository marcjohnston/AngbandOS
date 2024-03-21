// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientBlueDragonMonsterRace : MonsterRace
{
    protected AncientBlueDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheLightningMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "Ancient blue dragon";

    public override int ArmorClass => 80;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 4, 8),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 4, 8),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(EatGoldAttackEffect), 5, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form. Lightning crackles along its length.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Ancient blue dragon";
    public override int Hdice => 70;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1500;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "  Ancient   ";
    public override string SplitName2 => "    blue    ";
    public override string SplitName3 => "   dragon   ";
}
