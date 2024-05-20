using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface IBillService
    {
        string CreateBill(CreateBillRequest request);

        string PayBill(HttpContext context, double price, string movieName);

        string PayLastBillSuccess(string accessToken);
    }
}
