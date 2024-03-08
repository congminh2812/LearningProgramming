﻿using LearningProgramming.Application.Features.Message.Queries.GetMessages;

namespace LearningProgramming.Application.Models.Message
{
    public class ChatUsersResponse
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public MessageDto Message { get; set; }
    }
}