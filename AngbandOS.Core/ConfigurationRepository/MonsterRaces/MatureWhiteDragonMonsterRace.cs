// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MatureWhiteDragonMonsterRace : MonsterRace
{
    protected MatureWhiteDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheColdMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerDSymbol));
    public override string Name => "Mature white dragon";

    public override int ArmourClass => 65;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A large dragon, scales gleaming bright white.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Mature white dragon";
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 35;
    public override int Mexp => 1000;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "   Mature   ";
    public override string SplitName2 => "   white    ";
    public override string SplitName3 => "   dragon   ";
}
