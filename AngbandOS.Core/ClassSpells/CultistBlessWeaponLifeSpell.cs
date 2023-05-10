[Serializable]
internal class CultistBlessWeaponLifeSpell : ClassSpell
{
    private CultistBlessWeaponLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBlessWeapon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}