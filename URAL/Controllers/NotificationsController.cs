﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Notification;
using URAL.Extensions;
using URAL.Filters.ActionFilters;

namespace URAL.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class NotificationsController(INotificationsService service) : ControllerBase
{
    [PageNumberFilter]
    [HttpGet]
    public PaginatedList<NotificationToGet> GetUserMatch([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = service.GetUserMatchAsync(userId, pageNumber);
        return result;
    }

    [PageNumberFilter]
    [HttpGet]
    public PaginatedList<NotificationToGet> GetUserNotifications([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = service.GetUserNotificationsAsync(userId, pageNumber);
        return result;
    }

    [PageNumberFilter]
    [HttpGet]
    public PaginatedList<NotificationToGet> GetUserResponses([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = service.GetUserResponsesAsync(userId, pageNumber);
        return result;
    }
}
