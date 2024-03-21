// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NinjaMonsterRace : MonsterRace
{
    protected NinjaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Ninja";

    public override int ArmorClass => 60;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(PoisonAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(LoseStrAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(LoseConAttackEffect), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A humanoid clothed in black who moves with blinding speed.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Ninja";
    public override int Hdice => 13;
    public override int Hside => 12;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override bool Male => true;
    public override int Mexp => 300;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Ninja    ";
}
