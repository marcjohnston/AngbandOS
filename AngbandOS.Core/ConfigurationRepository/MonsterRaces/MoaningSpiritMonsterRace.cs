// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MoaningSpiritMonsterRace : MonsterRace
{
    protected MoaningSpiritMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportSelfMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Moaning spirit";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<WailAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<TerrifyAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseDexAttackEffect>(), 1, 8),
    };
    public override bool ColdBlood => true;
    public override string Description => "A ghostly apparition that shrieks horribly.";
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Moaning spirit";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 12;
    public override int Mexp => 44;
    public override int NoticeRange => 14;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Moaning   ";
    public override string SplitName3 => "   spirit   ";
    public override bool Undead => true;
}