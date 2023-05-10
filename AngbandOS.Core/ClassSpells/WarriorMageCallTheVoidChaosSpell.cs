internal class WarriorMageCallTheVoidChaosSpell : ClassSpell
{
    private WarriorMageCallTheVoidChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallTheVoid);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 100;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}