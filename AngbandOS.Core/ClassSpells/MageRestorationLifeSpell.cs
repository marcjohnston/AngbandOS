[Serializable]
internal class MageRestorationLifeSpell : ClassSpell
{
    private MageRestorationLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRestoration);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 100;
    public override int BaseFailure => 82;
    public override int FirstCastExperience => 225;
}