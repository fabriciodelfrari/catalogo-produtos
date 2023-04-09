namespace CatalogAPI.Domain.Model.ValueObjects.Authentication
{
    public class RegistrationResult
    {
        public bool Succeeded { get; set; }
        public ICollection<string> Errors { get; set; }

        public RegistrationResult()
        {
            Errors = new List<string>();
        }
    }
}
