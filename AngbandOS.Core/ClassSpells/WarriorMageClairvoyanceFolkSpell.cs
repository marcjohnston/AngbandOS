internal class WarriorMageClairvoyanceFolkSpell : ClassSpell
{
    private WarriorMageClairvoyanceFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellClairvoyance);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 140;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}