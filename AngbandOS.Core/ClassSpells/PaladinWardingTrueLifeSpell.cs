[Serializable]
internal class PaladinWardingTrueLifeSpell : ClassSpell
{
    private PaladinWardingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellWardingTrue);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 60;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}