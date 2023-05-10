internal class RogueEnchantWeaponSorcerySpell : ClassSpell
{
    private RogueEnchantWeaponSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellEnchantWeapon);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}