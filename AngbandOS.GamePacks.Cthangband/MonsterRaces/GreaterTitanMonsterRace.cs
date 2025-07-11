// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreaterTitanMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.MonstersSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(UpperPSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    
    public override int ArmorClass => 125;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 12, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 12, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 12, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 12, 12)
    };
    public override bool BashDoor => true;
    public override string Description => "A forty foot tall humanoid that shakes the ground as it walks. The power radiating from its frame shakes your courage, its hatred inspired by your defiance.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Greater titan";
    public override bool Giant => true;
    public override int Hdice => 38;
    public override int Hside => 100;
    public override int LevelFound => 46;
    public override bool Male => true;
    public override int Mexp => 13500;
    public override bool MoveBody => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 15;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Greater\ntitan";
    public override bool TakeItem => true;
}
