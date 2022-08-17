using System.Text.Json.Serialization;

namespace WEB_API_Udemy.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1, Mage = 2, Archer = 3
    }
}