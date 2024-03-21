[Serializable]
internal class NumberThreeSymbol : Symbol
{
    private NumberThreeSymbol(Game game) : base(game) { }
    public override char Character => '3';
    public override string Name => "Entrance to Weaponsmith";
}