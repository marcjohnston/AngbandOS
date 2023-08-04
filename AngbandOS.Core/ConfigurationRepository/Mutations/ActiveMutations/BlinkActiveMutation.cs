// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class BlinkActiveMutation : Mutation
{
    private BlinkActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(3, 3, Ability.Wisdom, 12))
        {
            SaveGame.TeleportPlayer(10);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 3 ? "blink            (unusable until level 3)" : "blink            (cost 3, WIS based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the power of minor teleportation.";
    public override string HaveMessage => "You can teleport yourself short distances.";
    public override string LoseMessage => "You lose the power of minor teleportation.";
}