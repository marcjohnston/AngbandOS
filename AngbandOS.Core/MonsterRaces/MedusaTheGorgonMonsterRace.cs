// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MedusaTheGorgonMonsterRace : MonsterRace
{
    protected MedusaTheGorgonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(PoisonBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonHydraMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerNSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(Exp80AttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(ParalyzeAttackEffect), 0, 0),
        (nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 8, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "Her face could sink a thousand ships.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Medusa, the Gorgon";
    public override int Hdice => 24;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override int Mexp => 9000;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Medusa";
    public override bool Unique => true;
}
