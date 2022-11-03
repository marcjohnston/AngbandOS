using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.Core.ChestTraps
{
    internal class ActivateChestTrapEventArgs
    {
        /// <summary>
        /// Returns a reference to the save game so that the trap has access to the entire game structure.
        /// </summary>
        public SaveGame SaveGame { get; }

        /// <summary>
        /// Returns the X grid position of trap.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Returns the Y grid position of the trap.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Returns whether or not the recursion should be cancelled.  Returns false, by default.  Set to true, to prevent the sub-traps
        /// from activating.
        /// </summary>
        public bool CancelRecursion = false;

        /// <summary>
        /// Returns whether or not the activation of the trap destroys the contents.  Returns false, by default.  Set to true, when the trap destroys the contents.
        /// </summary>
        public bool DestroysContents = false;

        public ActivateChestTrapEventArgs(SaveGame saveGame, int x, int y)
        {
            SaveGame = saveGame;
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Represents a trap on a chest.  Can be layered with multiple traps.  The base class implements the layering.  Derived classes only
    /// need concern themselves with their own implementation and not sub-traps.
    /// </summary>
    internal abstract class BaseChestTrap
    {
        /// <summary>
        /// Returns the next trap in the chain.  Returns null, when there are no more traps.
        /// </summary>
        private BaseChestTrap? NextTrap { get; }

        /// <summary>
        /// Represents the activation method the derived chest trap classes must implement.
        /// </summary>
        /// <param name="saveGame"></param>
        protected abstract void Activate(ActivateChestTrapEventArgs eventArgs);

        /// <summary>
        /// Activate the trap and all sub-traps.  Non-overridable.
        /// </summary>
        /// <param name="saveGame"></param>
        public void Activate(SaveGame saveGame, int x, int y)
        {
            ActivateChestTrapEventArgs eventArgs = new ActivateChestTrapEventArgs(saveGame, x, y);
            Activate(eventArgs);

            if (eventArgs.DestroysContents)
            {

            }
            if (eventArgs.CancelRecursion)
            {

            }
        }

        public BaseChestTrap(BaseChestTrap? nextTrap)
        {
            NextTrap = nextTrap;
        }
    }

    internal class ExplodeChestTrap : BaseChestTrap
    {
        public ExplodeChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("There is a sudden explosion!");
            eventArgs.SaveGame.MsgPrint("Everything inside the chest is destroyed!");
            eventArgs.DestroysContents = true;
            eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(5, 8), "an exploding chest");
        }
    }

    internal class LoseConChestTrap : BaseChestTrap
    {
        public LoseConChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A small needle has pricked you!");
            eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
            eventArgs.SaveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
        }
    }

    internal class LoseStrChestTrap : BaseChestTrap
    {
        public LoseStrChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A small needle has pricked you!");
            eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
            eventArgs.SaveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
        }
    }

    internal class ParalyzeChestTrap : BaseChestTrap
    {
        public ParalyzeChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A puff of yellow gas surrounds you!");
            if (!eventArgs.SaveGame.Player.HasFreeAction)
            {
                eventArgs.SaveGame.Player.SetTimedParalysis(eventArgs.SaveGame.Player.TimedParalysis + 10 + Program.Rng.DieRoll(20));
            }
        }
    }

    internal class PoisonChestTrap : BaseChestTrap
    {
        public PoisonChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }

        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A puff of green gas surrounds you!");
            if (!(eventArgs.SaveGame.Player.HasPoisonResistance || eventArgs.SaveGame.Player.TimedPoisonResistance != 0))
            {
                if (Program.Rng.DieRoll(10) <= eventArgs.SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    eventArgs.SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else
                {
                    eventArgs.SaveGame.Player.SetTimedPoison(eventArgs.SaveGame.Player.TimedPoison + 10 + Program.Rng.DieRoll(20));
                }
            }
        }
    }

    internal class SummonChestTrap : BaseChestTrap
    {
        public SummonChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }

        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            int num = 2 + Program.Rng.DieRoll(3);
            eventArgs.SaveGame.MsgPrint("You are enveloped in a cloud of smoke!");
            for (int i = 0; i < num; i++)
            {
                if (Program.Rng.DieRoll(100) < eventArgs.SaveGame.Difficulty)
                {
                    eventArgs.SaveGame.ActivateHiSummon();
                }
                else
                {
                    eventArgs.SaveGame.Level.Monsters.SummonSpecific(eventArgs.Y, eventArgs.X, eventArgs.SaveGame.Difficulty, 0);
                }
            }
        }
    }
}
