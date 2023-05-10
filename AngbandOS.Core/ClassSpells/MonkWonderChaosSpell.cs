[Serializable]
internal class MonkWonderChaosSpell : ClassSpell
{
    private MonkWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 7;
}