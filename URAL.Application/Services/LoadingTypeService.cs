﻿using MapsterMapper;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.LoadingType;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class LoadingTypeService(IMapper mapper, ILoadingTypeRepository repository) : ILoadingTypeService
{
    public IEnumerable<LoadingTypeToGet> GetAll()
    {
        return repository.GetAll().Select(x => mapper.Map<LoadingType, LoadingTypeToGet>(x));
    }

    public LoadingTypeToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity == null)
            return null;

        return mapper.Map<LoadingType, LoadingTypeToGet>(entity);
    }
}
