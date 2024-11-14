// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CryptCreepMonsterRace : MonsterRace
{
    protected CryptCreepMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseLightWoundsMonsterSpell),
        nameof(UndeadSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 12;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 2),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 1, 2),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "Frightening skeletal figures in black robes. ";
    public override bool Evil => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Crypt creep";
    public override bool Friends => true;
    public override int Hdice => 6;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 7;
    public override int Mexp => 25;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 14;
    public override int Speed => 110;
    public override string? MultilineName => "Crypt\ncreep";
    public override bool Undead => true;
}
