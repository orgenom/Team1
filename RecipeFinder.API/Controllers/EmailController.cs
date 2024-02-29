using RecipeFinder.DTO;
using RecipeFinder.Logic;
using Microsoft.AspNetCore.Mvc;


namespace RecipeFinder.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly EmailObject _emailObject;

        public EmailController(RecipeRepository repo)
        {
            _emailObject = new EmailObject(repo._configuration["BrevoKey"] ?? throw new Exception("null Brevo API key"));
        }

        [HttpGet("contacts")]
        public async Task<ActionResult<string>> GetAllContacts()
        {
            try
            {
                return Ok(await _emailObject.GetAllContacts());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("contact")]
        public async Task<ActionResult<string>> AddContact(string firstname, string lastname, string email)
        {
            try
            {
                _emailObject.AddContact(firstname, lastname, email);
                return Ok("Contact added");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("email")]
        public async Task<ActionResult<string>> SendEmail(string email, string subject, string content)
        {
            try
            {
                _emailObject.SendEmail(email, subject, content);
                return Ok("Email sent");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
