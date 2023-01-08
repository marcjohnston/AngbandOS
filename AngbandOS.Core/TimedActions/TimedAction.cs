namespace AngbandOS.Core.TimedActions
{
    /// <summary>
    /// Represents an action that occurs over a period of time.
    /// </summary>
    internal abstract class TimedAction
    {
        protected SaveGame SaveGame { get; }

        public TimedAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        protected int _timer;
        public int TimeRemaining => _timer;

        /// <summary>
        /// Updates the timer associated with the action and returns true, if the action was noticed; false, otherwise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool SetTimer(int value);

        /// <summary>
        /// Resets the timer to a specific value.  No messages or processing occurs.
        /// </summary>
        public virtual void Reset(int value = 0)
        {
            _timer = value;
        }

        public virtual void ProcessWorld()
        {
            if (TimeRemaining > 0)
            {
                SetTimer(_timer - 1);
            }
        }
    }

    //internal class StunTimedAction : TimedAction
    //{
    //    public StunTimedAction(SaveGame saveGame) : base(saveGame) { }
    //}

    //internal class PoisonTimedAction : TimedAction
    //{
    //    public PoisonTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class BlessingTimedAction : TimedAction
    //{
    //    public BlessingTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class StoneskinTimedAction : TimedAction
    //{
    //    public StoneskinTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class AcidResistanceTimedAction : TimedAction
    //{
    //    public AcidResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class LightningResistanceTimedAction : TimedAction
    //{
    //    public LightningResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class FireResistanceTimedAction : TimedAction
    //{
    //    public FireResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class ColdResistanceTimedAction : TimedAction
    //{
    //    public ColdResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class HeroismTimedAction : TimedAction
    //{
    //    public HeroismTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class SuperHeroismTimedAction : TimedAction
    //{
    //    public SuperHeroismTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class EtherealnessTimedAction : TimedAction
    //{
    //    public EtherealnessTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class InvulnerabilityTimedAction : TimedAction
    //{
    //    public InvulnerabilityTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class ProtectionFromEvilAction : TimedAction
    //{
    //    public ProtectionFromEvilAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class SlowAction : TimedAction
    //{
    //    public SlowAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class HasteTimedAction : TimedAction
    //{
    //    public HasteTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class FearTimedAction : TimedAction
    //{
    //    public FearTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class ConfusionTimedAction : TimedAction
    //{
    //    public ConfusionTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class ParalysisTimedAction : TimedAction
    //{
    //    public ParalysisTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class InfravisionTimedAction : TimedAction
    //{
    //    public InfravisionTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class TelepathyTimedAction : TimedAction
    //{
    //    public TelepathyTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class SeeInvisibilityTimedAction : TimedAction
    //{
    //    public SeeInvisibilityTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    //internal class BlindnessTimedAction : TimedAction
    //{
    //    public BlindnessTimedAction(SaveGame saveGame) : base(saveGame) { }

    //}

    internal class HallucinationsTimedAction : TimedAction
    {
        public HallucinationsTimedAction(SaveGame saveGame) : base(saveGame) { }

        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("Oh, wow! Everything looks so cosmic now!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You can see clearly again.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
