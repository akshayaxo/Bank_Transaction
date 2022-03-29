using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Transaction.Models;

namespace Transaction
{
    public class AccountTransaction
    {
        [FunctionName("AccountTransaction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Received new transaction request");
            string Message = "Starting Http Request";
            try
            {
                var content = await new StreamReader(req.Body).ReadToEndAsync();

                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(content);
                if (transaction != null)
                {
                    log.LogInformation("Saving to database");
                    using (var db = new BankContext())
                    {
                        account useraccount = db.accounts.Where(c => c.custid == transaction.Account).FirstOrDefault();
                        var trans = new trandetail()
                        { 
                            tnumber = transaction.Id,
                            acnumber = useraccount.acnumber,
                            dot = DateTime.Today,
                            transaction_type = transaction.Direction,
                            transaction_amount = transaction.Amount
                        };
                        db.trandetails.Add(trans);
                        await db.SaveChangesAsync();
                        Message = "DB updated successfully";
                    }
                }
                else
                {
                    var errorMessage = "No account found";
                    log.LogError(errorMessage);
                }
            }
            catch (Exception e)
            {
                log.LogError(e.Message, e);
            }
            return new OkObjectResult(Message);
        }
    }
}
