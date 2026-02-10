namespace AngbandOS.GamePacks.Cthangband.RangedWeaponBonuses
{
    [Serializable]
    public class WarriorLevel25RangedWeaponBonus : RangedWeaponBonusGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
        public override int? ExperienceLevel => 25;
        public override int BonusMissileAttacksPerRound => 1;
    }
}
