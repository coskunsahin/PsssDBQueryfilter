using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsssD.Service;

namespace PsssD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarservice carservice;

        public CarController(ICarservice _carservice)
        {
            carservice= _carservice;

        }
        [HttpGet("carlist")]
        public IEnumerable<Car> CarsList()
        {
            var carlist = carservice.GetCarList();

            return carlist;
        }
        [HttpGet("getcarbyid")]
        public Car GetCarById(int Id)
        {
            return carservice.GetCarById(Id);
        }
        [HttpPost("addcar")]
        public Car AddCar(Car car)
        {

            var carData = carservice.AddCar(car);
            //send the inserted product data to the queue and consumer will listening this data from queue

            return carData;
        }
        [HttpGet("Search")]
        public IActionResult Search(
           [FromQuery(Name = "s")] string s,
           [FromQuery(Name = "sort")] string sort,
           [FromQuery(Name = "page")] int page
       )
        {
            return Ok(carservice.Search(s, sort, page));
        }

        [HttpGet("Pagelist")]
        public IActionResult Pagelist(
          
          [FromQuery(Name = "sort")] string sort,
          [FromQuery(Name = "page")] int page
      )
        {
            return Ok(carservice.Pagelist( sort, page));
        }
        [HttpGet("specific")]
        public IActionResult Specific(string specific)

         
     
        {
            return Ok(carservice.Specific(specific));
        }

        [HttpGet("delivery")]
        public IActionResult Delivery(string delivery)



        {
            return Ok(carservice.Delivery(delivery));
        }
        [HttpPost("Postdatas")]
        public IActionResult Postdatas(
           [FromQuery(Name = "name")] string name,
           [FromQuery(Name = "status")] string status,
           [FromQuery(Name = "mil")] int mil,
           [FromQuery(Name = "94596")] int zipcode,
            [FromQuery(Name = "100000")] int price
       )

        {
            return Ok(carservice.Postdata(name,status,mil,zipcode,price));
        }
    }
}
