// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

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
    public GemstoneLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GemstoneLightSourceItemFactory>()) { }
}