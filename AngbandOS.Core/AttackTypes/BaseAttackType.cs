﻿namespace AngbandOS.Core.AttackTypes
{
    internal abstract class BaseAttackType
    {
        /// <summary>
        /// Returns the action message to be displayed, when the attack targets another monster.
        /// </summary>
        public abstract string MonsterAction(Monster monster);

        /// <summary>
        /// Returns the action message to be displayed, when the attack targets the player.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <returns></returns>
        public abstract string PlayerAction(SaveGame saveGame);

        /// <summary>
        /// Returns the action message to be displayed, when a description of the attack is being rendered to the player viewing
        /// their knowledge.
        /// </summary>
        public abstract string KnowledgeAction { get; }

        /// <summary>
        /// Returns true, if the attack requires touching the target; false otherwise.  Returns true, by default.  The beg, drool, gaze, insult, moan, show, spit, 
        /// spore, wail and worship attacks do not require touching the target.
        /// </summary>
        public virtual bool AttackTouchesTarget => true;

        /// <summary>
        /// Returns true, if the attack awakes the target; false otherwise.  Returns false, by default,  The beg, insult, moan and show attacks
        /// return true.
        /// </summary>
        public virtual bool AttackAwakensTarget => false;

        /// <summary>
        /// Returns true, if the attack stuns the target; false otherwise.  Returns false, by default.  The hit, punch, kick, butt and crush attacks return true.
        /// </summary>
        public virtual bool AttackStunsTarget => false;

        /// <summary>
        /// Returns true, if the attack cuts the target; false otherwise.  Returns false, by default.  The hit, claw and bite attacks all return true.
        /// </summary>
        public virtual bool AttackCutsTarget => false;

        /// <summary>
        /// Returns true, if the attack should render a message, if the attack touches the target and missed; false no message should be rendered.  Returns true, by default.  
        /// Only the crawl attack, requires touching the target and does not render a miss message.
        /// </summary>
        public virtual bool RendersMissMessage => true;
    }
}