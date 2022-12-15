namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class SavedGameContent
    {
        public SavedGameContent()
        {
            SavedGames = new HashSet<SavedGame>();
        }

        public int Id { get; set; }
        public byte[] Data { get; set; } = null!;

        public virtual ICollection<SavedGame> SavedGames { get; set; }
    }
}
