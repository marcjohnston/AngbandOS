// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ElevenHeadedHydraMonsterRace : MonsterRace
{
    protected ElevenHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<PlasmaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperMSymbol>();
    public override ColourEnum Colour => ColourEnum.Green;
    public override string Name => "11-headed hydra";

    public override bool Animal => true;
    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 12),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 12),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 12),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 12)
    };
    public override bool BashDoor => true;
    public override string Description => "A strange reptilian hybrid with eleven smouldering heads.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "11-headed hydra";
    public override int Hdice => 100;
    public override int Hside => 18;
    public override bool ImmuneFire => true;
    public override int LevelFound => 44;
    public override int Mexp => 6000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " 11-headed  ";
    public override string SplitName3 => "   hydra    ";
}
