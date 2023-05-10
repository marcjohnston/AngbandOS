internal class PriestBlessWeaponLifeSpell : ClassSpell
{
    private PriestBlessWeaponLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBlessWeapon);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 50;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 130;
}