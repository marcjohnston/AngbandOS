// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FoolhardyAdolescentMonsterRace : MonsterRace
{
    protected FoolhardyAdolescentMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 15;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He wants to kill a hero to prove that he's hard.";
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Foolhardy adolescent";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 50;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override int Sleep => 4;
    public override int Speed => 109;
    public override string? MultilineName => "Foolhardy\nadolescent";
    public override bool TakeItem => true;
}
