[Serializable]
internal class PriestBanishLifeSpell : ClassSpell
{
    private PriestBanishLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBanish);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}