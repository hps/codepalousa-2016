using System.Web.Mvc;
using SecureSubmit.Entities;
using SecureSubmit.Infrastructure;
using SecureSubmit.Services;

using CodePaLousa.ViewModels;
using SecureSubmit.Fluent.Services;
using System.Configuration;

namespace CodePaLousa.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View(new PaymentDetails
            {
                PublicKey = ConfigurationManager.AppSettings["PublicKey"],
                Amount = 1.00m
            });
        }

        [HttpPost]
        public ActionResult Process(PaymentDetails details)
        {
            var config = new HpsServicesConfig
            {
                SecretApiKey = ConfigurationManager.AppSettings["SecretKey"]
            };
            var service = new HpsFluentCreditService(config);
            HpsAuthorization response = null;

            try
            {
                response = service.Authorize()
                    .WithAmount(details.Amount)
                    .WithToken(details.PaymentToken)
                    .WithCardHolder(new HpsCardHolder
                    {
                        Address = new HpsAddress { Zip = details.BillingZip }
                    })
                    .Execute();
            }
            catch (HpsException e)
            {

            }
            return View(response);
        }
    }
}