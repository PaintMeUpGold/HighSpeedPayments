namespace HighVelocityPaymentsWebApp.Controllers
{
    using System.Web.Mvc;
    using HighVelocityPaymentsLibrary;
    using HighVelocityPaymentsLibrary.Model;

    public class BenefitsCostController : Controller
    {
        //
        // GET: /BenefitsCost/
        public string Index()
        {
            return "Hello from the Benefits Costs Controller";
        }

        //
        // GET: /BenefitsCost/Details/[some employee id]
        public ActionResult Details(int id)
        {
            var employee = new Employee {Id = id, Name = "Chris Brannon", NumberOfDependents = 2};
            return View(employee);
        }
    }
}
