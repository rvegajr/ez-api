[Route("odata/AreaTeams")]
public class AreaTeamController : ODataController
{
    private readonly EzDbContext _ctx;
    public AreaTeamController(EzDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet("")]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_ctx.AreaTeams?.AsQueryable());
    }
}