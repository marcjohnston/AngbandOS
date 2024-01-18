// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientWhiteDragonMonsterRace : MonsterRace
{
    protected AncientWhiteDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheColdMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlindnessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperDSymbol));
    public override string Name => "Ancient white dragon";

    public override int ArmourClass => 90;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 4, 9),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 4, 9),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ColdAttackEffect)), 5, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form. Frost covers it from head to tail.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Ancient white dragon";
    public override int Hdice => 70;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 39;
    public override int Mexp => 2500;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "  Ancient   ";
    public override string SplitName2 => "   white    ";
    public override string SplitName3 => "   dragon   ";
}
