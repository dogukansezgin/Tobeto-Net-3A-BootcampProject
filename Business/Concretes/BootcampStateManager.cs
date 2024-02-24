﻿using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }
    public IDataResult<CreateBootcampStateResponse> Add(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        _bootcampStateRepository.Add(bootcampState);

        CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(response, "Added Succesfully");
    }

    public IDataResult<DeleteBootcampStateResponse> Delete(DeleteBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        _bootcampStateRepository.Delete(bootcampState);

        DeleteBootcampStateResponse response = _mapper.Map<DeleteBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<DeleteBootcampStateResponse>(response, "Deleted Succesfully");
    }

    public IDataResult<List<GetAllBootcampStateResponse>> GetAll()
    {
        List<BootcampState> bootcampState = _bootcampStateRepository.GetAll();
        List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampState);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdBootcampStateResponse> GetById(int id)
    {
        BootcampState bootcampState = _bootcampStateRepository.Get(x => x.Id == id);
        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBootcampStateResponse> Update(UpdateBootcampStateRequest request)
    {
        BootcampState bootcampState = _bootcampStateRepository.Get(u => u.Id == request.Id);
        bootcampState.Name = request.Name ?? bootcampState.Name;
        bootcampState.UpdatedDate = DateTime.UtcNow;
        _bootcampStateRepository.Update(bootcampState);

        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Updated Succesfully");
    }
}
