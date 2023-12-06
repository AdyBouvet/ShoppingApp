using ShopApp.Enums;

namespace ShopApp.Utils
{
    public class Output
    {
        public Output(OutputType type, string message)
        {
            Type = type;
            Message = message;
        }

        public OutputType Type { get; set; }
        public string Message { get; set; } = string.Empty;

    }

    public static class Out
    {
        public static Output Created(string name) =>
            new(OutputType.Success, $"{name} added to database");

        public static Output Added(string itemName, string listName) =>
            new(OutputType.Success, $"{itemName} added to {listName}");

        public static Output NotFound(string name) =>
            new(OutputType.Warning, $"{name} not found");

        public static Output NotFound(string itemName, string listName) =>
            new(OutputType.Warning, $"{itemName} not found in {listName}");

        public static Output Deleted(string name) =>
            new(OutputType.Success, $"{name} deleted");

        public static Output Removed(string itemName, string listName) =>
            new(OutputType.Success, $"{itemName} removed from {listName}");

        public static Output Exists(string name) =>
            new(OutputType.Warning, $"{name} already exists");

        public static Output CustomError(string message) =>
            new(OutputType.Error, message);

        public static bool Ok(this Output output) =>
            output.Type == OutputType.Success;
    }
}
