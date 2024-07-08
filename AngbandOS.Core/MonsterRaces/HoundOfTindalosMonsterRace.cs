// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HoundOfTindalosMonsterRace : MonsterRace
{
    protected HoundOfTindalosMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheNetherMonsterSpell),
        nameof(BreatheTimeMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override bool Animal => true;
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(LoseWisAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(LoseWisAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(LoseWisAttackEffect), 2, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 3, 3)
    };
    public override bool Cthuloid => true;
    public override string Description => "'They are lean and athirst!'";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Hound of Tindalos";
    public override bool Friends => true;
    public override int Hdice => 60;
    public override int Hside => 15;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 54;
    public override int Mexp => 8000;
    public override int NoticeRange => 30;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override bool ResistNether => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Hound\nof\nTindalos";
}
