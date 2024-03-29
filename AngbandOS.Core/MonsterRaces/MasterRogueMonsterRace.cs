// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MasterRogueMonsterRace : MonsterRace
{
    protected MasterRogueMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 8),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 8),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(EatGoldAttackEffect), 4, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A thief of great power and shifty speed.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Master rogue";
    public override int Hdice => 15;
    public override int Hside => 9;
    public override int LevelFound => 23;
    public override bool Male => true;
    public override int Mexp => 110;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string? MultilineName => "Master\nrogue";
    public override bool TakeItem => true;
}
