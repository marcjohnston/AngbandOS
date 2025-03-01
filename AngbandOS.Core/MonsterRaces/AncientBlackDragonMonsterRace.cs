// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientBlackDragonMonsterRace : MonsterRace
{
    protected AncientBlackDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 90;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 9),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 9),
        (nameof(BiteAttack), nameof(AcidAttackEffect), 5, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form. Pools of acid melt the floor around it.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Ancient black dragon";
    public override int Hdice => 72;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 39;
    public override int Mexp => 2500;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Ancient\nblack\ndragon";
}
