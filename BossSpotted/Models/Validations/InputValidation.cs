using BossSpotted.Models.EntityFramework;

namespace BossSpotted.Models.Validations
{
    public class InputValidation
    {
        public InputValidation()
        {
            
        }

        public bool ValidateSightingSeriousness(int seriousness)
        {
            return Enum.IsDefined(typeof(SightingSeriousness), seriousness);
        }
    }
}
