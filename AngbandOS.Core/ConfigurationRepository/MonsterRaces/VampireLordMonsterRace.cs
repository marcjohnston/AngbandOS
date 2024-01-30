// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VampireLordMonsterRace : MonsterRace
{
    protected VampireLordMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperVSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "Vampire lord";

    public override int ArmorClass => 70;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp80AttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp80AttackEffect), 1, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A foul wind chills your bones as this ghastly figure approaches.";
    public override bool Drop_4D2 => true;
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Vampire lord";
    public override int Hdice => 16;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 39;
    public override int Mexp => 1800;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Vampire   ";
    public override string SplitName3 => "    lord    ";
    public override bool Undead => true;
}
