// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationFlatulent : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You become subject to uncontrollable flatulence.";
        HaveMessage = "You are subject to uncontrollable flatulence.";
        LoseMessage = "You are no longer subject to uncontrollable flatulence.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(3000) == 13)
        {
            saveGame.Disturb(false);
            saveGame.MsgPrint("BRRAAAP! Oops.");
            saveGame.MsgPrint(null);
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), 0, saveGame.Player.ExperienceLevel, 3);
        }
    }
}