namespace NFSystem.Results
{
    public class ImportError
    {
        public string FileName { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public ImportErrorType Type { get; init; }
    }

    public enum ImportErrorType
    {
        Validation,
        InvalidFormat,
        Parsing,
        Unexpected
    }
}
