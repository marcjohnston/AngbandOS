// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NineHeadedHydraMonsterRace : MonsterRace
{
    protected NineHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperMSymbol));
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "9-headed hydra";

    public override bool Animal => true;
    public override int ArmorClass => 95;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A strange reptilian hybrid with nine smouldering heads.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "9-headed hydra";
    public override int Hdice => 100;
    public override int Hside => 12;
    public override bool ImmuneFire => true;
    public override int LevelFound => 40;
    public override int Mexp => 3000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  9-headed  ";
    public override string SplitName3 => "   hydra    ";
}
