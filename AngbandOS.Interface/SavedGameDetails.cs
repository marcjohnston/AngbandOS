namespace AngbandOS.Interface
{
    public class SavedGameDetails
    {
        public string Guid { get; set; }
        public DateTime SavedDateTime { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string CharacterName { get; set; }
        public string Comments { get; set; }
        public bool IsAlive { get; set; }
    }
}
