[Serializable]
internal class PaladinRemoveCurseLifeSpell : ClassSpell
{
    private PaladinRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 11;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 4;
}