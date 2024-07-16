﻿using MapsterMapper;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.BodyType;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class BodyTypeService(IMapper mapper, IBodyTypeRepository repository) : IBodyTypeService
{
    public IEnumerable<BodyTypeToGet> GetAll()
    {
        return repository.GetAll().Select(x => mapper.Map<BodyType, BodyTypeToGet>(x));
    }

    public BodyTypeToGet GetById(ulong id)
    {
        return mapper.Map<BodyType, BodyTypeToGet>(repository.GetByID(id));
    }
}
