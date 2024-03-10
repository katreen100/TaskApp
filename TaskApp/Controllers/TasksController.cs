using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TaskApp.core;
using TaskApp.core.DTOS;
using TaskApp.core.model;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to this controller

    public class TasksController : ControllerBase
    {
        private readonly Iunitofwork _Iunitofwork;
        private readonly ILogger<TasksController> _logger;
        private readonly IMapper _mapper;
        public TasksController(Iunitofwork iunitofwork, ILogger<TasksController> logger, IMapper mapper)
        {
            _Iunitofwork = iunitofwork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _Iunitofwork.Tasks.GetById(id);

                if (task == null)
                {
                    return NotFound("The task does not exist.");
                }
                else
                {
                    return Ok(task);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        } [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var task = await _Iunitofwork.Tasks.GetAllAsync();
               if (task!= null)
                {
                    return Ok(task);

                }
                else
                {
                    return Ok(new List<Taskmodel>());
                }
                
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("GetRang")]
        public async Task<IActionResult> GetRang(int take, int skip)
        {
            try
            {
                var task = await _Iunitofwork.Tasks.FindRangeAsync(take, skip);

                return Ok(task);
                
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] TaskDto model)
        {
            try
            {
                Taskmodel task = _mapper.Map<Taskmodel>(model);
                var Addedtask = await _Iunitofwork.Tasks.AddAsync(task);
                _Iunitofwork.complete();
                
                    return Ok(Addedtask);
                
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        } [HttpPost("UpadateTask")]
        public  IActionResult UpadateTask([FromBody] Taskmodel model)
        {
            try
            {
                var task =  _Iunitofwork.Tasks.Update(model);
                _Iunitofwork.complete();

                return Ok(task);
                
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("DeleteTask")]
        public async Task<IActionResult> DeleteTask( int id )
        {
            try
            {
                var task = await _Iunitofwork.Tasks.GetById(id);
                _Iunitofwork.Tasks.Delete(task);
                _Iunitofwork.complete();

                return Ok();
                
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
