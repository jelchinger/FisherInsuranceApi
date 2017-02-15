using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/claim")]
public class ClaimsController : Controller
{
    // POST api/claims/claim
    
    private IMemoryStore db;

    public ClaimsController(IMemoryStore repo){

        db = repo;

    }

     public IActionResult GetClaims() {

        return Ok(db.RetrieveAllClaims);

    }

    [HttpPost]
    public IActionResult Post([FromBody]Claim claim)
    {
        return Ok(db.CreateClaim(claim));
    }

    // GET api/claims/claim/5

    [HttpGet("{id}")]
    public IActionResult Get(int id) 
    {
        return Ok(db.RetrieveClaim(id));
    }

    // PUT api/claims/claim/id

    [HttpPut]
    public IActionResult Put([FromBody]Claim claim) 
    {
        return Ok(db.UpdateClaim(claim));
    }

    // DELETE api/claims/claim/id

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        db.DeleteClaim(id);
        
        return Ok();
    }
}