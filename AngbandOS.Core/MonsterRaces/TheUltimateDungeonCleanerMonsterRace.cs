// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheUltimateDungeonCleanerMonsterRace : MonsterRace
{
    protected TheUltimateDungeonCleanerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerGSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "The Ultimate Dungeon Cleaner";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrushAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 10),
        new MonsterAttack(new CrushAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 10),
        new MonsterAttack(new CrushAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 10),
        new MonsterAttack(new CrushAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 10)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It looks like a huge spiked roller. It was designed to keep this dungeon clean, and you are the biggest spot of dirt in sight.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "The Ultimate Dungeon Cleaner";
    public override int Hdice => 70;
    public override int Hside => 12;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 28;
    public override int Mexp => 555;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override int Rarity => 2;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 12;
    public override int Speed => 120;
    public override string SplitName1 => "The Ultimate";
    public override string SplitName2 => "  Dungeon   ";
    public override string SplitName3 => "  Cleaner   ";
    public override bool Unique => true;
}
