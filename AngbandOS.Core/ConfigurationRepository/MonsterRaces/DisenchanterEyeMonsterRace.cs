// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DisenchanterEyeMonsterRace : MonsterRace
{
    protected DisenchanterEyeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DrainManaMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerESymbol));
    public override ColorEnum Color => ColorEnum.Chartreuse;
    public override string Name => "Disenchanter eye";

    public override int ArmorClass => 10;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(UnBonusAttackEffect)), 0, 0),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override string Description => "A disembodied eye, crackling with magic.";
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Disenchanter eye";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 5;
    public override int Mexp => 20;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "Disenchanter";
    public override string SplitName3 => "    eye     ";
}
