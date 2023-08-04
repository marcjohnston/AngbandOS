// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class IllumineActiveMutation : Mutation
{
    private IllumineActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(3, 2, Ability.Intelligence, 10))
        {
            SaveGame.LightArea(base.SaveGame.Rng.DiceRoll(2, SaveGame.ExperienceLevel / 2), (SaveGame.ExperienceLevel / 10) + 1);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 3 ? "illuminate       (unusable until level 3)" : "illuminate       (cost 2, INT based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You can light up rooms with your presence.";
    public override string HaveMessage => "You can emit bright light.";
    public override string LoseMessage => "You can no longer light up rooms with your presence.";
}