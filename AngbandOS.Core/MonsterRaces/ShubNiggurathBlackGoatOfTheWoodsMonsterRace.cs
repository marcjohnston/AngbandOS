// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShubNiggurathBlackGoatOfTheWoodsMonsterRace : MonsterRace
{
    protected ShubNiggurathBlackGoatOfTheWoodsMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBreatheBallMonsterSpell),
        nameof(ConfusionBreatheBallMonsterSpell),
        nameof(PoisonBreatheBallMonsterSpell),
        nameof(RadiationBreatheBallMonsterSpell),
        nameof(ChaosBallMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(DarkBallMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonCthuloidMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(SummonUniqueMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(LoseWisAttackEffect), 20, 5),
        (nameof(CrushAttack), nameof(LoseIntAttackEffect), 20, 5),
        (nameof(BiteAttack), nameof(LoseStrAttackEffect), 10, 2),
        (nameof(BiteAttack), nameof(LoseConAttackEffect), 10, 2)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "This horrendous outer god looks like a writhing cloudy mass filled with mouths and tentacles.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Shub-Niggurath, Black Goat of the Woods";
    public override bool GreatOldOne => true;
    public override int Hdice => 65;
    public override int Hside => 99;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 91;
    public override bool LightningAura => true;
    public override int Mexp => 47500;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Shub-Niggura";
    public override bool Unique => true;
}
