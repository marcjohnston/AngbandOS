// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SterilityActiveMutation : Mutation
{
    private SterilityActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(20, 40, Ability.Charisma, 18))
        {
            return;
        }
        SaveGame.MsgPrint("You suddenly have a headache!");
        SaveGame.TakeHit(base.SaveGame.Rng.DieRoll(30) + 30, "the strain of forcing abstinence");
        SaveGame.NumRepro += Constants.MaxRepro;
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20 ? "sterilize        (unusable until level 20)" : "sterilize        (cost 40, CHA based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "You can give everything around you a headache.";
    public override string HaveMessage => "You can cause mass impotence.";
    public override string LoseMessage => "You hear a massed sigh of relief.";
}