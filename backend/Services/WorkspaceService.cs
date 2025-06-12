using AutoMapper;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IWorkspaceService
    {
        Task<IEnumerable<WorkspaceResponseDto>> GetAllAsync();
        Task<WorkspaceResponseDto> CreateAsync(CreateWorkspaceDto dto, Guid creatorUserId);
        Task<bool> AddMemberAsync(Guid workspaceId, AddMemberDto dto);
    }

    public class WorkspaceService : IWorkspaceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkspaceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkspaceResponseDto>> GetAllAsync()
        {
            var workspaces = await _context.Workspaces.ToListAsync();
            return _mapper.Map<IEnumerable<WorkspaceResponseDto>>(workspaces);
        }

        public async Task<WorkspaceResponseDto> CreateAsync(CreateWorkspaceDto dto, Guid creatorUserId)
        {
            var workspace = _mapper.Map<Workspace>(dto);
            workspace.Id = Guid.NewGuid();

            _context.Workspaces.Add(workspace);

            // Ajouter le créateur comme admin
            var membership = new WorkspaceMembership
            {
                Id = Guid.NewGuid(),
                UserId = creatorUserId,
                WorkspaceId = workspace.Id,
                Role = "Admin"
            };
            _context.WorkspaceMemberships.Add(membership);

            await _context.SaveChangesAsync();
            return _mapper.Map<WorkspaceResponseDto>(workspace);
        }

        public async Task<bool> AddMemberAsync(Guid workspaceId, AddMemberDto dto)
        {
            var exists = await _context.WorkspaceMemberships
                .AnyAsync(m => m.UserId == dto.UserId && m.WorkspaceId == workspaceId);
            if (exists) return false;

            var membership = new WorkspaceMembership
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                WorkspaceId = workspaceId,
                Role = dto.Role
            };

            _context.WorkspaceMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
