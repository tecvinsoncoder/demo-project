namespace DemoProject.Shared
{
    public class Error
    {
        private string? Code { get; set; }
        private string? Description { set; get; }

        public Error(string code, string? description = null )
        {
            Code = code;
            Description = description;
        }

        public static readonly Error None = new (string.Empty);
        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}