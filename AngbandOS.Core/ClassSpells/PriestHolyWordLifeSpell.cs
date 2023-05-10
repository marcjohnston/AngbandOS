[Serializable]
internal class PriestHolyWordLifeSpell : ClassSpell
{
    private PriestHolyWordLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyWord);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 32;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}