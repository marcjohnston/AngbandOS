// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DarkElvenLordMonsterRace : MonsterRace
{
    protected DarkElvenLordMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(ColdBoltMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(MagicMissileMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(HasteMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    
    public override int ArmorClass => 40;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark elven figure in armor and radiating evil power.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Dark elven lord";
    public override int Hdice => 18;
    public override int Hside => 15;
    public override bool HurtByLight => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Dark\nelven\nlord";
}
