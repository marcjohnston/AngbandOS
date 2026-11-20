using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MartialArtsAttackGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("int",
        Title = "Chance",
        Summary = "Specifies the chance of performing the martial arts attack.")]
    public virtual int Chance { get; set; }

    [ConfigurationProperty("int",
        Title = "Damage Dice",
        Summary = "Specifies the number of damage dice used by the attack.")]
    public virtual int Dd { get; set; }

    [ConfigurationProperty("string",
        Title = "Description",
        Summary = "Specifies the description of the martial arts attack.")]
    public virtual string Desc { get; set; }

    [ConfigurationProperty("int",
        Title = "Damage Sides",
        Summary = "Specifies the number of sides on each damage die.")]
    public virtual int Ds { get; set; }

    [ConfigurationProperty("string",
        Title = "Martial Arts Effect Binding Key",
        Summary = "Specifies the binding key of the effect applied by the martial arts attack.")]
    public virtual string MartialArtsEffectBindingKey { get; set; }

    [ConfigurationProperty("int",
        Title = "Minimum Level",
        Summary = "Specifies the minimum level at which the martial arts attack is available.")]
    public virtual int MinLevel { get; set; }

    [ConfigurationProperty("bool",
        Title = "Is Default",
        Summary = "Determines whether the martial arts attack is the default attack.")]
    public virtual bool IsDefault { get; set; }
}
