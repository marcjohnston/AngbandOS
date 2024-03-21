// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ManticoreMonsterRace : MonsterRace
{
    protected ManticoreMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(Arrow7D6MonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Manticore";

    public override int ArmorClass => 15;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 4)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a winged lion's body with a human torso and a tail covered in vicious spikes.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Manticore";
    public override int Hdice => 25;
    public override int Hside => 10;
    public override int LevelFound => 30;
    public override int Mexp => 300;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Manticore  ";
}
