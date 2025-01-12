using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Application.HadlerResponse
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public List<StaticTariff?> Data { get; set; }
        public Response(string message, int status)
        {
            Message = message;
            Status = status;
        }
        public Response(string message, int status, List<StaticTariff?> data)
        {
            Message = message;
            Status = status;
            Data = data;
        }
    }
}
