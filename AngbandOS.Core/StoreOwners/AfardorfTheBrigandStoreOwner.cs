[Serializable]
internal class AfardorfTheBrigandStoreOwner : StoreOwner
{
    private AfardorfTheBrigandStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Afardorf the Brigand";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}