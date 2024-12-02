using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Extensions;
using Xceed.Words.NET;

namespace URAL.Controllers;

[Route("api/[controller]/[action]")]
[Authorize()]
[ApiController]
public class DocumentController(IDocumentService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DocX>> GetDocuments(string userId)
    {
        var id = User.GetUserIdFromClaim();
        var doc = await service.Generate(id, userId);
        return doc;
    }
}