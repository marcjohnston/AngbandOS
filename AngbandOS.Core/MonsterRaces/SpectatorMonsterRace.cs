// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpectatorMonsterRace : MonsterRace
{
    protected SpectatorMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseSeriousWoundsMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(ForgetMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 1;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(ParalyzeAttackEffect), 1, 4),
        (nameof(GazeAttack), nameof(ConfuseAttackEffect), 1, 4),
        (nameof(GazeAttack), nameof(DisenchantAttackEffect), 0, 0),
    };
    public override string Description => "It has three small eyestalks and a large central eye.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Spectator";
    public override int Hdice => 10;
    public override int Hside => 13;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 150;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Spectator";
    public override bool Stupid => true;
}
