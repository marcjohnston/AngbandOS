// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class TimePlayerEffect : PlayerEffect
{
    private TimePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by a blast from the past!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string act = null;
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasTimeResistance)
        {
            dam *= 4;
            dam /= Game.DieRoll(6) + 6;
            Game.MsgPrint("You feel as if time is passing you by.");
        }
        else
        {
            switch (Game.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    {
                        Game.MsgPrint("You feel life has clocked back.");
                        Game.LoseExperience(100 + (Game.ExperiencePoints.IntValue / 100 * Constants.MonDrainLife));
                        break;
                    }
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        WeightedRandom<Ability> abilitiesWeightedRandom = Game.SingletonRepository.ToWeightedRandom<Ability>();
                        Ability k = abilitiesWeightedRandom.Choose();
                        act = k.Act;
                        Game.MsgPrint($"You're not as {act} as you used to be...");
                        k.Innate = k.Innate * 3 / 4;
                        if (k.Innate < 3)
                        {
                            k.Innate = 3;
                        }
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
                case 10:
                    {
                        Game.MsgPrint("You're not as powerful as you used to be...");
                        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
                        {
                            ability.Innate = ability.Innate * 3 / 4;
                            if (ability.Innate < 3)
                            {
                                ability.Innate = 3;
                            }
                        }
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
            }
        }
        Game.TakeHit(dam, killer);
        return IdentifiedResultEnum.True;
    }
}
