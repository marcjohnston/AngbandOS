// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WarTrollMonsterRace : MonsterRace
{
    protected WarTrollMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperTSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A massive troll, equipped with a scimitar and heavy armor.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "War troll";
    public override bool Friends => true;
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override int Mexp => 800;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string? MultilineName => "War\ntroll";
    public override bool Troll => true;
}
