// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LargeKoboldMonsterRace : MonsterRace
{
    protected LargeKoboldMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerKSymbol);
    
    public override int ArmorClass => 32;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "It a man-sized figure with the all too recognizable face of a kobold.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Large kobold";
    public override int Hdice => 13;
    public override int Hside => 9;
    public override bool ImmunePoison => true;
    public override int LevelFound => 5;
    public override int Mexp => 25;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Large\nkobold";
}
