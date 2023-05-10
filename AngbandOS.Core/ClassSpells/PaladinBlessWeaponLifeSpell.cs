internal class PaladinBlessWeaponLifeSpell : ClassSpell
{
    private PaladinBlessWeaponLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBlessWeapon);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 65;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}