namespace NFSystem.Results
{
    public class ImportInvoiceResult
    {
        public IReadOnlyCollection<ImportSuccess> Successes => _successes;
        public IReadOnlyCollection<ImportError> Errors => _errors;

        private readonly List<ImportSuccess> _successes = new();
        private readonly List<ImportError> _errors = new();

        public bool HasSuccess => _successes.Any();
        public bool HasErrors => _errors.Any();
        public bool IsSuccess => HasSuccess && !HasErrors;
        public bool IsFailure => !HasSuccess && HasErrors;

        public void AddSuccess(string fileName, string invoiceNumber)
        {
            _successes.Add(new ImportSuccess
            {
                FileName = fileName,
                InvoiceNumber = invoiceNumber
            });
        }

        public void AddError(string fileName, string message, ImportErrorType type)
        {
            _errors.Add(new ImportError
            {
                FileName = fileName,
                Message = message,
                Type = type
            });
        }
    }
}
