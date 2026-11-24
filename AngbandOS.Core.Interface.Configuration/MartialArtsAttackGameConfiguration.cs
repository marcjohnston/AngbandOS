using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MartialArtsAttackGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("int",
        Title = "Chance",
        Description = "Specifies the chance of performing the martial arts attack.")]
    public virtual int Chance { get; set; }

    [ConfigurationProperty("int",
        Title = "Damage Dice",
        Description = "Specifies the number of damage dice used by the attack.")]
    public virtual int Dd { get; set; }

    [ConfigurationProperty("string",
        Title = "Description",
        Description = "Specifies the description of the martial arts attack.")]
    public virtual string Desc { get; set; }

    [ConfigurationProperty("int",
        Title = "Damage Sides",
        Description = "Specifies the number of sides on each damage die.")]
    public virtual int Ds { get; set; }

    [ConfigurationProperty("string",
        Title = "Martial Arts Effect Binding Key",
        Description = "Specifies the binding key of the effect applied by the martial arts attack.")]
    public virtual string MartialArtsEffectBindingKey { get; set; }

    [ConfigurationProperty("int",
        Title = "Minimum Level",
        Description = "Specifies the minimum level at which the martial arts attack is available.")]
    public virtual int MinLevel { get; set; }

    [ConfigurationProperty("bool",
        Title = "Is Default",
        Description = "Determines whether the martial arts attack is the default attack.")]
    public virtual bool IsDefault { get; set; }
}
