internal class WarriorMageBlessWeaponLifeSpell : ClassSpell
{
    private WarriorMageBlessWeaponLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBlessWeapon);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}