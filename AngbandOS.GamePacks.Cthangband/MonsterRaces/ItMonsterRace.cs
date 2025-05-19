// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ItMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ShriekMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.BlinkMonsterSpell),
        nameof(MonsterSpellsEnum.CreateTrapsMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.HydraSummonMonsterSpell),
        nameof(MonsterSpellsEnum.MonsterSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportAwayMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(PeriodSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.BlindAttackEffect), 8, 8),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.TerrifyAttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatItemAttackEffect), 0, 0)
    };
    public override bool AttrClear => true;
    public override bool CharClear => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "Nobody has ever seen It.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "It";
    public override int Hdice => 77;
    public override int Hside => 9;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 24;
    public override int Mexp => 400;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 25;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string? MultilineName => "It";
    public override bool Unique => true;
}
