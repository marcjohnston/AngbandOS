[Serializable]
internal class WarriorMageClairvoyanceSorcerySpell : ClassSpell
{
    private WarriorMageClairvoyanceSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellClairvoyance);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 120;
}