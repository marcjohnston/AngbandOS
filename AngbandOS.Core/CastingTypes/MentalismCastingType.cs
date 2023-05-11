namespace AngbandOS.Core.CastingTypes
{
    [Serializable]
    internal class MentalismCastingType : CastingType
    {
        private MentalismCastingType(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            SaveGame.DoCmdMentalism();
        }
    }
}