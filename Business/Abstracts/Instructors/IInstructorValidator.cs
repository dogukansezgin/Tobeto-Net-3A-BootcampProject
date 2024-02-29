using Business.Requests.Instructors;
using Entities.Concretes;

namespace Business.Abstracts.Instructors;

public interface IInstructorValidator
{
    void CheckIfInstructorNotExist(Instructor ınstructor);
    void CheckIfInstructorIdExist(int id);
    Instructor CheckInstructorUpdate(Instructor ınstructor, UpdateInstructorRequest request);
}
