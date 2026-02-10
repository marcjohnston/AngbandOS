namespace AngbandOS.GamePacks.Cthangband.RangedWeaponBonuses
{
    [Serializable]
    public class WarriorLevel50RangedWeaponBonus : RangedWeaponBonusGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
        public override int? ExperienceLevel => 50;
        public override int BonusMissileAttacksPerRound => 1;
    }
}
