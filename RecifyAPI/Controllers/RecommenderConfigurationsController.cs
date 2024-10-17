using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RecifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderConfigurationsController : ControllerBase
    {

        private readonly IRecommenderConfigurationService _recommenderConfigurationService;

        public RecommenderConfigurationsController(IRecommenderConfigurationService recommenderConfigurationService)
        {
            _recommenderConfigurationService = recommenderConfigurationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfiguration([FromBody] RecommenderConfigurationModel configuration)
        {
            var result = await _recommenderConfigurationService.CreateConfigurationAsync(configuration);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(string id, [FromBody] RecommenderConfigurationModel configuration)
        {
            var result = await _recommenderConfigurationService.UpdateConfigurationAsync(configuration);
            return Ok(result);
        }


        [HttpDelete("{configurationId}")]
        public async Task<IActionResult> DeleteConfiguration(string configurationId)
        {
            var result = await _recommenderConfigurationService.DeleteConfigurationAsync(configurationId);
            return result.Match<IActionResult>(
                _ => NoContent(),
                error => BadRequest(new { error.Message, error.HttpCode })
            );
        }


        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetConfigurationsForClient(string clientId)
        {
            var configurations = await _recommenderConfigurationService.GetConfigurationsForClientAsync(clientId);
            return Ok(configurations);
        }


    }
}
