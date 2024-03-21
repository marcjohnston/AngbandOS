// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CaveOrcMonsterRace : MonsterRace
{
    protected CaveOrcMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Cave orc";

    public override int ArmorClass => 32;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "He is often found in huge numbers in deep caves.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave orc";
    public override bool Friends => true;
    public override int Hdice => 11;
    public override int Hside => 9;
    public override bool HurtByLight => true;
    public override int LevelFound => 7;
    public override bool Male => true;
    public override int Mexp => 20;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Cave    ";
    public override string SplitName3 => "    orc     ";
}
