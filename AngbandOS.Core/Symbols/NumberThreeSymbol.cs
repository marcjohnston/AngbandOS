[Serializable]
internal class NumberThreeSymbol : Symbol
{
    private NumberThreeSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '3';
    public override string Name => "Entrance to Weaponsmith";
}