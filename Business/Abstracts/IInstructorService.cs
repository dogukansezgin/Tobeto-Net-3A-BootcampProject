﻿using Business.Requests.Instructors;
using Business.Responses.Instructors;

namespace Business.Abstracts;

public interface IInstructorService
{
    CreateInstructorResponse Add(CreateInstructorRequest request);
    DeleteInstructorResponse Delete(DeleteInstructorRequest request);
    UpdateInstructorResponse Update(UpdateInstructorRequest request);
    GetByIdInstructorResponse GetById(int id);
    List<GetAllInstructorResponse> GetAll();
}