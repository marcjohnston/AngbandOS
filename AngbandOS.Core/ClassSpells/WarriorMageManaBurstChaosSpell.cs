[Serializable]
internal class WarriorMageManaBurstChaosSpell : ClassSpell
{
    private WarriorMageManaBurstChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaBurst);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}