namespace AngbandOS.GamePacks.Cthangband.RangedWeaponBonuses
{
    [Serializable]
    public class RangerBowLevel40RangedWeaponBonus : RangedWeaponBonusGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
        public override string? ItemClassBindingKey => nameof(BowItemClass);
        public override int? ExperienceLevel => 40;
        public override int BonusMissileAttacksPerRound => 1;
    }
}
