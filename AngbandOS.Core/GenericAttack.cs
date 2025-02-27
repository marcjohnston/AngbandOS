// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericAttack : Attack
{
    public GenericAttack(Game game, AttackGameConfiguration attackGameConfiguration) : base(game)
    {
        MonsterAction = attackGameConfiguration.MonsterAction;
        Key = attackGameConfiguration.Key ?? attackGameConfiguration.GetType().Name;
        PlayerAction = attackGameConfiguration.PlayerAction;
        KnowledgeAction = attackGameConfiguration.KnowledgeAction;
        AttackTouchesTarget = attackGameConfiguration.AttackTouchesTarget;
        AttackAwakensTarget = attackGameConfiguration.AttackAwakensTarget;
        AttackStunsTarget  = attackGameConfiguration.AttackStunsTarget;
        AttackCutsTarget = attackGameConfiguration.AttackCutsTarget;
        RendersMissMessage = attackGameConfiguration.RendersMissMessage;
    }

    public override string Key { get; }

    /// <summary>
    /// Returns the action message to be displayed, when the attack targets another monster.
    /// </summary>
    public override string MonsterAction { get; }

    /// <summary>
    /// Returns the action message to be displayed, when the attack targets the player.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public override string PlayerAction { get; }

    /// <summary>
    /// Returns the action message to be displayed, when a description of the attack is being rendered to the player viewing
    /// their knowledge.
    /// </summary>
    public override string KnowledgeAction { get; }

    /// <summary>
    /// Returns true, if the attack requires touching the target; false otherwise.  Returns true, by default.  The beg, drool, gaze, insult, moan, show, spit, 
    /// spore, wail and worship attacks do not require touching the target.
    /// </summary>
    public override bool AttackTouchesTarget { get; } = true;

    /// <summary>
    /// Returns true, if the attack awakes the target; false otherwise.  Returns false, by default,  The beg, insult, moan and show attacks
    /// return true.
    /// </summary>
    public override bool AttackAwakensTarget { get; } = false;

    /// <summary>
    /// Returns true, if the attack stuns the target; false otherwise.  Returns false, by default.  The hit, punch, kick, butt and crush attacks return true.
    /// </summary>
    public override bool AttackStunsTarget { get; } = false;

    /// <summary>
    /// Returns true, if the attack cuts the target; false otherwise.  Returns false, by default.  The hit, claw and bite attacks all return true.
    /// </summary>
    public override bool AttackCutsTarget { get; } = false;

    /// <summary>
    /// Returns true, if the attack should render a message, if the attack touches the target and missed; false no message should be rendered.  Returns true, by default.  
    /// Only the crawl attack, requires touching the target and does not render a miss message.
    /// </summary>
    public override bool RendersMissMessage { get; } = true;
}
