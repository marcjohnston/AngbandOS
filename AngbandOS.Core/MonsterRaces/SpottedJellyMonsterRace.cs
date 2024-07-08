// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpottedJellyMonsterRace : MonsterRace
{
    protected SpottedJellyMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    
    public override int ArmorClass => 18;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AcidAttackEffect), 2, 6),
        (nameof(TouchAttack), nameof(AcidAttackEffect), 2, 6),
        (nameof(TouchAttack), nameof(AcidAttackEffect), 1, 10),
    };
    public override bool ColdBlood => true;
    public override string Description => "A jelly thing.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Spotted jelly";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 12;
    public override int Mexp => 33;
    public override bool NeverMove => true;
    public override int NoticeRange => 12;
    public override int Rarity => 3;
    public override int Sleep => 1;
    public override int Speed => 120;
    public override string? MultilineName => "Spotted\njelly";
    public override bool Stupid => true;
}
