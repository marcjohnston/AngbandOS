[Serializable]
internal class VoirinTheCowardlyStoreOwner : StoreOwner
{
    private VoirinTheCowardlyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Voirin the Cowardly";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}