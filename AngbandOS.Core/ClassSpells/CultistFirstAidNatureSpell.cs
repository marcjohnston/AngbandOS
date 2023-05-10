[Serializable]
internal class CultistFirstAidNatureSpell : ClassSpell
{
    private CultistFirstAidNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFirstAid);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 3;
}