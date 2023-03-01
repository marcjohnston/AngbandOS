[Serializable]
internal class HooshnakTheViciousStoreOwner : StoreOwner
{
    private HooshnakTheViciousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hooshnak the Vicious";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}