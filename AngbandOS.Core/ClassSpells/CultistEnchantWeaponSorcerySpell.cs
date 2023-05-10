internal class CultistEnchantWeaponSorcerySpell : ClassSpell
{
    private CultistEnchantWeaponSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellEnchantWeapon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 85;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}