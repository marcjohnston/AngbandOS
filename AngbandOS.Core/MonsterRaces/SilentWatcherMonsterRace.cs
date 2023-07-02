// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SilentWatcherMonsterRace : MonsterRace
{
    protected SilentWatcherMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ShriekMonsterSpell(),
        new ConfuseMonsterSpell(),
        new DrainManaMonsterSpell(),
        new HoldMonsterSpell(),
        new MindBlastMonsterSpell(),
        new SummonMonsterMonsterSpell(),
        new SummonMonstersMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerGSymbol>();
    public override Colour Colour => Colour.Grey;
    public override string Name => "Silent watcher";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new GazeAttackType(), new TerrifyAttackEffect(), 0, 0),
        new MonsterAttack(new GazeAttackType(), new ParalyzeAttackEffect(), 0, 0),
        new MonsterAttack(new GazeAttackType(), new LoseStrAttackEffect(), 0, 0),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A figure carved from stone, with three vulture faces. Their eyes glow a malevolent light...";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Silent watcher";
    public override int Hdice => 80;
    public override int Hside => 20;
    public override bool HurtByLight => true;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 25;
    public override int Mexp => 590;
    public override bool NeverMove => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 42;
    public override int Rarity => 5;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Silent   ";
    public override string SplitName3 => "  watcher   ";
}
