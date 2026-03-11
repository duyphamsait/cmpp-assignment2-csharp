using cmpp_assignment2_csharp.Controllers;

namespace cmpp_assignment2_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnrollmentController controller = new EnrollmentController();
            controller.Run();
        }
    }
}