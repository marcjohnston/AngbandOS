// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MummifiedOrcMonsterRace : MonsterRace
{
    protected MummifiedOrcMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Mummified orc";

    public override int ArmorClass => 28;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is an orcish figure covered in wrappings.";
    public override bool Drop90 => true;
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mummified orc";
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 21;
    public override int Mexp => 56;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 1;
    public override int Sleep => 75;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Mummified  ";
    public override string SplitName3 => "    orc     ";
    public override bool Undead => true;
}
