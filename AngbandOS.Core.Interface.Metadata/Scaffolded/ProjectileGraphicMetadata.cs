// <auto-generated>
// This code was generated by scaffold-metadata.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
namespace AngbandOS.Core.Interface.Metadata;

public static class ProjectileGraphicMetadata
{
    public static PropertyMetadata[] Metadata
    {
        get
        {
            return new PropertyMetadata[]
            {
                new StringPropertyMetadata("Key")
                {
                    DefaulDefaultValuetValue = null,
                    Description = "",
                    IsNullable = false,
                    Title = "Key",
                    CategoryTitle = "",
                },
                new CharacterPropertyMetadata("Character")
                {
                    DefaultValue = null,
                    Description = "Returns the character to be used for the projectile.",
                    IsNullable = false,
                    Title = "Character",
                    CategoryTitle = "",
                },
                new ColorPropertyMetadata("Color")
                {
                    DefaultValue = ColorEnum.White,
                    Description = "Returns the color to be used for the projectile.",
                    IsNullable = false,
                    Title = "Color",
                    CategoryTitle = "",
                },
            };
        }
    }
}