using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Core.DTOs
{
    public sealed class ServiceResponse<T>
    {
        public T Data { get;  set; }
        public bool IsSuccess => !Errors.Any() && Data != null;
        public int ResultCode { get;  set; } = StatusCodes.Status200OK;
        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

      
    }
}
