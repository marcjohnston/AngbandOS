namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GemstoneLightItem : LightItem
    {
        public override void EquipmentProcessWorldHook(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(999) == 1 && !saveGame.Player.HasAntiMagic)
            {
                if (saveGame.Player.TimedInvulnerability.TurnsRemaining == 0)
                {
                    saveGame.MsgPrint("The Jewel of Judgement drains life from you!");
                    saveGame.Player.TakeHit(Math.Min(saveGame.Player.Level, 50), "the Jewel of Judgement");
                }
            }
        }
        public GemstoneLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightGemstone>()) { }
    }
}