[Serializable]
internal class RogueIdentifySorcerySpell : ClassSpell
{
    private RogueIdentifySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellIdentify);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}