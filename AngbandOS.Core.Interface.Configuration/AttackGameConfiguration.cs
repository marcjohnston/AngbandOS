// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Attack",
    EntityNoun = "Attack")]
public class AttackGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the action message to be displayed, when the attack targets another monster.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Monster Action",
        Summary = "The action message displayed when the attack targets another monster.",
        DataType = "string")]
    public virtual string MonsterAction { get; set; }

    /// <summary>
    /// Returns the action message to be displayed, when the attack targets the player.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    [ConfigurationMetadataAttribute(
        Title = "Player Action Messages",
        Summary = "The action messages displayed when the attack targets the player.",
        DataType = "string[]?")]
    public virtual string[]? PlayerActionMessages { get; set; }

    /// <summary>
    /// Returns the action message to be displayed, when a description of the attack is being rendered to the player viewing
    /// their knowledge.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Knowledge Action",
        Summary = "The action message displayed when a description of the attack is rendered in the player's knowledge.",
        DataType = "string")]
    public virtual string KnowledgeAction { get; set; }

    /// <summary>
    /// Returns true, if the attack requires touching the target; false otherwise.  Returns true, by default.  The beg, drool, gaze, insult, moan, show, spit, 
    /// spore, wail and worship attacks do not require touching the target.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Attack Touches Target",
        Summary = "Determines whether the attack requires touching the target.",
        DataType = "bool")]
    public virtual bool AttackTouchesTarget { get; set; } = true;

    /// <summary>
    /// Returns true, if the attack awakes the target; false otherwise.  Returns false, by default,  The beg, insult, moan and show attacks
    /// return true.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Attack Awakens Target",
        Summary = "Determines whether the attack awakens the target.",
        DataType = "bool")]
    public virtual bool AttackAwakensTarget { get; set; } = false;

    /// <summary>
    /// Returns true, if the attack stuns the target; false otherwise.  Returns false, by default.  The hit, punch, kick, butt and crush attacks return true.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Attack Stuns Target",
        Summary = "Determines whether the attack stuns the target.",
        DataType = "bool")]
    public virtual bool AttackStunsTarget { get; set; } = false;

    /// <summary>
    /// Returns true, if the attack cuts the target; false otherwise.  Returns false, by default.  The hit, claw and bite attacks all return true.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Attack Cuts Target",
        Summary = "Determines whether the attack cuts the target.",
        DataType = "bool")]
    public virtual bool AttackCutsTarget { get; set; } = false;

    /// <summary>
    /// Returns true, if the attack should render a message, if the attack touches the target and missed; false no message should be rendered.  Returns true, by default.  
    /// Only the crawl attack, requires touching the target and does not render a miss message.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Renders Miss Message",
        Summary = "Determines whether a message is rendered when the attack touches the target but misses.",
        DataType = "bool")]
    public virtual bool RendersMissMessage { get; set; } = true;
}