// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FafnerTheDragonMonsterRace : MonsterRace
{
    protected FafnerTheDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBreatheBallMonsterSpell),
        nameof(PoisonBreatheBallMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 10),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 10),
        (nameof(BiteAttack), nameof(FireAttackEffect), 14, 6),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 14, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "The mighty dragon of the Norse myth, Fafner was a giant who slew his brother to win a treasure hoard, and then transformed himself into a dragon, greedily watching over his hoard.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Fafner the Dragon";
    public override int Hdice => 25;
    public override int Hside => 110;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 47;
    public override bool Male => true;
    public override int Mexp => 25000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override int Sleep => 70;
    public override int Speed => 120;
    public override string? MultilineName => "Fafner\nthe\nDragon";
    public override bool Unique => true;
}
