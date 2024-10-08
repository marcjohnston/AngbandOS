// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShamanMonsterRace : MonsterRace
{
    protected ShamanMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(LightningBoltMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(HasteMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 10;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A man with powerful spirit friends...";
    public override bool Drop_1D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Shaman";
    public override int Hdice => 12;
    public override int Hside => 12;
    public override bool ImmuneFear => true;
    public override int LevelFound => 13;
    public override bool Male => true;
    public override int Mexp => 50;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string? MultilineName => "Shaman";
}
