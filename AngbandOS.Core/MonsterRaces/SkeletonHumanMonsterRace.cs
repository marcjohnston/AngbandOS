// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SkeletonHumanMonsterRace : MonsterRace
{
    protected SkeletonHumanMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.BrightBeige;
    
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is an animated human skeleton.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Skeleton human";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 12;
    public override int Mexp => 38;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Skeleton\nhuman";
    public override bool Undead => true;
}
