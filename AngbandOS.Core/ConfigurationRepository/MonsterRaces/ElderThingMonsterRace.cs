// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ElderThingMonsterRace : MonsterRace
{
    protected ElderThingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(RadiationBallMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(PoisonBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonCthuloidMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportAwayMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Elder thing";

    public override int ArmorClass => 70;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(LoseWisAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override bool Demon => true;
    public override string Description => "It is barrel-shaped, with horizontal arms and a starfish head.";
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Elder thing";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 800;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Elder    ";
    public override string SplitName3 => "   thing    ";
}
