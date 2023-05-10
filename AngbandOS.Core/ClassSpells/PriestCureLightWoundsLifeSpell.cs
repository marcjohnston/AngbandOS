[Serializable]
internal class PriestCureLightWoundsLifeSpell : ClassSpell
{
    private PriestCureLightWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureLightWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 2;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}