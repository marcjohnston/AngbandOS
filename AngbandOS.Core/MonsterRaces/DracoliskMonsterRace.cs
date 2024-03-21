// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DracoliskMonsterRace : MonsterRace
{
    protected DracoliskMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(BreatheNetherMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    public override string Name => "Dracolisk";

    public override bool Animal => true;
    public override int ArmorClass => 120;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 5, 12),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 5, 12),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 8, 8),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(ParalyzeAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "A mixture of dragon and basilisk, the dracolisk stares at you with deep piercing eyes, its evil breath burning the ground where it stands.";
    public override bool Dragon => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Dracolisk";
    public override int Hdice => 35;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 46;
    public override int Mexp => 14000;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Dracolisk  ";
}
