[Serializable]
internal class HaobTheBerserkerStoreOwner : StoreOwner
{
    private HaobTheBerserkerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Haob the Berserker";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}