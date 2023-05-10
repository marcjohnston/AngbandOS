[Serializable]
internal class PriestFirstAidNatureSpell : ClassSpell
{
    private PriestFirstAidNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFirstAid);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}