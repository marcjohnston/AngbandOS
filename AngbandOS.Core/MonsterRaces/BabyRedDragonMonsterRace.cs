// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BabyRedDragonMonsterRace : MonsterRace
{
    protected BabyRedDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBreatheBallMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "This hatchling dragon is still soft, its eyes unaccustomed to light and its scales a pale red.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Baby red dragon";
    public override int Hdice => 11;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 9;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string? MultilineName => "Baby\nred\ndragon";
}
