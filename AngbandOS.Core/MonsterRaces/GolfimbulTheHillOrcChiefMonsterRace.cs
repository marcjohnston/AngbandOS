// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GolfimbulTheHillOrcChiefMonsterRace : MonsterRace
{
    protected GolfimbulTheHillOrcChiefMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Copper;
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 10),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "A leader of a band of raiding orcs, he picks on hobbits.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Golfimbul, the Hill Orc Chief";
    public override int Hdice => 24;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 12;
    public override bool Male => true;
    public override int Mexp => 230;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Golfimbul";
    public override bool Unique => true;
}
