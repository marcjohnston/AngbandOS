namespace AngbandOS.GamePacks.Cthangband.RangedWeaponBonuses
{
    [Serializable]
    public class RangerBowLevel20RangedWeaponBonus : RangedWeaponBonusGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
        public override string? ItemClassBindingKey => nameof(BowItemClass);
        public override int? ExperienceLevel => 20;
        public override int BonusMissileAttacksPerRound => 1;
    }
}
