using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using Library_Management_System.Repository;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingBookController : ControllerBase
    {
        private readonly IBorrow _borrowBookRepository;

        public BorrowingBookController(IBorrow borrowBookRepository)
        {
            _borrowBookRepository = borrowBookRepository;
        }

        [HttpPost("{bookId}/patron/{patronId}")]
        public async Task<IActionResult> BorrowBook(int bookId, int patronId)
        {
            try
            {
                await _borrowBookRepository.BorrowBook(bookId, patronId);
                return Ok("Book successfully borrowed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}

