using AutoMapper;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mapping;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        // Entity to DTO
        CreateMap<UserTask, TaskDto>();
        CreateMap<Note, NoteDto>();

        // DTO to Entity
        CreateMap<TaskDto, UserTask>();
        CreateMap<NoteDto, Note>();

        // CreateTaskDto to Task
        CreateMap<CreateTaskDto, UserTask>();
    }
}