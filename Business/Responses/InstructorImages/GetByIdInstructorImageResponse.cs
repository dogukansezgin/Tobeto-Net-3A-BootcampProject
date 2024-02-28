﻿namespace Business.Responses.InstructorImages;

public class GetByIdInstructorImageResponse
{
    public Guid Id { get; set; }
    public int InstructorId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}