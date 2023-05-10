[Serializable]
internal class PriestProtectionFromEvilLifeSpell : ClassSpell
{
    private PriestProtectionFromEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellProtectionFromEvil);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 8;
    public override int BaseFailure => 42;
    public override int FirstCastExperience => 4;
}