// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedDragonBatMonsterRace : MonsterRace
{
    protected RedDragonBatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerBSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Red dragon bat";

    public override bool Animal => true;
    public override int ArmourClass => 28;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a sharp-tailed bat, wreathed in fire.";
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Red dragon bat";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 23;
    public override int Mexp => 60;
    public override int NoticeRange => 12;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 130;
    public override string SplitName1 => "    Red     ";
    public override string SplitName2 => "   dragon   ";
    public override string SplitName3 => "    bat     ";
}
