[Serializable]
internal class CultistRemoveCurseLifeSpell : ClassSpell
{
    private CultistRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 18;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 4;
}