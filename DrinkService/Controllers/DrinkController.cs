using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrinkService.Core.Models;
using DrinkService.Core.Services;
using DrinkService.Core.Validation;
using DrinkService.RequestModels;
using DrinkService.ResponseModels;

namespace DrinkService.Controllers
{
    public class DrinkController : ApiController
    {
        private readonly IDrinkService _drinkService;
        private readonly IDrinkValidator _drinkValidator;

        public DrinkController(IDrinkService drinkService, IDrinkValidator drinkValidator)
        {
            this._drinkService = drinkService;
            this._drinkValidator = drinkValidator;
        }

        public HttpResponseMessage GetAll()
        {
            var drinkList = _drinkService.GetAll();
            var drinkListObject = new DrinkList()
            {
                Data = drinkList.ToList(),
                Count = drinkList.ToList().Count()
            };

            return Request.CreateResponse<DrinkList>(HttpStatusCode.OK, drinkListObject);
        }

        public HttpResponseMessage Get(string id)
        {
            try
            {
                var drink = _drinkService.Get(id);
                return Request.CreateResponse<Drink>(HttpStatusCode.OK, drink);
            }
            catch (InvalidOperationException ex)
            {
                var responseError = new ResponseError() { Errors = new List<string>() { ex.Message } };
                return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
            }
        }

        public HttpResponseMessage Post(DrinkCreate drinkCreateData)
        {
            var drink = new Drink()
            {
                Name = drinkCreateData.Name,
                Quantity = drinkCreateData.Quantity
            };

            var validationResult = _drinkValidator.Validate(drink);

            try
            {
                if (validationResult.IsValid)
                {
                    var drinkResult = _drinkService.Create(drink);
                    return Request.CreateResponse<Drink>(HttpStatusCode.OK, drinkResult);
                }
                else
                {
                    var responseError = new ResponseError() { Errors = validationResult.ErrorList };
                    return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
                }
            }
            catch (ArgumentException ex)
            {
                var responseError = new ResponseError() { Errors = new List<string>() { ex.Message } };
                return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
            }            
        }

        public HttpResponseMessage Put(string id, DrinkUpdate updateDrinkData)
        {
            var drink = new Drink()
            {
                Id = id,
                Name = updateDrinkData.Name != null ? updateDrinkData.Name : " ",
                Quantity = updateDrinkData.Quantity
            };

            var validationResult = _drinkValidator.Validate(drink);
            try
            {
                if (validationResult.IsValid)
                {
                    var drinkResult = _drinkService.Update(drink);
                    return Request.CreateResponse<Drink>(HttpStatusCode.OK, drinkResult);
                }
                else
                {
                    var responseError = new ResponseError() { Errors = validationResult.ErrorList };
                    return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
                }
            }
            catch (ArgumentException ex)
            {
                var responseError = new ResponseError() { Errors = new List<string>() { ex.Message } };
                return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
            }
        }

        // DELETE: api/Drinks/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                _drinkService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (InvalidOperationException ex)
            {
                var responseError = new ResponseError() { Errors = new List<string>() { ex.Message } };
                return Request.CreateResponse<ResponseError>(HttpStatusCode.BadRequest, responseError);
            }            
        }
    }
}
