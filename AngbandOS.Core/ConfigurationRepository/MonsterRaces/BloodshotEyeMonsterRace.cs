// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BloodshotEyeMonsterRace : MonsterRace
{
    protected BloodshotEyeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DrainManaMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerESymbol));
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Bloodshot eye";

    public override int ArmourClass => 6;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(BlindAttackEffect)), 2, 6),
    };
    public override string Description => "A disembodied eye, bloodshot and nasty.";
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Bloodshot eye";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 7;
    public override int Mexp => 15;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Bloodshot  ";
    public override string SplitName3 => "    eye     ";
}
