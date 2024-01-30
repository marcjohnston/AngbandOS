// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MephistophelesLordOfHellMonsterRace : MonsterRace
{
    protected MephistophelesLordOfHellMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(BreatheNetherMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonReaverMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperUSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Mephistopheles, Lord of Hell";

    public override int ArmorClass => 150;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(Exp80AttackEffect), 1, 5),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(TerrifyAttackEffect), 1, 5),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(FireAttackEffect), 4, 5),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(UnPowerAttackEffect), 4, 5)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "A duke of hell, in the flesh.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Mephistopheles, Lord of Hell";
    public override int Hdice => 30;
    public override int Hside => 222;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 84;
    public override bool Male => true;
    public override int Mexp => 42500;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override bool ResistPlasma => true;
    public override int Sleep => 50;
    public override int Speed => 140;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Mephistophel";
    public override bool Unique => true;
}
