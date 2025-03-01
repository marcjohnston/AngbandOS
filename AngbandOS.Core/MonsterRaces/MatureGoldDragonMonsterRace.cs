// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MatureGoldDragonMonsterRace : MonsterRace
{
    protected MatureGoldDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(SoundBreatheBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 80;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 10),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "A large dragon with scales of gleaming gold.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Mature gold dragon";
    public override int Hdice => 56;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 37;
    public override int Mexp => 1500;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 150;
    public override int Speed => 110;
    public override string? MultilineName => "Mature\ngold\ndragon";
}
