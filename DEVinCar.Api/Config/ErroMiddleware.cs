using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using Newtonsoft.Json;

namespace DEVinCar.Api.Config
{
    public class ErroMiddleware
    {

        private readonly RequestDelegate _next;
        public ErroMiddleware(RequestDelegate next){
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context){
            try{
                await _next(context);
            }catch(Exception ex){
                await TratamentoExcecao(context, ex);
            }
        }

        private  Task TratamentoExcecao(HttpContext context, Exception ex)
        {
            HttpStatusCode status; 
            string message; 

            if (ex is JaExisteException){
                status = HttpStatusCode.NotAcceptable;
                message = ex.Message;
            }
            else if (ex is NaoExisteException){
                status = HttpStatusCode.NotAcceptable;
                message = ex.Message;
            }
            else{
                status = HttpStatusCode.InternalServerError;
                message = "Ocorreu um erro favor contactar a TI";

            }

            var response = new ErrorDTO(message);

            context.Response.StatusCode = (int) status;

            return context.Response.WriteAsJsonAsync(response);
        
        }
    }
}