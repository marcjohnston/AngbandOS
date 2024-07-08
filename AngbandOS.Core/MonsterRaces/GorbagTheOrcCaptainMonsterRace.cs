// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GorbagTheOrcCaptainMonsterRace : MonsterRace
{
    protected GorbagTheOrcCaptainMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "A gruesomely ugly but cunning orc, his eyes regard you with hatred. His powerful arms flex menacingly as he advances.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Gorbag, the Orc Captain";
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 18;
    public override bool Male => true;
    public override int Mexp => 400;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Gorbag";
    public override bool Unique => true;
}
