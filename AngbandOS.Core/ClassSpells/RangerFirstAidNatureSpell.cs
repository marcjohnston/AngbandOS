[Serializable]
internal class RangerFirstAidNatureSpell : ClassSpell
{
    private RangerFirstAidNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFirstAid);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 2;
}