// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NibelungMonsterRace : MonsterRace
{
    protected NibelungMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Silver;
    
    public override int ArmorClass => 12;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        (nameof(TouchAttack), nameof(EatGoldAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "Night dwarfs collecting new riches for their collection. ";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Nibelung";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 4;
    public override bool HurtByLight => true;
    public override int LevelFound => 6;
    public override bool Male => true;
    public override int Mexp => 6;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override bool ResistDisenchant => true;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Nibelung";
    public override bool TakeItem => true;
}
