﻿using Business.Requests.Applicants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public Applicant CheckApplicantUpdate(Applicant applicant, UpdateApplicantRequest request)
    {
        applicant.UserName = request.UserName != "string" || request.UserName != null ? request.UserName : applicant.UserName;
        applicant.FirstName = request.FirstName != "string" || request.FirstName != null ? request.FirstName : applicant.FirstName;
        applicant.LastName = request.LastName != "string" || request.LastName != null ? request.LastName : applicant.LastName;
        applicant.About = request.About != "string" || request.About != null ? request.About : applicant.About;
        applicant.NationalIdentity = request.NationalIdentity != "string" || request.NationalIdentity != null ? request.NationalIdentity : applicant.NationalIdentity;
        applicant.Email = request.Email != "string" || request.Email != null ? request.Email : applicant.Email;
        var passwordHash = request.PasswordHash.ToString();
        applicant.PasswordHash = passwordHash != "string" || request.PasswordHash != null ? request.PasswordHash : applicant.PasswordHash;
        var passwordSalt = request.PasswordSalt.ToString();
        applicant.PasswordSalt = passwordSalt != "string" || request.PasswordSalt != null ? request.PasswordSalt : applicant.PasswordSalt;
        //applicant.DateOfBirth eklenecek.

        applicant.UpdatedDate = DateTime.UtcNow;
        return applicant;
    }

    public void CheckIfApplicantIdExist(Guid id)
    {
        var isExist = _applicantRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Applicant is not exists.");
    }

    public void CheckIfApplicantNotExist(Applicant applicant)
    {
        var isExistId = _applicantRepository.Get(x => x.Id == applicant.Id) is not null;
        var isExistUserName = _applicantRepository.Get(x => x.UserName.Trim() == applicant.UserName.Trim()) is not null;
        var isExistNationalId = _applicantRepository.Get(x => x.NationalIdentity.Trim() == applicant.NationalIdentity.Trim()) is not null;
        var isExistEmail = _applicantRepository.Get(x => x.Email.Trim() == applicant.Email.Trim()) is not null;
        if (isExistId || isExistUserName || isExistNationalId || isExistEmail) throw new BusinessException("Applicant already exists.");
    }
}
