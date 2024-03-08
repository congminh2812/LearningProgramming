using AutoMapper;
using LearningProgramming.Application.Features.Message.Commands.CreateMessage;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.MappingProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<CreateMessageCommand, Message>();
        }
    }
}
