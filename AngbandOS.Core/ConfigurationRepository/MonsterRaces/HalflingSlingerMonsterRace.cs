// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HalflingSlingerMonsterRace : MonsterRace
{
    protected HalflingSlingerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(Arrow7D6MonsterSpell)
    };

    protected override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Halfling slinger";

    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
    };
    public override string Description => "A rebel halfling who has rejected the halfling tradition of archery.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Halfling slinger";
    public override bool Friends => true;
    public override int Hdice => 30;
    public override int Hside => 9;
    public override bool ImmuneCold => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 35;
    public override bool Male => true;
    public override int Mexp => 330;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Halfling  ";
    public override string SplitName3 => "  slinger   ";
}
