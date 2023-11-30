using Microsoft.AspNetCore.Mvc;
using ToDoList_API.Models;

namespace ToDoList_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        TaskContext db = new TaskContext();


        [HttpPost(template:"Registration")]
        public async Task<ActionResult<UserT>> RegistrUser(UserT userdata)
        {
            if (db.UserTs.FirstOrDefault(z => z.Username == userdata.Username) != null)
            {
                return BadRequest("Пользователь с таким именем уже существует");
            }
            else if (userdata.Username == "" || userdata.PasswordHash == "")
            {
                return BadRequest("Заполните все поля");
            }
            else
            {
                db.UserTs.Add(userdata);
                db.SaveChanges();
                return Ok(userdata);
            }

            return NotFound();
        }

        [HttpGet("{Username}")]
        public async Task<ActionResult<UserT>> GetUserinfo(string Username)
        {
            if (Username != "" && Username != null)
            {
                UserT GetUser = db.UserTs.FirstOrDefault(z => z.Username == Username);

                if (GetUser != null)
                {
                    return Ok(GetUser);
                }
                else
                {
                    return NotFound("Пользователь не найден");
                }
            }
            else
            {
                return BadRequest("Укажите имя пользователя");
            }
        }

        [HttpGet("Task/{IdUser}")]
        public async Task<ActionResult<TaskT>> GetTask(int IdUser)
        {
            if (IdUser != null)
            {
                var GetTask = db.TaskTs.Where(z => z.UserId == IdUser).ToList();
                if (GetTask == null)
                {
                    return NotFound("Задачи не найдены");
                }
                else
                {
                    return Ok(GetTask);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost(template:"CreateTask")]
        public async Task<ActionResult<TaskT>> CreateTask(TaskT NewTask)
        {
            if (NewTask != null)
            {
                db.TaskTs.Add(NewTask);
                db.SaveChanges();
                return Ok(NewTask);
            }
            else
            {
                return BadRequest("Заполните поля");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TaskT>> UpdateTask()
        {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<TaskT>> DeleteTask()
        {
            return null;
        }
    }
}
