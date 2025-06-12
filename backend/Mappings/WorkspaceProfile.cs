using AutoMapper;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Mappings
{
    public class WorkspaceProfile : Profile
    {
        public WorkspaceProfile()
        {
            CreateMap<Workspace, WorkspaceResponseDto>();
            CreateMap<CreateWorkspaceDto, Workspace>();
        }
    }
}
