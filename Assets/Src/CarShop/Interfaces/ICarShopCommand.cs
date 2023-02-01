using Src.Models;

namespace Src.CarShop.Interfaces
{
    public interface ICarShopCommand
    {
        void Execute(Car car);
    }
}