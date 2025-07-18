// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheUltimateDungeonCleanerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 10),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 10),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 10),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 10)
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
    public override string? MultilineName => "The Ultimate\nDungeon\nCleaner";
    public override bool Unique => true;
}
