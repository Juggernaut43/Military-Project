using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        [HttpGet(Name = "CheckCreditCard")]
        public bool Get(string cardNumberStr, string cvvStr, DateOnly ExpDate)
        {
            //Check the date
            if (DateOnly.FromDateTime(DateTime.Now) > ExpDate)
            {
                return false;
            }

            int cvv;

            //check if cvv is a number
            if (!int.TryParse(cvvStr, out cvv))
            {
                return false;
            }

            //check cvv
            if (cvv < 100 || cvv > 999)
            {
                return false;
            }

            long cardNumber;
            //check if cvv is a number
            if (!long.TryParse(cardNumberStr, out cardNumber))
            {
                return false;
            }
            //check number
            if (cardNumber < 1000000000000000 || cardNumber > 9999999999999999)
            {
                return false;
            }
            return true;
        }
    }
}
