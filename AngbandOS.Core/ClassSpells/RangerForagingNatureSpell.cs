internal class RangerForagingNatureSpell : ClassSpell
{
    private RangerForagingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellForaging);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 7;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 2;
}