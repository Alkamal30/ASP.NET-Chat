using Chat.Domain.Entities;
using Chat.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {

	public UserController(IUnitOfWorks unitOfWorks) {
		_unitOfWorks = unitOfWorks;
	}


	private IUnitOfWorks _unitOfWorks;



	[HttpGet]
	public IEnumerable<User> GetUsers() {
		return _unitOfWorks.UserRepository.GetAll();
	}

	[HttpGet("{userId}")]
	public User? GetUsersById(int userId) {
		return _unitOfWorks.UserRepository.GetFirstOrDefault(user => user.Id == userId);
	}

	[HttpPost]
	public IActionResult AddUser(User user) {

		_unitOfWorks.UserRepository.Add(user);
		_unitOfWorks.Save();

		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateUser(User user) {

		_unitOfWorks.UserRepository.Update(user);
		_unitOfWorks.Save();

		return Ok();
	}

	[HttpDelete]
	public IActionResult RemoveUser(User user) {

		_unitOfWorks.UserRepository.Remove(user);
		_unitOfWorks.Save();

		return Ok();
	}
}
