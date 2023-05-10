[Serializable]
internal class CultistProtectionFromEvilLifeSpell : ClassSpell
{
    private CultistProtectionFromEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellProtectionFromEvil);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}