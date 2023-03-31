using Chat.Application.Interfaces.Repository;
using Chat.Domain.Entities;
using Chat.Domain.ViewModels;
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


	[HttpPost("Register")]
	public IActionResult Register(UserRegistrationViewModel registrationViewModel) {

		if(!ModelState.IsValid)
			return BadRequest("Registration ViewModel is not valid!");

		try {
			User user = new User() {
				Login = registrationViewModel.Login,
				Password = registrationViewModel.Password
			};

			_unitOfWorks.UserRepository.Add(user);
			_unitOfWorks.Save();

			return Ok(user);
		}
		catch(Exception exception) {
			return BadRequest(exception.Message);
		}
	}

	[HttpPost("Authorize")]
	public IActionResult Authorize(UserAuthorizationViewModel authorizationViewModel) {

		if(!ModelState.IsValid)
			return BadRequest("Authorization ViewModel is not valid!");

		try {
			User? user = _unitOfWorks.UserRepository
				.GetFirstOrDefault(
					u => u.Login == authorizationViewModel.Login 
					&& u.Password == authorizationViewModel.Password
				);

			if(user is null)
				return BadRequest("Incorrect Login or Password!");

			return Ok();
		}
		catch(Exception exception) {
			return BadRequest(exception.Message);
		}
	}
}
