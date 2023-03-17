using Chat.Domain.Entities;
using Chat.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase {

	public MessageController(IUnitOfWorks unitOfWorks) {
		_unitOfWorks = unitOfWorks;
	}


	private IUnitOfWorks _unitOfWorks;



	[HttpGet]
	public IEnumerable<Message> GetAllMessages() {
		return _unitOfWorks.MessageRepository.GetAll();
	}

	[HttpGet("{id}")]
	public Message? GetMessageById(int id) {
		return _unitOfWorks
			.MessageRepository
			.GetFirstOrDefault(m => m.Id == id);
	}

	[HttpPost]
	public IActionResult AddMessage(Message message) {

		_unitOfWorks.MessageRepository.Add(message);
		_unitOfWorks.Save();

		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateMessage(Message message) {

		_unitOfWorks.MessageRepository.Update(message);
		_unitOfWorks.Save();

		return Ok();
	}

	[HttpDelete]
	public IActionResult RemoveMessage(Message message) {

		_unitOfWorks.MessageRepository.Update(message);
		_unitOfWorks.Save();

		return Ok();
	}
}
