// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MasterVampireMonsterRace : MonsterRace
{
    protected MasterVampireMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperVSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Master vampire";

    public override int ArmorClass => 60;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp40AttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp40AttackEffect), 1, 4)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a humanoid form dressed in robes. Power emanates from its chilling frame.";
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Master vampire";
    public override int Hdice => 34;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 34;
    public override int Mexp => 750;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Master   ";
    public override string SplitName3 => "  vampire   ";
    public override bool Undead => true;
}
