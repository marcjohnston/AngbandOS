internal class HighMageFirstAidNatureSpell : ClassSpell
{
    private HighMageFirstAidNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFirstAid);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 3;
}