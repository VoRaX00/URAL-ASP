using System.Reflection.Metadata;
using Xceed.Words.NET;

namespace URAL.Application.IServices;

public interface IDocumentService
{
    public Task<DocX> Generate(string firstUserId, string secondUserId);
}