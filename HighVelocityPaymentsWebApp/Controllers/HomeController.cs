namespace HighVelocityPaymentsWebApp.Controllers
{
    using System.Web.Mvc;
    using HighVelocityPaymentsLibrary;
    using HighVelocityPaymentsLibrary.DataAccess;
    using HighVelocityPaymentsLibrary.Model;

    public class HomeController : Controller
    {
        private readonly GetAllEmployees getAllEmployees;
        private readonly CreateEmployee createEmployee;
        private readonly GetEmployee getEmployee;
        private readonly DeleteEmployee deleteEmployee;
        private readonly EmployeeBenefitsCalculator benefitsCalculator;

        public HomeController(GetAllEmployees getAllEmployees, CreateEmployee createEmployee, GetEmployee getEmployee, EmployeeBenefitsCalculator benefitsCalculator, DeleteEmployee deleteEmployee)
        {
            this.getAllEmployees = getAllEmployees;
            this.createEmployee = createEmployee;
            this.getEmployee = getEmployee;
            this.benefitsCalculator = benefitsCalculator;
            this.deleteEmployee = deleteEmployee;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var listOfAllEmployees = getAllEmployees.Execute();

            return View(listOfAllEmployees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            createEmployee.Execute(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var employee = getEmployee.Execute(id);
            var employeeBenefitCosts = benefitsCalculator.CalculateEmployeeBenefitCost(employee);

            return View(employeeBenefitCosts);
        }

        public ActionResult Delete(int id)
        {
            deleteEmployee.Execute(id);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Chris Brannon's oh-so-generic Contact Page.";

            return View();
        }
    }
}
