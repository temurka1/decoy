namespace Decoy.Domain.Services
{
    using Decoy.Domain.Models;

    public interface IQuoteGenerator
    {
        IEnumerable<QuoteItem> GetQuote(ProjectSettings projectSettings);
    }
}
