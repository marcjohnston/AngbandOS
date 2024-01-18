// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SayFeelingScript : Script
{
    private SayFeelingScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        if (SaveGame.CurrentDepth > 0)
        {
            string[] DangerFeelingText =
            {
                "You're not sure about this level yet", "You feel there is something special about this ",
                "You nearly faint as horrible visions of death fill your mind", "This level looks very dangerous",
                "You have a very bad feeling", "You have a bad feeling", "You feel nervous",
                "You feel unsafe", "You don't like the look of this place",
                "This level looks reasonably safe", "What a boring place"
            };


            string[] TreasureFeelingText = {
                "You're not sure about this level yet.", "you feel it contains something special",
                "treasure galore!", "with a veritable hoard.",
                "powerful magic can be found here.", "there's magic in the air.", "there's wealth to be found.",
                "with significant treasure.", "there's not much of value here.",
                "with nothing of worth.", "what meagre pickings..."
            };

            // Some sanity checks
            if (SaveGame.DangerFeeling < 0)
            {
                SaveGame.DangerFeeling = 0;
            }
            if (SaveGame.DangerFeeling > 10)
            {
                SaveGame.DangerFeeling = 10;
            }
            if (SaveGame.TreasureFeeling < 0)
            {
                SaveGame.TreasureFeeling = 0;
            }
            if (SaveGame.TreasureFeeling > 10)
            {
                SaveGame.TreasureFeeling = 10;
            }
            // Special feeling overrides the normal two-part feeling
            if (SaveGame.DangerFeeling == 1 || SaveGame.TreasureFeeling == 1)
            {
                string message = DangerFeelingText[1];
                SaveGame.MsgPrint(SaveGame.GameTime.LevelFeel ? message : DangerFeelingText[0]);
            }
            else
            {
                // Make the two-part feeling make a bit more sense by using the correct conjunction
                string conjunction = ", and ";
                if ((SaveGame.DangerFeeling > 5 && SaveGame.TreasureFeeling < 6) || (SaveGame.DangerFeeling < 6 && SaveGame.TreasureFeeling > 5))
                {
                    conjunction = ", but ";
                }
                string message = DangerFeelingText[SaveGame.DangerFeeling] + conjunction + TreasureFeelingText[SaveGame.TreasureFeeling];
                SaveGame.MsgPrint(SaveGame.GameTime.LevelFeel ? message : DangerFeelingText[0]);
            }
        }
        return false;
    }
}
