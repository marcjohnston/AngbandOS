namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GemstoneLightSourceItem : LightSourceItem
    {
        public override void EquipmentProcessWorldHook()
        {
            if (Program.Rng.DieRoll(999) == 1 && !SaveGame.Player.HasAntiMagic)
            {
                if (SaveGame.Player.TimedInvulnerability.TurnsRemaining == 0)
                {
                    SaveGame.MsgPrint("The Jewel of Judgement drains life from you!");
                    SaveGame.Player.TakeHit(Math.Min(SaveGame.Player.Level, 50), "the Jewel of Judgement");
                }
            }
        }
        public GemstoneLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GemstoneLightSourceItemFactory>()) { }
    }
}