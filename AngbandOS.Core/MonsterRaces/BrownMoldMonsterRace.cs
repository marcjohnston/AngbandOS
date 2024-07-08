// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BrownMoldMonsterRace : MonsterRace
{
    protected BrownMoldMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerMSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 12;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(ConfuseAttackEffect), 1, 4),
    };
    public override string Description => "A strange brown growth on the dungeon floor.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Brown mold";
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 6;
    public override int Mexp => 20;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 110;
    public override string? MultilineName => "Brown\nmold";
    public override bool Stupid => true;
}
