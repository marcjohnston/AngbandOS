// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class LoseAblReward : Reward
{
    private LoseAblReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'I grow tired of thee, mortal.'");
        if (SaveGame.DieRoll(3) == 1 && !(patron.PreferredAbility < 0))
        {
            SaveGame.TryDecreasingAbilityScore(patron.PreferredAbility);
        }
        else
        {
            SaveGame.TryDecreasingAbilityScore(SaveGame.DieRoll(6) - 1);
        }
    }
}