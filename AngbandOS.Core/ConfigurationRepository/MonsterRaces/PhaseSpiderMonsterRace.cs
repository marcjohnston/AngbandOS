// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PhaseSpiderMonsterRace : MonsterRace
{
    protected PhaseSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlinkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportToMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperSSymbol>();
    public override ColourEnum Colour => ColourEnum.Pink;
    public override string Name => "Phase spider";

    public override bool Animal => true;
    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 1, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A spider that never seems quite there. Everywhere you look it is just half-seen in the corner of one eye.";
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Phase spider";
    public override bool Friends => true;
    public override int Hdice => 6;
    public override int Hside => 8;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override int Mexp => 60;
    public override int NoticeRange => 15;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Phase    ";
    public override string SplitName3 => "   spider   ";
    public override bool WeirdMind => true;
}