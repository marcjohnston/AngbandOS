[Serializable]
internal class PriestDispelCurseLifeSpell : ClassSpell
{
    private PriestDispelCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelCurse);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 60;
}