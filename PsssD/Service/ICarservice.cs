namespace PsssD.Service
{
    public interface ICarservice
    {
        public IEnumerable<Car> GetCarList();
        public Car GetCarById(int id);
        public Car AddCar (Car cars);
        public Object Search(string s, string sort, int? queryPage);

        public Object Pagelist (string sort, int? queryPage);

        public Object Specific(string specific);
        public Object Delivery(string delivery);
        public Object Postdata(string name,string status, int? mil,int? zipcode,int? price);
    }
}
