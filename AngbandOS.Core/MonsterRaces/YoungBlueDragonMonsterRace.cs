// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YoungBlueDragonMonsterRace : MonsterRace
{
    protected YoungBlueDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(LightningBreatheBallMonsterSpell),
        nameof(ScareMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 50;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It has a form that legends are made of. Its still-tender scales are a deep blue in hue. Sparks crackle along its length.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Young blue dragon";
    public override int Hdice => 27;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 29;
    public override int Mexp => 300;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string? MultilineName => "Young\nblue\ndragon";
}
