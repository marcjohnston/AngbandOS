// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TsathogguaMonsterRace : MonsterRace
{
    protected TsathogguaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheChaosMonsterSpell),
        nameof(BreatheDisenchantMonsterSpell),
        nameof(BreatheDisintegrationMonsterSpell),
        nameof(BreatheManaMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(SummonCthuloidMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Tsathoggua";

    public override int ArmorClass => 150;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 35, 5),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(AcidAttackEffect), 35, 5),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 35, 5),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(AcidAttackEffect), 35, 5)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "Toad shaped and sleepy, don't let his inoffensive appearance fool you. He still bears all the power of a Great Old One.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool EmptyMind => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Tsathoggua";
    public override bool GreatOldOne => true;
    public override int Hdice => 99;
    public override int Hside => 99;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillItem => true;
    public override bool KillWall => true;
    public override int LevelFound => 93;
    public override bool LightningAura => true;
    public override int Mexp => 50000;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistDisenchant => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 100;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Tsathoggua ";
    public override bool Stupid => true;
    public override bool Unique => true;
}
