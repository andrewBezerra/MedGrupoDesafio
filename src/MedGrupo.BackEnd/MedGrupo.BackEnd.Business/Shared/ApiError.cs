﻿namespace MedGrupo.BackEnd.Business.Shared
{
    public class ApiError
    {
        public string Title { get; }
        public string Message { get; }

        public ApiError(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
