// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AirSpiritMonsterRace : MonsterRace
{
    protected AirSpiritMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.Diamond;
    public override string Name => "Air spirit";

    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A whirlwind of sentient air.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Air spirit";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 12;
    public override int Mexp => 40;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Air     ";
    public override string SplitName3 => "   spirit   ";
}
