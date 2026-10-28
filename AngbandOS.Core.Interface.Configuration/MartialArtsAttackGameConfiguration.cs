using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Martial Arts Attack",
    EntityNoun = "martial arts attack")]
public class MartialArtsAttackGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Chance",
        Summary = "Specifies the chance of performing the martial arts attack.",
        DataType = "int")]
    public virtual int Chance { get; set; }

    [ConfigurationMetadata(
        Title = "Damage Dice",
        Summary = "Specifies the number of damage dice used by the attack.",
        DataType = "int")]
    public virtual int Dd { get; set; }

    [ConfigurationMetadata(
        Title = "Description",
        Summary = "Specifies the description of the martial arts attack.",
        DataType = "string")]
    public virtual string Desc { get; set; }

    [ConfigurationMetadata(
        Title = "Damage Sides",
        Summary = "Specifies the number of sides on each damage die.",
        DataType = "int")]
    public virtual int Ds { get; set; }

    [ConfigurationMetadata(
        Title = "Martial Arts Effect Binding Key",
        Summary = "Specifies the binding key of the effect applied by the martial arts attack.",
        DataType = "string")]
    public virtual string MartialArtsEffectBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Minimum Level",
        Summary = "Specifies the minimum level at which the martial arts attack is available.",
        DataType = "int")]
    public virtual int MinLevel { get; set; }

    [ConfigurationMetadata(
        Title = "Is Default",
        Summary = "Determines whether the martial arts attack is the default attack.",
        DataType = "bool")]
    public virtual bool IsDefault { get; set; }
}
