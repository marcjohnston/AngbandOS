[Serializable]
internal class CultistRestorationLifeSpell : ClassSpell
{
    private CultistRestorationLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRestoration);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 225;
}