// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackReaverMonsterRace : MonsterRace
{
    protected BlackReaverMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperUSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 90;

    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 50),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 50),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 50),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 50)
    };
    public override bool Demon => true;
    public override string Description => "Clicking metal steps announce the arrival of this creature, A powerful undead warrior possessed by a major demon, it is unstoppable.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Black reaver";
    public override int Hdice => 70;
    public override int Hside => 101;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 77;
    public override int Mexp => 30000;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 90;
    public override int Speed => 120;
    public override string? MultilineName => "Black\nreaver";
    public override bool Undead => true;
}
