using Microsoft.EntityFrameworkCore;
using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PsssD.Service
{
    public class Carservice : ICarservice
    {
        private readonly ApplicationContext _dbContext;

        public Carservice(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Car AddCar(Car cars)
        {
            var result = _dbContext.Cars.Add(cars);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public object Delivery(string delivery)
        {
            return _dbContext.Cars.Where(x => x.Delivery == delivery).Select(v => new { v.CarId, v.Mil, v.Status, v.Delivery, v.Name, v.Model, v.Price, v.Specific, v.Zipcode }).OrderByDescending(x=>x.Delivery);
            
        }

        public IList<Car> Get()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetCarList()
        {
            return _dbContext.Cars.ToList();
        }

        public object Pagelist(string sort, int? queryPage)
        {
            var query = (from Car
                  in _dbContext.Cars
                         select Car);



            if (sort == "asc")
            {
                query = query.OrderBy(p => p.Price);
            }
            else if (sort == "desc")
            {
                query = query.OrderByDescending(p => p.Price);
            }


            int perPage = 2;
            int page = queryPage.GetValueOrDefault(1) == 0 ? 1 : queryPage.GetValueOrDefault(1);
            var total = query.Count();

            return new
            {
                data = query.Skip((page - 1) * perPage).Take(perPage),
                total,
                page,
                last_page = total / perPage
            };
        }

        public object Postdata(string name, string status, int? mil, int? zipcode, int? price
            )
        {
            var ar = _dbContext.Cars.Where(x => x.Name == name || x.Status == status || x.Mil == int.MaxValue || x.Mil == mil || x.Zipcode == zipcode || x.Zipcode == 94596 || x.Price == price && x.Price == 100000).Select(v => new { v.CarId, v.Mil, v.Status, v.Delivery, v.Name, v.Model, v.Price, v.Specific, v.Zipcode });
            return ar.ToList();

        }







        public object Search(string s, string sort, int? queryPage)
        {
            var query = (from Car
                   in _dbContext.Cars
                         select Car);

            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(p => p.Name.Contains(s) || p.Model.Contains(s) || p.Specific.Contains(s) ||
                p.Zipcode.ToString().Contains(s) || p.Delivery.ToString().Contains(s) || p.Mil.ToString().Contains(s) || p.Status.ToString().Contains(s) ||
                p.Price.ToString().Contains(s)).OrderByDescending(x => x.Delivery);
            }

            if (sort == "asc")
            {
                query = query.OrderBy(p => p.Price);
            }
            else if (sort == "desc")
            {
                query = query.OrderByDescending(p => p.Price);
            }


            int perPage = 2;
            int page = queryPage.GetValueOrDefault(1) == 0 ? 1 : queryPage.GetValueOrDefault(1);
            var total = query.Count();

            return new
            {
                data = query.Skip((page - 1) * perPage).Take(perPage),
                total,
                page,
                last_page = total / perPage
            };
        }

        public object Specific(string specific)
        {
            return _dbContext.Cars.Where(x => x.Specific == specific).FirstOrDefault();
        }
    }




}

