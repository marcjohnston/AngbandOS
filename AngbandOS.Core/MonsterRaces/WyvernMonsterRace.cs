// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WyvernMonsterRace : MonsterRace
{
    protected WyvernMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 65;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
        (nameof(StingAttack), nameof(PoisonAttackEffect), 1, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A fast-moving and deadly dragonian animal. Beware its poisonous sting!";
    public override bool Dragon => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wyvern";
    public override int Hdice => 100;
    public override int Hside => 5;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override int Mexp => 360;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Wyvern";
}
