internal class HighMageBlessWeaponLifeSpell : ClassSpell
{
    private HighMageBlessWeaponLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBlessWeapon);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 70;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 115;
}