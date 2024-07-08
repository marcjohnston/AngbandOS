// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientMultiHuedDragonMonsterRace : MonsterRace
{
    protected AncientMultiHuedDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheAcidMonsterSpell),
        nameof(BreatheColdMonsterSpell),
        nameof(BreatheLightningMonsterSpell),
        nameof(BreatheFireMonsterSpell),
        nameof(BreathePoisonMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 6, 12),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form. Many colors ripple down its massive frame. Few live to see another.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Ancient multi-hued dragon";
    public override int Hdice => 21;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 43;
    public override int Mexp => 13000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Ancient\nmulti-hued\ndragon";
}
