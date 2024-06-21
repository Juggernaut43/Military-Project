using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternalWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        // GET: api/<CreditController>
        [HttpGet]
        public bool Get(string cardNumberStr, string cvvStr, string ExpDate)
        {
            //Check the date
            if (DateTime.Now > DateTime.Parse(ExpDate))
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
