﻿using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBootcampImageRepository : ISyncRepository<BootcampImage, Guid>
{
}
