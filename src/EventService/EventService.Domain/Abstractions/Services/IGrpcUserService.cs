using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Domain.Abstractions.Services;

public interface IGrpcUserService
{
    Task<UserGrpcDto> GetUser(Guid userId);
}
