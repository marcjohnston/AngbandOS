internal class MageTerrorDeathSpell : ClassSpell
{
    private MageTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 10;
}