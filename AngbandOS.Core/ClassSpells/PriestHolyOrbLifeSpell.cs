[Serializable]
internal class PriestHolyOrbLifeSpell : ClassSpell
{
    private PriestHolyOrbLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyOrb);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}