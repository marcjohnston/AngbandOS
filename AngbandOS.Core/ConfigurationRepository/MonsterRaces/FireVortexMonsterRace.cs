// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FireVortexMonsterRace : MonsterRace
{
    protected FireVortexMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerVSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Fire vortex";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<EngulfAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 3, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "A whirling maelstrom of fire.";
    public override bool EmptyMind => true;
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Fire vortex";
    public override int Hdice => 9;
    public override int Hside => 9;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 21;
    public override int Mexp => 100;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool Powerful => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Fire    ";
    public override string SplitName3 => "   vortex   ";
}