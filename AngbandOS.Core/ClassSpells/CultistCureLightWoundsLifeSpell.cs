[Serializable]
internal class CultistCureLightWoundsLifeSpell : ClassSpell
{
    private CultistCureLightWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureLightWounds);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}