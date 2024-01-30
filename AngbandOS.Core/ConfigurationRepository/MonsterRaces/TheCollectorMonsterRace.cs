// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheCollectorMonsterRace : MonsterRace
{
    protected TheCollectorMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(SummonUniqueMonsterSpell),
        nameof(TeleportAwayMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Copper;
    public override string Name => "The Collector";

    public override int ArmorClass => 100;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(LoseChaAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatItemAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(LoseAllAttackEffect), 10, 1),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatGoldAttackEffect), 0, 0)
    };
    public override bool ColdBlood => true;
    public override string Description => "A strange little gnome, he's been collecting toys and friends and doesn't want to give them up.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "The Collector";
    public override int Hdice => 25;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool ImmuneStun => true;
    public override int LevelFound => 52;
    public override bool Male => true;
    public override int Mexp => 45000;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 150;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    The     ";
    public override string SplitName3 => " Collector  ";
    public override bool Unique => true;
}
